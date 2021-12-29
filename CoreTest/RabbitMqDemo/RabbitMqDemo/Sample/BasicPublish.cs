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
    /// <summary>
    /// https://gist.github.com/pizycki/5c16185bdce593447b3b561896776463#file-client-cs-L59
    /// </summary>
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
            model.QueueDeclare("RabbitMqDemo.BasicPublish_test1", //队列名
                false,  //是否持久化
                false, //排他性，该队列仅对首次声明的连接可见，并在连接断开时自动删除
                false, // true 如果该队列没有任何订阅的消费者，则该队列会被自动删除
                null);  //如果安装了队列优先级插件，可以设置消息优先级

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

        /// <summary>
        /// 发布消息并返回成功
        /// model.WaitForConfirms()
        /// </summary>
        /// <returns></returns>
        public async Task PublishWithAck()
        {
            _logger.LogInformation($"PublishToDefaultExchange, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(TimeSpan.FromSeconds(1));

            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.Port = 5672;

            //创建链接
            using var conn = factory.CreateConnection();
            conn.CallbackException += Connetion_CallbackException;
            conn.ConnectionBlocked += Connetion_ConnectionBlocked;
            conn.ConnectionUnblocked += Connetion_ConnectionUnblocked;
            //conn.RecoverySucceeded += Connetion_RecoverySucceeded;
            //conn.ConnectionRecoveryError += Connetion_ConnectionRecoveryError;
            //连接关闭的时候
            conn.ConnectionShutdown += Connetion_ConnectionShutdown;

            //创建通道
            using var model = conn.CreateModel();

            //broker 发现当前消息无法被路由到指定的 queues 中（如果设置了 mandatory 属性，则 broker 会先发送 basic.return）
            model.BasicReturn += Channel_BasicReturn;

            //声明队列
            model.QueueDeclare("RabbitMqDemo.BasicPublishAck_test1", false, false, false);
            
            //开启确认模式
            model.ConfirmSelect();

            _logger.LogInformation("请输入消息: 输入空值退出");
            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                IBasicProperties properties = model.CreateBasicProperties();
                properties.CorrelationId = $"{Environment.MachineName}_{DateTime.Now.ToString("yyyy-MM-dd_hh:mm:sshhhh")}";

                //Default exchange binding --exchange amp.default direct
                model.BasicPublish("", "RabbitMqDemo.BasicPublishAck_test1", false, properties, bytes);

                //投递确认1，批量Confirm模式
                //try
                //{
                //    //无返回，则该方法将引发超时的异常
                //    model.WaitForConfirmsOrDie(TimeSpan.FromMilliseconds(1));
                //}
                //catch (Exception e)
                //{
                //    _logger.LogError(e, "消息投递失败!");
                //}


                //投递确认2 //无返回，该方法不会引发超时的异常
                if (model.WaitForConfirms(TimeSpan.FromMilliseconds(10)))
                {
                    _logger.LogInformation("消息投递成功!");
                }
                else
                {
                    _logger.LogError("消息投递失败!");
                    //重试机制
                }

                _logger.LogInformation("请输入消息:");
                input = Console.ReadLine();
            }
            Console.WriteLine("已退出!");
        }

        /// <summary>
        /// 发布持久化消息
        /// </summary>
        /// <returns></returns>
        public async Task PublishWithStatick()
        {

        }


        private static void Channel_BasicReturn(object sender, RabbitMQ.Client.Events.BasicReturnEventArgs e)
        {
            Console.WriteLine("Channel_BasicReturn");
        }

        private static void Connetion_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("Connetion_ConnectionShutdown");
        }

        private static void Connetion_ConnectionUnblocked(object sender, EventArgs e)
        {
            Console.WriteLine("Connetion_ConnectionUnblocked");
        }

        private static void Connetion_ConnectionBlocked(object sender, RabbitMQ.Client.Events.ConnectionBlockedEventArgs e)
        {
            Console.WriteLine("Connetion_ConnectionBlocked");
        }

        private static void Connetion_ConnectionRecoveryError(object sender, RabbitMQ.Client.Events.ConnectionRecoveryErrorEventArgs e)
        {
            Console.WriteLine("Connetion_ConnectionRecoveryError");
        }

        private static void Connetion_RecoverySucceeded(object sender, EventArgs e)
        {
            Console.WriteLine("Connetion_RecoverySucceeded");
        }

        private static void Connetion_CallbackException(object sender, RabbitMQ.Client.Events.CallbackExceptionEventArgs e)
        {
            Console.WriteLine("Connetion_CallbackException");
        }
    }
}
