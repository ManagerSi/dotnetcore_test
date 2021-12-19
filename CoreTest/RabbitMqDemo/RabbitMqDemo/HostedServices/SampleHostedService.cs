using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMqDemo.Sample;

namespace RabbitMqDemo.HostedServices
{
    public class SampleHostedService:IHostedService
    {
        private readonly ILogger<SampleHostedService> _logger;
        private BasicPublish _publish;
        private EasyNetQClientTest _easyNetQClientTest;

        public SampleHostedService(ILogger<SampleHostedService> logger, BasicPublish publish, EasyNetQClientTest easyNetQClientTest)
        {
            _logger = logger;
            _publish = publish;
            _easyNetQClientTest = easyNetQClientTest;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SampleHostedService start");

            //Task.Run(async () => { await _publish.Run(); });
            //Task.Run(async () => { await _easyNetQClientTest.Run(); });



            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SampleHostedService StopAsync");

            return Task.CompletedTask;
        }
    }
}
