using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace MutiBinding.Common.RabbitMq
{
    public class RabbitMqConfiguration
    {
        public ConnectionConfiguration Connection { get; set; }
        public ExchangeConfiguration[] Exchanges { get; set; }
        public QueueConfiguration[] Queues { get; set; }
        public BindingConfiguration[] Binding { get; set; }
    }

    /// <summary>
    /// name: 交换机名称
    /// type: 有效的交换机类型（使用静态ExchangeType类的属性安全地声明交换）
    /// passive: 不要创建交换。 如果指定的交换不存在，则抛出异常。 （默认为false）
    /// durable: 生存服务器重新启动。 如果此参数为false，则在服务器重新启动时，交换将被删除。 （默认为true）
    /// autoDelete: 最后一个队列未被绑定时删除此交换。 （默认为false）
    /// internal: 这种交换不能由发布者直接使用，而只能由交换使用来交换绑定。 （默认为false）
    /// alternateExchange:如果无法路由邮件，则将邮件路由到此交换机。
    /// delayed:如果设置，则分配x延迟型交换以路由延迟的消息。
    /// </summary>
    public class ExchangeConfiguration
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Passive { get; set; } = false;

        public bool Durable { get; set; } = true;
        public bool AutoDelete { get; set; } = false;
        public bool Internal { get; set; } = false;
        public string AlternateExchange { get; set; } = null;
        public bool Delayed { get; set; } = false;
    }

    /// <summary>
    /// name: 队列的名称
    /// passive:如果队列不存在，则不要创建该队列，而是引发异常（默认为false）
    /// durable: 可以在服务器重新启动后继续运行 如果这是错误的，则在服务器重新启动时，队列将被删除。 （默认为true）
    /// exclusive: 只能由当前连接访问，其他连接上来会抛异常。 （默认为false）
    /// autoDelete: 所有消费者断开连接后删除队列。 （默认为false）
    /// perQueueMessageTtl:丢弃之前，消息在队列中应保留多长时间（以毫秒为单位）。 （默认未设置）
    /// expires: 自动删除之前，队列应该保持未使用状态的时间以毫秒为单位。 （默认未设置）
    /// maxPriority: 确定队列应支持的最大消息优先级。
    /// deadLetterExchange:确定交换机的名称在被服务器自动删除之前可以保持未使用状态。
    /// deadLetterRoutingKey:如果设置，将路由消息与指定的路由密钥，如果未设置，则消息将使用与最初发布的路由密钥相同的路由。
    /// maxLength: 队列中可能存在的最大可用消息数。 一旦达到限制，邮件就会从队列的前面被删除或死信，以便为新邮件腾出空间。
    /// maxLengthBytes:队列的最大大小（以字节为单位）。 一旦达到限制，邮件就会从队列的前面被删除或死信，以便为新邮件腾出空间
    /// 
    /// 请注意，如果定义了maxLength和/或maxLengthBytes属性，则RabbitMQ的行为可能并不如人们所期望的那样。 人们可能会期望代理拒绝进一步的消息; 但是RabbitMQ文档（https://www.rabbitmq.com/maxlength.html）表明，一旦达到限制，邮件将从队列的前端丢弃或死锁，以便为新邮件腾出空间。
    /// </summary>
    public class QueueConfiguration
    {
       public string Name { get; set; }
       public bool Passive { get; set; } = false;
       public bool Durable { get; set; } = true;
       public bool Exclusive { get; set; } = false;
       public bool AutoDelete { get; set; } = false;
       public int? PerQueueMessageTtl { get; set; } = null;
       public int? Expires { get; set; } = null;
       public byte? MaxPriority { get; set; } = null;
       public string DeadLetterExchange { get; set; } = null;
       public string DeadLetterRoutingKey { get; set; } = null;
       public int? MaxLength { get; set; } = null;
       public int? MaxLengthBytes { get; set; } = null;
    }

    public class BindingConfiguration
    {
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
        public Dictionary<string,object> Args {get; set; }
    }
}
