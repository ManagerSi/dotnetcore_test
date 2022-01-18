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
    public class TopicPublish
    {
        private readonly ILogger<TopicPublish> _logger;
        public TopicPublish(ILogger<TopicPublish> logger)
        {
            _logger = logger;
        }


        public async Task Publish()
        {
            _logger.LogInformation($"TopicPublish, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.Port = 5672;

            //创建链接
            using var conn = factory.CreateConnection();

            //创建通道
            using var model = conn.CreateModel();

            model.ExchangeDelete("RabbitMqDemo.TopicExchange_Notification",false);

            //声明交换机
            model.ExchangeDeclare(
                "RabbitMqDemo.TopicExchange_Notification",
                ExchangeType.Topic,
                false,
                false,
                null
                );

            //声明队列
            model.QueueDeclare("RabbitMqDemo.TopicPublish_车", false, false, false);
            model.QueueDeclare("RabbitMqDemo.TopicPublish_玩具", false, false, false);
            model.QueueDeclare("RabbitMqDemo.TopicPublish_白色", false, false, false);
            
            //Key: * 匹配任意一个单词，# 匹配零个或者多个单词
            //When special characters "*" (star) and "#" (hash) aren't used in bindings, the topic exchange will behave just like a direct one.
            
            //绑定队列-车
            model.QueueBind(
                "RabbitMqDemo.TopicPublish_车",
                "RabbitMqDemo.TopicExchange_Notification",
                "*.*.车",
                null);

            //绑定队列-玩具
            model.QueueBind(
                "RabbitMqDemo.TopicPublish_玩具",
                "RabbitMqDemo.TopicExchange_Notification",
                "*.玩具.*",
                null
                );

            //绑定队列-颜色
            model.QueueBind(
                "RabbitMqDemo.TopicPublish_白色",
                "RabbitMqDemo.TopicExchange_Notification",
                "白色.#",
                null);
            /////////////////////////////////////////////////////////////////////////////

            var key1 = "白色.玩具.车";
            _logger.LogInformation($"发送通知：{key1} -> queue(白色.玩具.车)");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key1,
                false,
                null,
                Encoding.UTF8.GetBytes(key1)
                );

            var key2 = "红色.玩具.车";
            _logger.LogInformation($"发送通知：{key2} -> queue(玩具.车)");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key2,
                false,
                null,
                Encoding.UTF8.GetBytes(key2)
            );

            var key3 = "白色.别克.车";
            _logger.LogInformation($"发送通知：{key3} -> queue(白色.车)");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key3,
                false,
                null,
                Encoding.UTF8.GetBytes(key3)
            );

            var key5 = "白色.玩具.熊猫";
            _logger.LogInformation($"发送通知：{key5} -> queue(白色.玩具)");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key5,
                false,
                null,
                Encoding.UTF8.GetBytes(key5)
            );
            
            var key6 = "白色.小猫咪";
            _logger.LogInformation($"发送通知：{key6} -> queue(白色)");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key6,
                false,
                null,
                Encoding.UTF8.GetBytes(key6)
            );

            var key4 = "绿色.玩具.飞机";
            _logger.LogInformation($"发送通知：{key4} -> queue(玩具)");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key4,
                false,
                null,
                Encoding.UTF8.GetBytes(key4)
            );

            var key7 = "真皮.奔驰.车";
            _logger.LogInformation($"发送通知：{key7} -> queue(车)");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key7,
                false,
                null,
                Encoding.UTF8.GetBytes(key7)
            );


            var key8 = "雅雅.车";
            _logger.LogInformation($"发送通知：{key8} -> no queue");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key8,
                false,
                null,
                Encoding.UTF8.GetBytes(key8)
            );
            var key9 = "雅雅.玩具";
            _logger.LogInformation($"发送通知：{key9} -> no queue");
            model.BasicPublish(
                "RabbitMqDemo.TopicExchange_Notification",
                key9,
                false,
                null,
                Encoding.UTF8.GetBytes(key9)
            );

            _logger.LogInformation("已退出!");
        }
    }
}
