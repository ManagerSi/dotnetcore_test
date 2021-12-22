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
    public class TransactionPublish
    {
        private readonly ILogger<TransactionPublish> _logger;
        public TransactionPublish(ILogger<TransactionPublish> logger)
        {
            _logger = logger;
        }


        public async Task PublishWithTransaction()
        {
            _logger.LogInformation($"PublishWithTransaction, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
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
            model.QueueDeclare("RabbitMqDemo.PublishWithTransaction_test1", false, false, false);
            model.QueueDeclare("RabbitMqDemo.PublishWithTransaction_test2", false, false, false);

            Console.WriteLine("请输入消息: 输入空值退出");
            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                try
                {
                    _logger.LogInformation($"----获取输入{input}----");
                    IBasicProperties properties = model.CreateBasicProperties();
                    properties.CorrelationId = $"{Environment.MachineName}_{DateTime.Now.ToString("yyyy-MM-dd_hh:mm:sshhhh")}";

                    _logger.LogInformation($"----开启事务----");
                    model.TxSelect();//开启事务

                    _logger.LogInformation($"----publish queue 1----");
                    byte[] bytes1 = Encoding.UTF8.GetBytes(input);
                    model.BasicPublish("", "RabbitMqDemo.PublishWithTransaction_test1", false, properties, bytes1);

                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    _logger.LogInformation($"----publish queue 2----");
                    byte[] bytes2 = Encoding.UTF8.GetBytes(input + " with Transaction");
                    model.BasicPublish("", "RabbitMqDemo.PublishWithTransaction_test2", false, properties, bytes2);

                    _logger.LogInformation($"----提交事务----");
                    model.TxCommit();//提交事务
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "RabbitMqDemo.PublishWithTransaction Error");

                    _logger.LogInformation($"----回滚事务----");
                    model.TxRollback();
                }

                Console.WriteLine("请输入消息:");
                input = Console.ReadLine();
            }
            _logger.LogInformation("已退出!");
        }
    }
}
