using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqConsumerDemo.Sample
{
    public class TransactionConsume
    {
        public static void ConsumeWithTransaction()
        {
            Console.WriteLine("---------------ConsumeWithTransaction!---------------");
            try
            {
                var factory = new ConnectionFactory();
                factory.HostName = "localhost"; //RabbitMQ服务在本地运行
                factory.UserName = "guest"; //用户名
                factory.Password = "guest"; //密码 

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        //declare consumer
                        var c1 = new EventingBasicConsumer(channel);
                        c1.Received += Consumer_Received;
                        var c2 = new EventingBasicConsumer(channel);
                        c2.Received += Consumer2_Received;

                        channel.BasicQos(0, 1, true); //基于信道进行限制

                        //binding consumer
                        channel.BasicConsume("RabbitMqDemo.PublishWithTransaction_test1", true, c1);
                        channel.BasicConsume("RabbitMqDemo.PublishWithTransaction_test2", true, c2);


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
    }
}