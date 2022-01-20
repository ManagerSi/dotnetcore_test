using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqConsumerDemo.Sample
{
    public class HeaderConsumer
    {
        public static void Consume()
        {
            var conFactory = new ConnectionFactory();
            conFactory.Port = 5672;
            conFactory.HostName = "localhost";
            conFactory.UserName = "guest";
            conFactory.Password = "guest";

            using (var conn = conFactory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.QueueDeclare("RabbitMqDemo.HeaderPublish_All", false, false, false);
                    channel.QueueDeclare("RabbitMqDemo.HeaderPublish_Any", false, false, false);

                    var userConsumer = new EventingBasicConsumer(channel);
                    userConsumer.Received += UserConsumer_Received;
                    channel.BasicConsume("RabbitMqDemo.HeaderPublish_All", false, userConsumer);

                    var anyConsumer = new EventingBasicConsumer(channel);
                    anyConsumer.Received += anyConsumer_Received;
                    channel.BasicConsume("RabbitMqDemo.HeaderPublish_Any", false, anyConsumer);

                    Console.ReadLine();
                }

            }
        }

        private static void UserConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var channel = ((IBasicConsumer) sender).Model;
            channel.BasicAck(e.DeliveryTag,false);
            try
            {
                var body = e.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());

                var propList = e.BasicProperties.Headers.Select(i => i.Value is Byte[]
                    ? $"({i.Key},{Encoding.UTF8.GetString((Byte[])i.Value)})"
                    : $"({i.Key},{i.Value})"
                ).AsEnumerable();
                Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- AllConsumer_Received: {message}, prop：{ string.Join(";", propList)}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private static void anyConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var channel = ((IBasicConsumer)sender).Model;
            channel.BasicAck(e.DeliveryTag, false);

            Console.ForegroundColor = ConsoleColor.Red;

            try
            {
                var body = e.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());

                var propList = e.BasicProperties.Headers.Select(i => i.Value is Byte[]
                    ? $"({i.Key},{Encoding.UTF8.GetString((Byte[])i.Value)})"
                    : $"({i.Key},{i.Value})"
                ).AsEnumerable();

                Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- AnyConsumer_Received: {message}, prop：{string.Join(";", propList)}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception); 
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }
        }
    }
}
