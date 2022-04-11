using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            foreach (var i in Enumerable.Range(1,20))
            {
                redisClient.EnqueueItemOnList("QueueTest:queue", $"Massage {i}");
            }

            Console.WriteLine("send 20 msg to list 'QueueTest:queue'");

            Timer t = new Timer((o) =>
            {
                var value = redisClient.DequeueItemFromList("QueueTest:queue");
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("队列中数据不存在！");
                }
                else
                {
                    Console.WriteLine($"receive msg: {value}");
                }

            }, null, 0, 500);
            Console.Read();
        }
    }
}