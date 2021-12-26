
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;

namespace RabbitMqConsumerDemo.Sample
{
    public class BasicConsume
    {
        public static void ConsumeFromDefaultExchange()
        {
            Console.WriteLine("---------------ConsumeFromDefaultExchange!---------------");
            try
            {
                var factory = new ConnectionFactory();
                factory.HostName = "localhost";//RabbitMQ服务在本地运行
                factory.UserName = "guest";//用户名
                factory.Password = "guest";//密码 

                using (var connection = factory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        //prefetchSize：预读取的消息内容大小上限(包含)，可以简单理解为消息有效载荷字节数组的最大长度限制，0表示无上限。
                        //prefetchCount：预读取的消息数量上限，0表示无上限。
                        //global：false表示prefetchCount单独应用于信道上的每个新消费者，true表示prefetchCount在同一个信道上的消费者共享。
                        channel.BasicQos(0, 1, false);
                        //declare consumer
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += Consumer_Received;
                        
                        //binding consumer
                        channel.BasicConsume("RabbitMqDemo.BasicPublish_test1", true, consumer);

                        //block thread
                        Console.WriteLine("press any key to exit.");
                        Console.ReadLine();
                        Console.WriteLine("exit.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void ConsumeFromDefaultExchange_WithPrefetch()
        {
            Console.WriteLine("---------------ConsumeFromDefaultExchange_WithPrefetch!---------------");
            try
            {
                var factory = new ConnectionFactory();
                factory.HostName = "localhost";//RabbitMQ服务在本地运行
                factory.UserName = "guest";//用户名
                factory.Password = "guest";//密码 

                using (var connection = factory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        //默认情况下，RabbitMQ将按顺序将每条消息发送给下一个消费者。平均每个消费者将获得相同数量的消息。这种分发消息的方式叫做循环（round-robin）。
                        //设置prefetchCount : 1来告知RabbitMQ，在未收到消费端的消息确认时，不再分发消息，也就确保了当消费端处于忙碌状态时，不再分配任务。

                        #region 基于信道进行限制
                        {
                            //prefetchSize：预读取的消息内容大小上限(包含)，可以简单理解为消息有效载荷字节数组的最大长度限制，0表示无上限。
                            //prefetchCount：预读取的消息数量上限，0表示无上限。
                            //global：false表示prefetchCount单独应用于信道上的每个新消费者，true表示prefetchCount在同一个信道上的消费者共享。
                            //channel.BasicQos(0, 1, true);//基于信道进行限制

                            ////declare consumer
                            //var consumer1 = new EventingBasicConsumer(channel);
                            //consumer1.Received += Consumer_Received;
                            //var consumer2 = new EventingBasicConsumer(channel);
                            //consumer2.Received += Consumer2_Received;

                            ////binding consumer
                            //channel.BasicConsume("RabbitMqDemo.BasicPublish_test1", true, consumer1);
                            //channel.BasicConsume("RabbitMqDemo.BasicPublish_test2", true, consumer2);
                        }
                        #endregion

                        #region 基于消费者进行限制
                        {
                            //declare consumer
                            var c1 = new EventingBasicConsumer(channel);
                            c1.Received += Consumer_Received;
                            var c2 = new EventingBasicConsumer(channel);
                            c2.Received += Consumer2_Received;

                            channel.BasicQos(0, 1, true);//基于信道进行限制
                            channel.BasicQos(0, 3, false);//基于消费者进行限制

                            //binding consumer
                            channel.BasicConsume("RabbitMqDemo.BasicPublish_test1", true, c1);
                            channel.BasicConsume("RabbitMqDemo.BasicPublish_test2", true, c2);

                        }
                        #endregion

                        //block thread
                        Console.WriteLine("press any key to exit.");
                        Console.ReadLine();
                        Console.WriteLine("exit.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 接收消息并告知queue可以删除此消息
        /// model.BasicAck()
        /// </summary>
        public static void ConsumeWithAck()
        {
            Console.WriteLine("---------------ConsumeWithAck!---------------");
            try
            {
                var factory = new ConnectionFactory();
                factory.HostName = "localhost";//RabbitMQ服务在本地运行
                factory.UserName = "guest";//用户名
                factory.Password = "guest";//密码 

                using (var connection = factory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        //prefetchSize：预读取的消息内容大小上限(包含)，可以简单理解为消息有效载荷字节数组的最大长度限制，0表示无上限。
                        //prefetchCount：预读取的消息数量上限，0表示无上限。
                        //global：false表示prefetchCount单独应用于信道上的每个新消费者，true表示prefetchCount在同一个信道上的消费者共享。
                        channel.BasicQos(0, 1, false);
                        
                        //declare consumer
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += Consumer_ReceivedWithAck;
                        
                        //binding consumer
                        channel.BasicConsume("RabbitMqDemo.BasicPublishAck_test1", false, consumer); //autoAck=false,

                        //block thread
                        Console.WriteLine("press any key to exit.");
                        Console.ReadLine();
                        Console.WriteLine("exit.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} Consumer_Received: {message}");
        }
        private static void Consumer2_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} Consumer2_Received: {message}");
        }         

        private static void Consumer_ReceivedWithAck(object sender, BasicDeliverEventArgs e)
        {
            var model = ((EventingBasicConsumer) sender).Model;
            
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- Consumer_Received: {message} -------");

            Thread.Sleep(TimeSpan.FromSeconds(10));

            if (new Random().Next(10) > 5)
            {
                model.BasicAck(e.DeliveryTag, false);//消息确认处理
                Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} Consumer Return Ack");
            }
            else
            {
                //model.BasicReject(e.DeliveryTag, false);//消息处理失败，丢弃
                model.BasicNack(e.DeliveryTag, false, true);
                Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} Consumer Return Reject");
            }
        }

    }
}
