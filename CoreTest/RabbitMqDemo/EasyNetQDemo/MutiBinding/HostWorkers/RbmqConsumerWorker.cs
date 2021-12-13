using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MutiBinding.Common.RabbitMq;

namespace MutiBinding.HostWorkers
{
    public class RbmqConsumerWorker : BackgroundService
    {
        private readonly ILogger<RbmqConsumerWorker> _logger;
        private IRabbitBusBuilder _rabbitBusBuilder;

        public RbmqConsumerWorker(ILogger<RbmqConsumerWorker> logger, IRabbitBusBuilder rabbitBusBuilder)
        {
            _logger = logger;
            _rabbitBusBuilder = rabbitBusBuilder;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
