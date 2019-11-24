using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace sql_server_application_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================Hello World!================================");

            //ApplicationToRun("app1");

            //同步，没有问题
            MockMutiApplicationToRun();

            //异步-->Parallel类的For方法并没有等待延迟，而是直接完成. parallel类只等待它创建的任务，而不等待其它后台活动
            //MockMutiApplicationToRunAsycn();

            Console.WriteLine("===================================Down!==================================");
            Console.ReadKey();
        }

        #region 同步方法
        /// <summary>
        /// https://www.cnblogs.com/afei-24/p/6904179.html
        /// 使用Parallel.ForEach 开启多个app
        /// </summary>
        static void MockMutiApplicationToRun()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            ParallelLoopResult plr = Parallel.ForEach(list , s =>
            {
                ApplicationToRun("appServer" + s);
            });

            if (plr.IsCompleted)
                Console.WriteLine("all appServer completed!");
        }

        /// <summary>
        /// 开启一个app server
        /// </summary>
        /// <param name="appServerName">设置appServerName</param>
        static void ApplicationToRun(string appServerName)
        {
            string connStr = "Data Source=localhost;Integrated Security=SSPI;user id=jerry;password=jerry";
            using (SqlLock sqlLock = new SqlLock(connStr, "App_lockKey", 3000))
            {
                if (sqlLock.LockCreated)
                {
                    Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::get lock.");
                    
                    ProcessDataForLongTime(appServerName);
                }
                else
                {
                    Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::can't get lock.");
                }
            }
            Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::finished.");
        }

        /// <summary>
        /// 处理数据的方法
        /// </summary>
        /// <param name="appServerName">设置appServerName</param>
        static void ProcessDataForLongTime(string appServerName)
        {
            Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::ProcessData.");
            Task.Delay(TimeSpan.FromSeconds(10)).GetAwaiter().GetResult();
            //Thread.Sleep(TimeSpan.FromSeconds(15));
        }
        #endregion 同步方法


        #region 异步方法
        /// <summary>
        /// 使用Parallel.ForEach 开启多个app
        /// </summary>
        static void MockMutiApplicationToRunAsycn()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            ParallelLoopResult plr = Parallel.ForEach(list, async s =>
            {
               await ApplicationToRunAsync("appServer" + s);
            });

            if (plr.IsCompleted)
                Console.WriteLine("all appServer completed!");
        }

        /// <summary>
        /// 开启一个app server
        /// </summary>
        /// <param name="appServerName">设置appServerName</param>
        static async Task ApplicationToRunAsync(string appServerName)
        {
            string connStr = "Data Source=localhost;Integrated Security=SSPI;user id=jerry;password=jerry";
            using (SqlLock sqlLock = new SqlLock(connStr, "App_lockKey", 3000))
            {
                if (sqlLock.LockCreated)
                {
                    Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::get lock.");

                    await ProcessDataForLongTimeAsync(appServerName);
                }
                else
                {
                    Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::can't get lock.");
                }
            }
            Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::finished.");
        }

        /// <summary>
        /// 异步处理数据的方法
        /// 线程不是由parallel生成，所以parallel不会等待该线程
        /// </summary>
        /// <param name="appServerName">设置appServerName</param>
        static async Task ProcessDataForLongTimeAsync(string appServerName)
        {
            Console.WriteLine($"CurrentThread:{Thread.CurrentThread.ManagedThreadId}  {appServerName}::ProcessData.");
            await Task.Delay(TimeSpan.FromSeconds(10));
        }
        #endregion 异步方法


    }
}
