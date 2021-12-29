using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMqDemo.HostedServices;
using RabbitMqDemo.Sample;

namespace RabbitMqDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            #region basicPublish

            //var basicPublish = host.Services.GetService(typeof(BasicPublish)) as BasicPublish;

            //basicPublish.PublishToDefaultExchange()
            //.ConfigureAwait(false).GetAwaiter().GetResult();

            //basicPublish.PublishToDefaultExchange_WithPrefetch()
            //    .ConfigureAwait(false).GetAwaiter().GetResult();

            //basicPublish.PublishWithAck() //ȷ����ϢͶ�ݵ�queue��
            //    .ConfigureAwait(false).GetAwaiter().GetResult();

            #endregion

            #region Transaction

            //var transactionPublish = host.Services.GetService(typeof(TransactionPublish)) as TransactionPublish;
            //transactionPublish.PublishWithTransaction()
            //.ConfigureAwait(false).GetAwaiter().GetResult();

            #endregion

            #region Rpc

            //var rpcPublish = host.Services.GetService(typeof(RpcPublish)) as RpcPublish;
            //Console.WriteLine("��������Ϣ: �����ֵ�˳�");
            //var input = Console.ReadLine();
            //while (!string.IsNullOrEmpty(input))
            //{
            //    var response = rpcPublish.PublishRPC(input)
            //    .ConfigureAwait(false).GetAwaiter().GetResult();

            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"-- Main thread Get response: {response}");

            //    Console.WriteLine("��������Ϣ:");
            //    input = Console.ReadLine();
            //}
            //Console.WriteLine("���˳�!");
            //rpcPublish.Close();

            #endregion

            #region DirectPublish

            var directPublish = host.Services.GetService(typeof(DirectPublish)) as DirectPublish;
            directPublish.Publish()
                .ConfigureAwait(false).GetAwaiter().GetResult();

            Console.WriteLine("���˳�!");

            #endregion

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                }).ConfigureServices(s =>
                {
                    s.AddLogging();
                    s.AddSingleton<EasyNetQClientTest>();
                    s.AddSingleton<BasicPublish>();
                    s.AddSingleton<TransactionPublish>();
                    s.AddSingleton<RpcPublish>();
                    s.AddSingleton<DirectPublish>();


                    s.AddHostedService<SampleHostedService>();
                });
    }
}
