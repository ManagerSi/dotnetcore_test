using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Consumer;
using EasyNetQ.Topology;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MutiBinding.Common.RabbitMq;

namespace MutiBinding.HostWorkers
{
    public class RbmqConsumerWorker : BackgroundService
    {
        private readonly ILogger<RbmqConsumerWorker> _logger;
        private IRabbitBusBuilder _rabbitBusBuilder;

        private IDisposable _consumer;
        
        public RbmqConsumerWorker(ILogger<RbmqConsumerWorker> logger, IRabbitBusBuilder rabbitBusBuilder)
        {
            _logger = logger;
            _rabbitBusBuilder = rabbitBusBuilder;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Connect to Rbmq at: {time}", DateTimeOffset.Now);
            
            using (var bus = await _rabbitBusBuilder.BuildAsync(stoppingToken))
            {
                var advanceBus = bus.Advanced;
                var queue = new Queue("MyTestQueue.test.final.q");
                _consumer = advanceBus.Consume(
                    queue,
                    HandleMqMessage,
                    config =>
                    {
                        config.WithPrefetchCount(1);
                        config.WithExclusive(false);
                    }
                );


                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(2000, stoppingToken);
                }

            }
        }

       
        //private void HandleMqMessage(byte[] body,MessageProperties properties,MessageReceivedInfo receivedInfo)
        //{
        //    var message = Encoding.UTF8.GetString(body);

        //    _logger.LogInformation($"receive MQ message: {message}");
        //}

        private Task<AckStrategy> HandleMqMessage(byte[] body, MessageProperties properties, MessageReceivedInfo receivedInfo)
        {
            var message = Encoding.UTF8.GetString(body);

            _logger.LogInformation($"receive MQ message: {message}");

            return Task.FromResult(AckStrategies.Ack);
        }
        public override void Dispose()
        {
            _logger.LogInformation($"MQ Dispose");
            _consumer?.Dispose();
        }
    }
}
