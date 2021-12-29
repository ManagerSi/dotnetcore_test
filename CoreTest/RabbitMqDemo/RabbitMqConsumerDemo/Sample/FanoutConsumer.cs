using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqConsumerDemo.Sample
{
    public class FanoutConsumer
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
                    channel.QueueDeclare("RabbitMqDemo.FanoutPublish_SMS", false, false, false);
                    channel.QueueDeclare("RabbitMqDemo.FanoutPublish_Email", false, false, false);

                    channel.BasicQos(0, 1, false);

                    //declare all consumer
                    var all_consumer = new EventingBasicConsumer(channel);
                    all_consumer.Received += Consumer_Received_SMS;
                    channel.BasicConsume(
                        "RabbitMqDemo.FanoutPublish_SMS",
                        false,
                        all_consumer
                    );

                    //declare all consumer
                    var error_consumer = new EventingBasicConsumer(channel);
                    error_consumer.Received += Consumer_Received_Email;
                    channel.BasicConsume(
                        "RabbitMqDemo.FanoutPublish_Email",
                        false,
                        error_consumer
                    );

                    //block thread
                    Console.WriteLine("press any key to exit.");
                    Console.ReadLine();
                    Console.WriteLine("exit.");
                }
            }
        }

        private static void Consumer_Received_SMS(object sender, BasicDeliverEventArgs e)
        {
            var model = ((EventingBasicConsumer)sender).Model;

            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- Consumer_Received_SMS: {message}");

            model.BasicAck(e.DeliveryTag, false);//消息确认处理
        }

        private static void Consumer_Received_Email(object sender, BasicDeliverEventArgs e)
        {
            var model = ((EventingBasicConsumer)sender).Model;

            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- Consumer_Received_Email: {message}");
            Console.ForegroundColor = ConsoleColor.White;

            model.BasicAck(e.DeliveryTag, false);//消息确认处理
        }
    }
}
