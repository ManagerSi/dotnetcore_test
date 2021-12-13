using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;

namespace MutiBinding.Common.RabbitMq
{
    public interface IRabbitBusBuilder
    {
        IRabbitBusBuilder UseRabbitMqConfiguration(RabbitMqConfiguration rabbitMqConfiguration);
        Task<IBus> BuildAsync(CancellationToken cancellationToken = default);
    }
}
