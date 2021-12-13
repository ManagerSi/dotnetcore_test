using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MutiBinding.Common.RabbitMq;
using MutiBinding.HostWorkers;

namespace MutiBinding
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;

                    var rabbitConfig = config.GetSection("RabbitMqConfiguration").Get<RabbitMqConfiguration>();
                    services.AddSingleton<IRabbitBusBuilder>(CreateRabbitMqBusBuilder(rabbitConfig));
                    

                    services.AddHostedService<RbmqConsumerWorker>();
                })
                .UseWindowsService();

        private static IRabbitBusBuilder CreateRabbitMqBusBuilder(RabbitMqConfiguration rabbitConfig)
        {
            return new RabbitBusBuilder()
                .UseRabbitMqConfiguration(rabbitConfig);
        }
    }
}
