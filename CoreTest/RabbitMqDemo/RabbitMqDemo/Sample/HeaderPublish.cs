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
    public class HeaderPublish
    {
        private readonly ILogger<HeaderPublish> _logger;
        public HeaderPublish(ILogger<HeaderPublish> logger)
        {
            _logger = logger;
        }


        public async Task Publish()
        {
            _logger.LogInformation($"HeaderPublish, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");

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
                "RabbitMqDemo.HeaderExchange_Notification",
                ExchangeType.Headers,  //header
                false,
                false,
                null
                );

            //声明队列
            model.QueueDeclare("RabbitMqDemo.HeaderPublish_All", false, false, false);
            model.QueueDeclare("RabbitMqDemo.HeaderPublish_Any", false, false, false);

            //绑定队列
            model.QueueBind(
                "RabbitMqDemo.HeaderPublish_All",
                "RabbitMqDemo.HeaderExchange_Notification",
                string.Empty,
                new Dictionary<string, object>()
                {
                    {"x-match","all" }, // 需要消息的prop.Headers中同时包含 user pass 两个属性才能转发到当前queue (键值对必须全匹配)
                    {"user","jerry" },
                    {"pass","123" }
                });

            model.QueueBind(
                "RabbitMqDemo.HeaderPublish_Any",
                "RabbitMqDemo.HeaderExchange_Notification",
                "",
                new Dictionary<string, object>()
                {
                    {"x-match","any" }, // 需要消息的prop.Headers中部份包含 user 或 pass 就能转发到当前queue (键值对必须全匹配)
                    {"user","jerry" },
                    {"pass","123" }
                }
                );

            _logger.LogInformation("发送Header通知!");
            {
                string msg = $"all/any";
                _logger.LogInformation($"发送{msg}通知!");
                var body = Encoding.UTF8.GetBytes(msg);

                var prop = model.CreateBasicProperties();
                prop.Headers = new Dictionary<string, object>()
                {
                    {"user","jerry" }, //完全匹配键值对
                    {"pass","123" },
                    {"age",15 }
                };
                model.BasicPublish(
                    "RabbitMqDemo.HeaderExchange_Notification",
                    string.Empty,
                    false,
                    prop,
                    body
                );
            }
            {
                string msg = $"any";
                _logger.LogInformation($"发送{msg}通知!");
                var body = Encoding.UTF8.GetBytes(msg);

                var prop = model.CreateBasicProperties();
                prop.Headers = new Dictionary<string, object>()
                {
                    {"user","celia" },
                    {"pass","123" }, //匹配 pass 即可
                    {"age",15 }
                };
                model.BasicPublish(
                    "RabbitMqDemo.HeaderExchange_Notification",
                    string.Empty,
                    false,
                    prop,
                    body
                );
            }
            {
                string msg = $"any";
                _logger.LogInformation($"发送{msg}通知!");
                var body = Encoding.UTF8.GetBytes(msg);

                var prop = model.CreateBasicProperties();
                prop.Headers = new Dictionary<string, object>()
                {
                    {"user","jerry" }, //匹配 user
                    {"pass","456" }
                };
                model.BasicPublish(
                    "RabbitMqDemo.HeaderExchange_Notification",
                    string.Empty,
                    false,
                    prop,
                    body
                );
            }

            _logger.LogInformation("已退出!");
        }
    }
}
