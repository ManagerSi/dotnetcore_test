using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace RabbitMqDemo.Sample
{
    public class BasicPublish
    {
        private readonly ILogger<BasicPublish> _logger;
        public BasicPublish(ILogger<BasicPublish> logger)
        {
            _logger = logger;
        }
        public async Task Run()
        {
            _logger.LogInformation($"ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            var res = await Task.FromResult(10);
            _logger.LogInformation($"ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");

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
                    var input = Console.ReadLine();
                    while (!string.IsNullOrEmpty(input))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(input);

                        IBasicProperties properties = model.CreateBasicProperties();
                        properties.CorrelationId = $"{Environment.MachineName}_{DateTime.Now.ToString("yyyy-MM-dd_hh:mm:sshhhh")}";

                        //Default exchange binding --exchange amp.default direct
                        model.BasicPublish("", "BasicPublish_test1", false, properties, bytes);

                        Console.WriteLine("请输入消息:");
                        input = Console.ReadLine();
                    }
                }
            }

            
        }
    }
}
