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

        #region private method
        
        private IRabbitBusBuilder UseConnectionConfig(RabbitMqConfiguration rabbitMqConfiguration)
        {
            _configuration = rabbitMqConfiguration.Connection;
            if (!string.IsNullOrEmpty(rabbitMqConfiguration.Host))
            {
                _configuration.Hosts.Add(new HostConfiguration()
                {
                    Host = rabbitMqConfiguration.Host,
                    Port = rabbitMqConfiguration.Port
                });
            }

            return this;
        }

        private IRabbitBusBuilder UseExchange(string exchangeName, Action<IExchangeDeclareConfiguration> action)
        {
            _exchangeConfigurations.Add(Tuple.Create(exchangeName, action));

            return this;
        }
        private IRabbitBusBuilder UseQueue(string exchangeName, Action<IQueueDeclareConfiguration> action)
        {
            _queueConfigurations.Add(Tuple.Create(exchangeName, action));

            return this;
        }

        private IRabbitBusBuilder UseBinding(string exchangeName, Action<IQueueDeclareConfiguration> action)
        {
            _queueConfigurations.Add(Tuple.Create(exchangeName, action));

            return this;
        }


        #endregion

        public IRabbitBusBuilder UseRabbitMqConfiguration(RabbitMqConfiguration rabbitMqConfiguration)
        {
            UseConnectionConfig(rabbitMqConfiguration);

            if (rabbitMqConfiguration?.Exchanges != null)
            {
                foreach (var exchangeConfig in rabbitMqConfiguration.Exchanges)
                {
                    UseExchange(exchangeConfig.Name, x =>
                    {
                        x.AsAutoDelete(exchangeConfig.AutoDelete);
                        x.AsDurable(exchangeConfig.Durable);
                        x.WithType(exchangeConfig.Type);

                        if (exchangeConfig.Args != null && exchangeConfig.Args.Count > 0)
                        {
                            foreach (var arg in exchangeConfig.Args)
                            {
                                x.WithArgument(arg.Key, arg.Value);
                            }
                        }
                    });
                }
            }

            if (rabbitMqConfiguration.Connection != null)
            {
                foreach (var queueConfig in rabbitMqConfiguration.Queues)
                {
                    UseQueue(queueConfig.Name, x =>
                    {
                        x.AsAutoDelete(queueConfig.AutoDelete);
                        x.AsDurable(queueConfig.Durable);
                        x.AsExclusive(queueConfig.Exclusive);
                        

                        if (queueConfig.Args != null && queueConfig.Args.Count > 0)
                        {
                            foreach (var arg in queueConfig.Args)
                            {
                                x.WithArgument(arg.Key, arg.Value);
                            }
                        }

                        if (queueConfig.PerQueueMessageTtl.HasValue)
                        {
                            x.WithMessageTtl(TimeSpan.FromMilliseconds(queueConfig.PerQueueMessageTtl.Value));
                        }
                        //if (!string.IsNullOrEmpty(queueConfig.DeadLetterExchange))
                        //{

                        //    x.WithDeadLetterExchange(queueConfig.DeadLetterExchange);
                        //}
                    });
                }
            }

            if (rabbitMqConfiguration.Binding != null)
            {
                foreach (var bindingConfig in rabbitMqConfiguration.Binding)
                {
                    _bindingConfigurations.Add(new BindingConfiguration()
                    {
                        ExchangeName = bindingConfig.ExchangeName,
                        QueueName = bindingConfig.QueueName,
                        RoutingKey = bindingConfig.RoutingKey,
                        Args =  bindingConfig.Args,
                    });
                }
            }

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
