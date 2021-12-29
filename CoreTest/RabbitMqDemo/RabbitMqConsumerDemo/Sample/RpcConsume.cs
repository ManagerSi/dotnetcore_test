using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqConsumerDemo.Sample
{
    public class RpcConsume
    {
        private IConnection _connection;
        private IModel _model;

        private string _queueName = "RabbitMqDemo.RpcPublish_test1";

        public void ConsumeRPC()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName="localhost",
                UserName = "guest",
                Password = "guest",
            };

            _connection = factory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(
                queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _model.BasicQos(0, 1, false);

            EventingBasicConsumer consumer = new EventingBasicConsumer(_model);
            consumer.Received += Consumer_Received;
            _model.BasicConsume(_queueName, false, consumer);


            //block thread
            Console.WriteLine("press any key to exit.");
            Console.ReadLine();
            Console.WriteLine("exit.");
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var model = ((EventingBasicConsumer) sender).Model;
            var msg = Encoding.UTF8.GetString(e.Body.ToArray());
            var props = e.BasicProperties;

            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss ffff} ------- Consumer_Received: {msg} -------");

            if (!string.IsNullOrEmpty(props?.ReplyTo))
            {
                string response = msg + "--> Return msg";
                Console.WriteLine($" ------- Return Response: {response} -------");

                var replyProps = model.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                var responseBytes = Encoding.UTF8.GetBytes(response);

                model.BasicPublish(
                    exchange: "",                // Must reply to default exchange ("")
                    routingKey: props.ReplyTo,
                    basicProperties: replyProps,
                    body: responseBytes);

            }
            model.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);

        }

        public void Close()
        {
            _model?.Close();
            _model?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
