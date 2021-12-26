using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqDemo.Sample
{
    public class RpcPublish
    {


        private readonly ILogger<RpcPublish> _logger;

        private IConnection _connection;
        private IModel _model;
        
        private string _exchangeName = "RabbitMqDemo.RpcExchange";
        private string _queueName = "RabbitMqDemo.RpcPublish_test1";
        private string _routingKey = "RabbitMqDemo.RpcPublish*";
        private string _replyToQueue = "RabbitMqDemo.RpcPublish_test1.reply-to";

        private Dictionary<string, TaskCompletionSource<string>> _replyMsgDict = new Dictionary<string, TaskCompletionSource<string>>();

        public RpcPublish(ILogger<RpcPublish> logger)
        {
            _logger = logger;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            };

            _connection = factory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(_queueName, false, false, false, null);
            _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic,false,false,null);
            _model.QueueBind(_queueName, _exchangeName, _routingKey, null);

            //配置replay
            _model.QueueDeclare(_replyToQueue, false, false, false, null);
            EventingBasicConsumer consumer = new EventingBasicConsumer(_model);
            consumer.Received += Consumer_Received;
            _model.BasicConsume(_replyToQueue, true, consumer);

        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var msg = Encoding.UTF8.GetString(e.Body.ToArray());
            _logger.LogInformation($"-- Get reply Message: {msg} --");

            var correlationId = e.BasicProperties.CorrelationId;
            if (_replyMsgDict.ContainsKey(correlationId))
            {
                var task = _replyMsgDict[correlationId];
                _logger.LogInformation($"--Set Message to Task --");
                task.SetResult(msg);
            }
        }

        public Task<string> PublishRPC(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);

            _logger.LogInformation($"--Publish Message to Queue:{_queueName} --");

            var prop = _model.CreateBasicProperties();
            prop.CorrelationId = Guid.NewGuid().ToString();
            prop.ReplyTo = _replyToQueue;
            _model.BasicPublish(_exchangeName,_routingKey,false,prop, messageBytes);

            //设置task等待，等Consumer_Received拿到消息后给task赋值
            TaskCompletionSource<string> souceTask = new TaskCompletionSource<string>();
            _replyMsgDict.Add(prop.CorrelationId, souceTask);

            return souceTask.Task;
        }

    }
}
