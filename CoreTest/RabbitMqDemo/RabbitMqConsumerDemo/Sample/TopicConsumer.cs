using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqConsumerDemo.Sample
{
    public class TopicConsumer
    {
        public static void Consume()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";

            using (var conn = factory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    //声明队列,若不声明，如果queue不存在，则报错 NOT_FOUND
                    channel.QueueDeclare("RabbitMqDemo.TopicPublish_车", false, false, false);
                    channel.QueueDeclare("RabbitMqDemo.TopicPublish_玩具", false, false, false);
                    channel.QueueDeclare("RabbitMqDemo.TopicPublish_白色", false, false, false);
                    channel.BasicQos(0, 1, false);

                    //declare all consumer
                    var 车_consumer = new EventingBasicConsumer(channel);
                    车_consumer.Received += Consumer_Received_车;
                    channel.BasicConsume(
                        "RabbitMqDemo.TopicPublish_车",
                        false,
                        车_consumer
                    );

                    //declare all consumer
                    var 玩具_consumer = new EventingBasicConsumer(channel);
                    玩具_consumer.Received += Consumer_Received_玩具;
                    channel.BasicConsume(
                        "RabbitMqDemo.TopicPublish_玩具",
                        false,
                        玩具_consumer
                    );

                    //declare all consumer
                    var 白色_consumer = new EventingBasicConsumer(channel);
                    白色_consumer.Received += Consumer_Received_白色;
                    channel.BasicConsume(
                        "RabbitMqDemo.TopicPublish_白色",
                        false,
                        白色_consumer
                    );

                    //block thread
                    Console.WriteLine("press any key to exit.");
                    Console.ReadLine();
                    Console.WriteLine("exit.");
                }
            }
        }

        private static void Consumer_Received_车(object sender, BasicDeliverEventArgs e)
        {
            var model = ((EventingBasicConsumer)sender).Model;

            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- Consumer_Received_车: {message}");

            model.BasicAck(e.DeliveryTag, false);//消息确认处理
        }

        private static void Consumer_Received_玩具(object sender, BasicDeliverEventArgs e)
        {
            var model = ((EventingBasicConsumer)sender).Model;

            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- Consumer_Received_玩具: {message}");
            Console.ForegroundColor = ConsoleColor.White;

            model.BasicAck(e.DeliveryTag, false);//消息确认处理
        }

        private static void Consumer_Received_白色(object sender, BasicDeliverEventArgs e)
        {
            var model = ((EventingBasicConsumer)sender).Model;

            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- Consumer_Received_白色: {message}");
            Console.ForegroundColor = ConsoleColor.White;

            model.BasicAck(e.DeliveryTag, false);//消息确认处理
        }
    }
}
