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
            var basicPublish = host.Services.GetService(typeof(BasicPublish)) as BasicPublish;

            #region basicPublish

            //basicPublish.PublishToDefaultExchange()
                //.ConfigureAwait(false).GetAwaiter().GetResult();

            basicPublish.PublishToDefaultExchange_WithPrefetch()
                .ConfigureAwait(false).GetAwaiter().GetResult();
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
                    s.AddSingleton<BasicPublish>();
                    s.AddSingleton<EasyNetQClientTest>();


                    s.AddHostedService<SampleHostedService>();
                });
    }
}
