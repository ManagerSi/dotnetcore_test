using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;

namespace MutiBinding.Common.RabbitMq
{
    public class RabbitBusBuilder: IRabbitBusBuilder
    {
        public ConnectionConfiguration _configuration;
        public List<Tuple<string, Action<IExchangeDeclareConfiguration>>> _exchangeConfigurations = new List<Tuple<string, Action<IExchangeDeclareConfiguration>>>();
        public List<Tuple<string, Action<IQueueDeclareConfiguration>>> _queueConfigurations = new List<Tuple<string, Action<IQueueDeclareConfiguration>>>();
        public List<BindingConfiguration> _bindingConfigurations = new List<BindingConfiguration>();


        public IRabbitBusBuilder UseRabbitMqConfiguration(RabbitMqConfiguration rabbitMqConfiguration)
        {


            return this;
        }

        public async Task<IBus> BuildAsync(CancellationToken cancellationToken=default)
        {
            var exchanges = new List<IExchange>();
            var queues = new List<IQueue>();
            var bindings = new List<IBinding>();

            var bus = RabbitHutch.CreateBus(_configuration, x => { });
            var advanceBus = bus.Advanced;


            foreach (var exchangeConfiguration in _exchangeConfigurations)
            {
                var exchange = await advanceBus.ExchangeDeclareAsync(exchangeConfiguration.Item1, exchangeConfiguration.Item2, cancellationToken);
                exchanges.Add(exchange);
            }

            foreach (var queueConfiguration in _queueConfigurations)
            {
                var queue = await advanceBus.QueueDeclareAsync(queueConfiguration.Item1, queueConfiguration.Item2, cancellationToken);
                queues.Add(queue);
            }

            foreach (var bindingConfiguration in _bindingConfigurations)
            {
                var ex = exchanges.Single(e => e.Name.Equals(bindingConfiguration.ExchangeName, StringComparison.InvariantCultureIgnoreCase));
                var que = queues.Single(q => q.Name.Equals(bindingConfiguration.QueueName, StringComparison.InvariantCultureIgnoreCase));

                var binding = await advanceBus.BindAsync(ex, que, bindingConfiguration.RoutingKey, bindingConfiguration.Args, cancellationToken);
                bindings.Add(binding);
            }

            return bus;
        }
    }
}
