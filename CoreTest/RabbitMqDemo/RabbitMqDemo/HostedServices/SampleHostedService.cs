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

        public SampleHostedService(ILogger<SampleHostedService> logger, BasicPublish publish)
        {
            _logger = logger;
            _publish = publish;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SampleHostedService start");

            Task.Run(
                async () => { await _publish.Run(); }
            );
            

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SampleHostedService StopAsync");

            return Task.CompletedTask;
        }
    }
}
