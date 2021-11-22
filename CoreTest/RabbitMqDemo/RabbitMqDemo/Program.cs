using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateHostBuilder(args).Build().Run();
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
