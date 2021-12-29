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
    public class FanoutPublish
    {
        private readonly ILogger<FanoutPublish> _logger;
        public FanoutPublish(ILogger<FanoutPublish> logger)
        {
            _logger = logger;
        }


        public async Task Publish()
        {
            _logger.LogInformation($"FanoutPublish, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
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
                "RabbitMqDemo.FanoutExchange_Notification",
                ExchangeType.Fanout,
                false,
                false,
                null
                );

            //声明队列
            model.QueueDeclare("RabbitMqDemo.FanoutPublish_SMS", false, false, false);
            model.QueueDeclare("RabbitMqDemo.FanoutPublish_Email", false, false, false);

            //绑定队列
            model.QueueBind(
                "RabbitMqDemo.FanoutPublish_SMS",
                "RabbitMqDemo.FanoutExchange_Notification",
                string.Empty,
                null);

            model.QueueBind(
                "RabbitMqDemo.FanoutPublish_Email",
                "RabbitMqDemo.FanoutExchange_Notification", 
                "error",
                null
                );

            _logger.LogInformation("发送100条通知!");
            foreach (var i in Enumerable.Range(1,100))
            {
                string msg = $"通知 {i}";
                var body = Encoding.UTF8.GetBytes(msg);

                model.BasicPublish(
                    "RabbitMqDemo.FanoutExchange_Notification",
                    string.Empty,
                    false,
                    null,
                    body
                    );
            }

            _logger.LogInformation("已退出!");
        }
    }
}
