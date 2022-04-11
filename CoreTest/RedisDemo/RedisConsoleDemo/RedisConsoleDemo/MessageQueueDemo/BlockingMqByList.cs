using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSRedis;

namespace RedisConsoleDemo.MessageQueueDemo
{
    /// <summary>
    /// 本次使用 ASPNetCore 完成RedisMQ的实践，引入Redis国产第三方开源库CSRedisCore.
    /// 
    /// 不使用著名的StackExchange.Redis 组件库的原因：
    /// 
    /// 之前一直使用StackExchange.Redis， 参考了很多资料，做了很多优化，并未完全解决RedisTimeoutException问题 
    /// 
    /// StackExchange.Redis基于其多路复用的连接机制，不支持阻塞式命令， 故采用了 CSRedisCore，该库强调了API 与Redis官方命令一致，很容易上手
    /// </summary>
    public class BlockingMqByList
    {
        public static void Demo()
        {
            //  redisClient.Password = "123";
            Task.Run(() => InsertMsgToQueue());

            Timer t = new Timer((o) =>
            {
                using var csredis = new CSRedisClient("127.0.0.1:6379");

                var value = csredis.BRPop(5,"QueueTest:queue"); // 阻塞读，若指定List没有新元素，在给定超时时间内，该命令会阻塞当前redis连接，直到超时返回nil， 这样做的目的在于减小Redis压力。 
                Console.WriteLine(string.IsNullOrWhiteSpace(value) ? "队列中数据不存在！" : $"receive msg: {value}");
            }, null, 0, 50);
            Console.Read();
        }

        private static void InsertMsgToQueue()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("send 20 msg to list 'QueueTest:queue'");

                    using var csredis = new CSRedisClient("127.0.0.1:6379");

                    var msgs = Enumerable.Range(1, 20).Select(i => $"Massage {i}").ToArray();
                    csredis.LPush("QueueTest:queue", msgs);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                Thread.Sleep(2500);
            }

        }
    }
}
