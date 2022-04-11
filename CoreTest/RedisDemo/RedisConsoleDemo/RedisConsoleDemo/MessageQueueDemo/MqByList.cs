using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace RedisConsoleDemo.MessageQueueDemo
{
    public class MqByList
    {
        //版本2：使用Redis的客户端管理器（对象池）
        private static IRedisClientsManager redisClientManager = new PooledRedisClientManager(new string[]
        {
            //如果是Redis集群则配置多个{IP地址:端口号}即可
            //例如: "10.0.0.1:6379","10.0.0.2:6379","10.0.0.3:6379"
            "127.0.0.1:6379"
        });
        //从池中获取Redis客户端实例
        private static IRedisClient redisClient = redisClientManager.GetClient();

        public static void Demo()
        {
            //  redisClient.Password = "123";
            Task.Run(() => InsertMsgToQueue());
            
            Timer t = new Timer((o) =>
            {
                using var client = redisClientManager.GetClient();
                var value = client.DequeueItemFromList("QueueTest:queue");
                Console.WriteLine(string.IsNullOrWhiteSpace(value) ? "队列中数据不存在！" : $"receive msg: {value}");
            }, null, 0, 100);
            Console.Read();
        }

        private static void InsertMsgToQueue()
        {
            while (true)
            {
                try
                {
                    using var client = redisClientManager.GetClient();
                    foreach (var i in Enumerable.Range(1, 20))
                    {
                        client.EnqueueItemOnList("QueueTest:queue", $"Massage {i}");
                    }
                    Console.WriteLine("send 20 msg to list 'QueueTest:queue'");
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