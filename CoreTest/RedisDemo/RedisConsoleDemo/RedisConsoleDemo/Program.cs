using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //String test
            //String_Test();
            //String_Test2();
            String_Test3();

            //List_Test();

            //Hash();
            //Hash_Test2();

            //SortedSet();
            //SortedSet_Test2();

            //Subscriber();

            Console.ReadKey();

        }

        #region string

        /// <summary>
        /// 测试string
        /// 1min 过期时间
        /// </summary>
        private static void String_Test()
        {
            var maxRange = 10;
            var cache = RedisConnectorHelper.GetDatabase();
            var rdn = new Random();
            for (int i = 0; i < maxRange; i++)
            {
                var next = rdn.Next(maxRange);
                cache.StringSet($"Index_Status:{i}", next, TimeSpan.FromSeconds(60));
            }

            Console.WriteLine("------get from head------");
            for (int i = 0; i < maxRange; i++)
            {
                var value = cache.StringGet($"Index_Status:{i}");
                Console.WriteLine($"Key: Index_Status:{i}, value:{value}");
            }

            Console.WriteLine("------get from rear------");
            for (int i = maxRange - 1; i > -1; i--)
            {
                var value = cache.StringGet($"Index_Status:{i}");
                Console.WriteLine($"Key: Index_Status:{i}, value:{value}");
            }
        }
        /// <summary>
        /// 测试string
        /// 过期时间:5min 
        /// </summary>
        private static void String_Test2()
        {
            var maxRange = 10000;
            var prefix = "Index_Person";

            var cache = RedisConnectorHelper.GetDatabase();
            var rdn = new Random();
            for (int i = 0; i < maxRange; i++)
            {
                var next = rdn.Next(maxRange);
                Person p = new Person() { Id = i, Age = next, Name = $"pName_{i}" };
                var pStr = JsonConvert.SerializeObject(p);

                cache.StringSet($"{prefix}:{i}", pStr, TimeSpan.FromMinutes(5));
            }

            Console.WriteLine("------get from head------");
            for (int i = 0; i < maxRange; i++)
            {
                var value = cache.StringGet($"{prefix}:{i}");
                Person p = JsonConvert.DeserializeObject<Person>(value);

                Console.WriteLine($"Key: {prefix}:{i}, value:{value}");
                Console.WriteLine($"Key: {prefix}:{i}, Person:{p.ToString()}");
            }

            Console.WriteLine("------remove------");
            for (int i = 0; i < 100; i++)
            {
                var value = cache.KeyDelete($"{prefix}:{i}");
            }
            List<RedisKey> keys = new List<RedisKey>();
            for (int i = 100; i < maxRange; i++)
            {
                keys.Add($"{prefix}:{i}");
                if (i % 50 == 0)
                {
                    cache.KeyDelete(keys.ToArray());
                    keys.Clear();
                }
            }
            if (keys.Count > 0)
                cache.KeyDelete(keys.ToArray());

        }

        /// <summary>
        /// redis 模糊查询 key 是否存在；
        /// </summary>
        public static void String_Test3()
        {
            var db = RedisConnectorHelper.GetDatabase();
            var preStr = "PatternMatch:Key_";

            for (int i = 0; i < 20; i++)
            {
                var key = preStr + i;
                db.StringSet(key, i, TimeSpan.FromMinutes(10));
                Console.WriteLine($"insert key:{key}, value:{i}");
            }

            Console.WriteLine("look the kay with *1*");
            var luaScript = "return redis.call('keys',@pattern)";
            var prepared = LuaScript.Prepare(luaScript);
            var cacheResult = db.ScriptEvaluate(prepared, new { pattern = "*1*" });
            if (cacheResult.IsNull)
            {
                Console.WriteLine("no result");
            }
            else
            {
                var keys = ((string[])cacheResult).ToList();
                Console.WriteLine($"keys: {string.Join(",",keys)}");
            }


        }

        /// <summary>
        ///  redis 模糊查询 key 是否存在；
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool KeyIsExit(string pattern)
        {
            var db = RedisConnectorHelper.GetDatabase();

            var luaScript = "return redis.call('keys',@pattern)";
            var prepared = LuaScript.Prepare(luaScript);
            var cacheResult = db.ScriptEvaluate(prepared, new { pattern = pattern });
            if (cacheResult.IsNull)
            {
                return false;
            }
            var keys = ((string[])cacheResult).ToList();
            return keys.Count > 0;
        }
        #endregion

        #region List


        public static void List_Test()
        {
            var maxRange = 10;
            var cache = RedisConnectorHelper.GetDatabase();
            var stopwatch = new Stopwatch();

            Console.WriteLine("从右侧插入数据");
            stopwatch.Start();
            for (int i = 0; i < maxRange; i++)
            {
                Person p = new Person() { Id = i, Age = i, Name = $"pName_{i}" };
                var pStr = JsonConvert.SerializeObject(p);

                //从右侧插入
                var listLength = cache.ListRightPush("GoodPeople", pStr); //.ListLeftPush()
            }
            stopwatch.Stop();
            Console.WriteLine("insertion of value at the end of the list consumes time:" + stopwatch.ElapsedMilliseconds);


            Console.WriteLine("获取列表");
            //获取列表，可指定范围
            var goodPeoples = cache.ListRange("GoodPeople", 0, -1);
            foreach (var goodPeople in goodPeoples)
            {
                Console.WriteLine(goodPeople.ToString());
            }

            Console.WriteLine("从左侧拿数据");
            stopwatch.Restart();
            for (int i = 0; i < 5; i++)
            {
                //从右侧删除
                var pStr = cache.ListLeftPop("GoodPeople");
                Console.WriteLine(pStr);
                Console.WriteLine(JsonConvert.DeserializeObject<Person>(pStr).ToString());
            }

            Console.WriteLine("从右侧拿数据");
            for (int i = 5; i < maxRange; i++)
            {
                //从右侧删除
                var pStr = cache.ListRightPop("GoodPeople");
                Console.WriteLine(pStr);
                Console.WriteLine(JsonConvert.DeserializeObject<Person>(pStr).ToString());
            }
            stopwatch.Stop();
            Console.WriteLine("pop of value at the end of the list consumes time:" + stopwatch.ElapsedMilliseconds);
            
        }

        #endregion

        #region hash

        public static void Hash()
        {
            var database = RedisConnectorHelper.GetDatabase();

            Person cang = new Person() { Id = 1, Age = 11, Name = $"cang" };
            Person shan = new Person() { Id = 2, Age = 12, Name = $"shan" };
            Person yun = new Person() { Id = 3, Age = 13, Name = $"yun" };
            database.HashSet("user", "cang", JsonConvert.SerializeObject(cang));
            database.HashSet("user", "shan", JsonConvert.SerializeObject(shan));
            database.HashSet("user", "yun", JsonConvert.SerializeObject(yun));

            //获取Model
            Console.WriteLine("获取单个");
            string hashcang = database.HashGet("user", "cang");
            var demo = JsonConvert.DeserializeObject<Person>(hashcang);//反序列化
            Console.WriteLine(demo.ToString());

            //获取List
            Console.WriteLine("获取list");
            RedisValue[] values = database.HashValues("user");//获取所有value
            foreach (var item in values)
            {
                Person hashmodel = JsonConvert.DeserializeObject<Person>(item);
                Console.WriteLine(item);
                Console.WriteLine(hashmodel.ToString());
            }

            //范围查询
            //模糊查询，在redis里,允许模糊查询有3个通配符*、?、[]、
            //* : 通配任意多个字符 ?: 通配单个字符 []: 通配括号内的某1个字符
            Console.WriteLine("范围查询,查找含有a的 hashField");
            foreach (var hashEntry in database.HashScan("user","*a*"))
            {
                Console.WriteLine(hashEntry);
            }

            Console.WriteLine($"user length: {database.HashLength("user")}");
            Console.WriteLine("删除1个 feild：cang");
            database.HashDelete("user", "cang");
            Console.WriteLine($"user length: {database.HashLength("user")}");

            Console.WriteLine("删除多个feild：shan/yun");
            database.HashDelete("user", new RedisValue[]{ "shan" , "yun" });

            Console.WriteLine($"user length: {database.HashLength("user")}");
        }

        /// <summary>
        /// 自增
        /// </summary>
        public static void Hash_Test2()
        {
            string hashKey = "Incre_HashSet";
            var db = RedisConnectorHelper.GetDatabase();

            Console.WriteLine("init");
            List<Task> tasks = new List<Task>(10);
            HashSet<string> hashFields = new HashSet<string>(10);
            for (int i = 0; i < 10; i++)
            {
                string hashField = $"Num_{i}";
                hashFields.Add(hashField);
                tasks.Add(db.HashSetAsync(hashKey, hashField, i));
                Console.WriteLine($"field:{hashField}, value:{i} ");
            }
            Task.WaitAll(tasks.ToArray());
            tasks.Clear();

            Console.WriteLine("增加");
            var rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 100; i++)
            {
                var index = rnd.Next(0, 11);
                string hashField = $"Num_{index}";
                var task = db.HashIncrementAsync(hashKey,hashField);
                var task2 = task.ContinueWith(task1 => Console.WriteLine($"field:{hashField}, incred value:{task.Result}"));
                tasks.Add(task);
                tasks.Add(task2);
            }
            Task.WaitAll(tasks.ToArray());
            tasks.Clear();

            Console.WriteLine("list all result");
            foreach (var hashEntry in db.HashGetAll(hashKey))
            {
                Console.WriteLine($"field:{hashEntry.Name}, value:{hashEntry.Value} ");
            }

            Console.WriteLine("delete all");
            var count = db.HashDelete(hashKey, hashFields.Select(i => new RedisValue(i)).ToArray());
            Console.WriteLine($"delete count: {count}");
        }

        #endregion

        #region Set



        #endregion

        #region sortedSet

        public static void SortedSet()
        {
            var db = RedisConnectorHelper.GetDatabase();

            Console.WriteLine("批量添加SortedSetEntry到sortedSet");
            SortedSetEntry[] entity1 = new SortedSetEntry[]
            {
                new SortedSetEntry("a",1),
                new SortedSetEntry("b",2),
            }; 
            SortedSetEntry[] entity2 = new SortedSetEntry[]
            {
                new SortedSetEntry("b",2),
                new SortedSetEntry("c",3),
            };
            db.SortedSetAdd("soredSet1", entity1);
            db.SortedSetAdd("soredSet2", entity2);

            Console.WriteLine("单个添加到sortedSet");
            db.SortedSetAdd("soredSet1", "d", 4);
            db.SortedSetAdd("soredSet2", "d", 4);

            //先求出两个集合的并集，同时设置重合项的乘法因子为 0（），设置聚合方式为取最小值；
            //（"weights", 1, 0）weights 为关健字，1 为key1的乘法因子，0为key2的乘法因子，有多个 key 时，以此类推；
            db.Execute("ZUNIONSTORE", "soredSet3", 2, "key1", "key2", "weights", 1, 0, "aggregate", "min");
            //去除 score 为零的的元素，得到差集；
            db.Execute("ZREMRANGEBYSCORE", "soredSet3", 0, 0);
            var queryResult = db.SortedSetRangeByScoreWithScores("soredSet3");
            Console.WriteLine("value\tscore");
            foreach (var item in queryResult)
            {
                Console.WriteLine("{0}\t{1}", item.Element, item.Score);
            }
        }

        /// <summary>
        /// 计算交集
        /// </summary>
        public static void SortedSet_Test2()
        {
            var db = RedisConnectorHelper.GetDatabase();

            Console.WriteLine("批量添加SortedSetEntry到sortedSet");
            SortedSetEntry[] entity1 = new SortedSetEntry[]
            {
                new SortedSetEntry("a",1),
                new SortedSetEntry("b",2),
            };
            SortedSetEntry[] entity2 = new SortedSetEntry[]
            {
                new SortedSetEntry("b",2),
                new SortedSetEntry("c",3),
            };
            db.SortedSetAdd("soredSet1", entity1);
            db.SortedSetAdd("soredSet2", entity2);

            Console.WriteLine("单个添加到sortedSet");
            db.SortedSetAdd("soredSet1", "d", 4);
            db.SortedSetAdd("soredSet2", "d", 4);

            //先求出两个集合的并集，同时设置重合项的乘法因子为 0（），设置聚合方式为取最小值；
            //（"weights", 1, 0）weights 为关健字，1 为key1的乘法因子，0为key2的乘法因子，有多个 key 时，以此类推；
            db.Execute("ZUNIONSTORE", "soredSet3", 2, "key1", "key2", "weights", 1, 0, "aggregate", "min");
            //去除 score 为零的的元素，得到差集；
            db.Execute("ZREMRANGEBYSCORE", "soredSet3", 0, 0);
            var queryResult = db.SortedSetRangeByScoreWithScores("soredSet3");
            Console.WriteLine("value\tscore");
            foreach (var item in queryResult)
            {
                Console.WriteLine("{0}\t{1}", item.Element, item.Score);
            }

            Console.WriteLine("删除soredSet1, SortedSetRemoveRangeByRank (0,-1)");
            Console.WriteLine(db.SortedSetLength("soredSet1"));
            db.SortedSetRemoveRangeByRank("soredSet1", 0, -1);
            Console.WriteLine(db.SortedSetLength("soredSet1"));
            Console.WriteLine("删除soredSet2, SortedSetRemoveRangeByScore (1,100)");
            Console.WriteLine(db.SortedSetLength("soredSet2"));
            db.SortedSetRemoveRangeByScore("soredSet2", 1, 100);
            Console.WriteLine(db.SortedSetLength("soredSet2"));
            Console.WriteLine("删除soredSet3");
            Console.WriteLine(db.SortedSetLength("删除soredSet3"));
            db.SortedSetRemoveRangeByValue("删除soredSet3", "a", "d");
            Console.WriteLine(db.SortedSetLength("删除soredSet3"));
        }


        #endregion

        #region Subscriber

        /// <summary>
        /// 订阅
        /// </summary>
        public static void Subscriber()
        {
            ISubscriber sub = RedisConnectorHelper.GetRedisConnect.GetSubscriber();

            //订阅 Channel1 频道
            Console.WriteLine("订阅Channel1");
            sub.Subscribe("Channel1", new Action<RedisChannel, RedisValue>((channel, message) =>
            {
                Console.WriteLine("-----Channel1" + " 订阅收到消息：" + message);
            }));

            Console.WriteLine("向频道 Channel1 发送信息 10条:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"向频道 Channel1 发送信息 msg{i}");
                sub.Publish("Channel1", "msg" + i);//向频道 Channel1 发送信息
            }

            Console.WriteLine("睡眠5秒");
            Task.Delay(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();

            Console.WriteLine("解除绑定 Channel1");
            sub.UnsubscribeAll();
        }


        #endregion

        /// <summary>
        /// 事务
        /// </summary>
        public static void Transaction()
        {
            var database = RedisConnectorHelper.GetDatabase();

            string name = database.StringGet("name");
            string age = database.StringGet("age");
            var tran = database.CreateTransaction();//创建事物
            tran.AddCondition(Condition.StringEqual("name", name));//乐观锁
            tran.StringSetAsync("name", "海");
            tran.StringSetAsync("age", 25);
            database.StringSet("name", "Cang");//此时更改 name 值，提交事物的时候会失败。
            bool committed = tran.Execute();//提交事物，true成功，false回滚。
        }


        /// <summary>
        /// 批量操作
        /// </summary>
        public static void Batch()
        {
            var database = RedisConnectorHelper.GetDatabase();

            var batch = database.CreateBatch();

            //批量写
            Task t1 = batch.StringSetAsync("name", "羽",TimeSpan.FromMinutes(10));
            Task t2 = batch.StringSetAsync("age", 22, TimeSpan.FromMinutes(10));
            batch.Execute();
            Task.WaitAll(t1, t2);
            Console.WriteLine("Age:" + database.StringGet("age"));
            Console.WriteLine("Name:" + database.StringGet("name"));

            //批量写
            List<Task> listTask = new List<Task>();
            for (int i = 0; i < 100000; i++)
            {
                listTask.Add(batch.StringSetAsync("age" + i, i, TimeSpan.FromMinutes(10)));

                listTask.Add(batch.SortedSetAddAsync("key2", "b", 1)); // 添加有序集合数据；

            }
            batch.Execute();

            //批量读
            List<Task<RedisValue>> valueList = new List<Task<RedisValue>>();
            for (int i = 0; i < 10000; i++)
            {
                Task<RedisValue> tres = batch.StringGetAsync("age" + i);
                valueList.Add(tres);
            }
            batch.Execute();
            foreach (var redisValue in valueList)
            {
                string value = redisValue.Result;//取出对应的value值
            }

        }


        /// <summary>
        /// 分布式锁
        /// </summary>
        public static void Lock()
        {
            var database = RedisConnectorHelper.GetDatabase();

            RedisValue token = Environment.MachineName;
            //lock_key表示的是redis数据库中该锁的名称，不可重复。 //token用来标识谁拥有该锁并用来释放锁。//TimeSpan表示该锁的有效时间。10秒后自动释放，避免死锁。
            if (database.LockTake("lock_key", token, TimeSpan.FromSeconds(10)))
            {
                try
                {
                    //TODO:开始做你需要的事情
                    Thread.Sleep(5000);
                }
                finally
                {
                    database.LockRelease("lock_key", token);//释放锁
                }
            }
        }

        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public override string ToString()
            {
                return $"Person- Id:{Id}, Name:{Name}, Age:{Age}";
            }
        }

    }
}
