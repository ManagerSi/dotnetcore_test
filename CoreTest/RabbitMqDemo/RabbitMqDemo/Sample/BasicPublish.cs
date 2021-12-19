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
            await Task.CompletedTask;
        }

        public async Task PublishToDefaultExchange()
        {
            _logger.LogInformation($"PublishToDefaultExchange, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            var res = await Task.FromResult(10);

            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost"; 
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.Port = 5672;

            //创建链接
            using var conn = factory.CreateConnection();

            //创建通道
            using var model = conn.CreateModel();
            //声明队列
            model.QueueDeclare("RabbitMqDemo.BasicPublish_test1", false, false, false);

            Console.WriteLine("请输入消息: 输入空值退出");
            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                IBasicProperties properties = model.CreateBasicProperties();
                properties.CorrelationId = $"{Environment.MachineName}_{DateTime.Now.ToString("yyyy-MM-dd_hh:mm:sshhhh")}";

                //Default exchange binding --exchange amp.default direct
                model.BasicPublish("", "RabbitMqDemo.BasicPublish_test1", false, properties, bytes);

                Console.WriteLine("请输入消息:");
                input = Console.ReadLine();
            }
            Console.WriteLine("已退出!");
        }

        public async Task PublishToDefaultExchange_WithPrefetch()
        {
            _logger.LogInformation($"PublishToDefaultExchange_WithPrefetch, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            var res = await Task.FromResult(10);

            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.Port = 5672;

            //创建链接
            using var conn = factory.CreateConnection();

            //创建通道
            using var model = conn.CreateModel();
            //声明队列
            model.QueueDeclare("RabbitMqDemo.BasicPublish_test1", false, false, false);
            model.QueueDeclare("RabbitMqDemo.BasicPublish_test2", false, false, false);

            Console.WriteLine("请输入消息: 输入空值退出");
            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                IBasicProperties properties = model.CreateBasicProperties();
                properties.CorrelationId = $"{Environment.MachineName}_{DateTime.Now.ToString("yyyy-MM-dd_hh:mm:sshhhh")}";

                //Default exchange binding --exchange amp.default direct
                model.BasicPublish("", "RabbitMqDemo.BasicPublish_test1", false, properties, bytes);
                model.BasicPublish("", "RabbitMqDemo.BasicPublish_test2", false, properties, bytes);

                Console.WriteLine("请输入消息:");
                input = Console.ReadLine();
            }
            Console.WriteLine("已退出!");
        }
    }
}
