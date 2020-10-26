using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMqDemo.Sample
{
    public class BasicPublish
    {
        public void PublishMsg(string input)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost"; 
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.Port = 5672;

            //创建链接
            using (var conn = factory.CreateConnection())
            {

                //创建通道
                using (var model = conn.CreateModel())
                {

                    //声明队列
                    model.QueueDeclare("BasicPublish_test1", false, false, true);

                    Console.WriteLine("请输入消息: 输入空值退出");
                    input = Console.ReadLine();
                    while (!string.IsNullOrEmpty(input))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(input);

                        IBasicProperties properties = model.CreateBasicProperties();
                        properties.CorrelationId = $"{Environment.MachineName}_{DateTime.Now.ToString("yyyy-MM-dd_hh:mm:sshhhh")}";

                        //Default exchange binding --exchange amp.default direct
                        model.BasicPublish("", "BasicPublish_test1", false, properties, bytes);

                        Console.WriteLine("请输入消息: 输入空值退出");
                        input = Console.ReadLine();
                    }
                }
            }


        }
    }
}
