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
    public class DirectPublish
    {
        private readonly ILogger<DirectPublish> _logger;
        public DirectPublish(ILogger<DirectPublish> logger)
        {
            _logger = logger;
        }


        public async Task Publish()
        {
            _logger.LogInformation($"DirectPublish, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
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

            //声明交换机
            model.ExchangeDeclare(
                "RabbitMqDemo.DirectExchange_Log",
                ExchangeType.Direct,
                false,
                false,
                null
                );

            //声明队列
            model.QueueDeclare("RabbitMqDemo.DirectPublish_Log_all", false, false, false);
            model.QueueDeclare("RabbitMqDemo.DirectPublish_Log_error", false, false, false);

            //绑定all队列
            string[] logTypes = new[] {"debug", "info", "warn", "error"};
            foreach (var logType in logTypes)
            {
                model.QueueBind(
                    "RabbitMqDemo.DirectPublish_Log_all",
                    "RabbitMqDemo.DirectExchange_Log",
                    logType,
                    null);
            }
            //绑定error队列
            model.QueueBind(
                "RabbitMqDemo.DirectPublish_Log_error",
                "RabbitMqDemo.DirectExchange_Log", 
                "error",
                null
                );

            _logger.LogInformation("发送100条日志!");
            foreach (var i in Enumerable.Range(1,100))
            {
                var routingKey = logTypes[i % 4];
                string msg = $"{routingKey} {i}";
                var body = Encoding.UTF8.GetBytes(msg);

                model.BasicPublish(
                    "RabbitMqDemo.DirectExchange_Log",
                    routingKey,
                    false,
                    null,
                    body
                    );
            }

            _logger.LogInformation("已退出!");
        }
    }
}
