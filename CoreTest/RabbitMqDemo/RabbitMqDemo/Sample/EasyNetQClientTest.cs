using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ.Management.Client;
using EasyNetQ.Management.Client.Model;
using Microsoft.Extensions.Logging;

namespace RabbitMqDemo.Sample
{
    /// <summary>
    /// Rabbitmq: Test with EasyNetQ.Management.Client
    /// </summary>
    public class EasyNetQClientTest
    {
        private readonly ILogger<EasyNetQClientTest> _logger;
        public EasyNetQClientTest(ILogger<EasyNetQClientTest> logger)
        {
            _logger = logger;
        }

        public async Task Run()
        {
            _logger.LogInformation("EasyNetQClientTest start.......");

            var initial = new ManagementClient("http://localhost", "guest", "guest");

            var existVhosts = await initial.GetVhostsAsync();
            foreach (var evhost in existVhosts)
            {
                var isHostAlive = await initial.IsAliveAsync(evhost);
                _logger.LogInformation($"hosts: {evhost.Name}, isHostAlive:{isHostAlive}");
            }

            _logger.LogInformation("// create an EasyNetQ exchange");
            var intExchange = await initial.CreateExchangeAsync(new ExchangeInfo("EasyNetQ_exchagne", "direct"), existVhosts[0]);

            _logger.LogInformation("// create an EasyNetQ queue");
            var intQueue = await initial.CreateQueueAsync(new QueueInfo("EasyNetQ_queue"), existVhosts[0]);

            _logger.LogInformation("// bind the exchange to the queue");
            await initial.CreateBindingAsync(intExchange, intQueue, new BindingInfo("EasyNetQ_routing_key"));

            _logger.LogInformation("// publish a test message");
            await initial.PublishAsync(intExchange, new PublishInfo("EasyNetQ_routing_key", "Hello World!"));

            _logger.LogInformation("// get any messages on the queue");
            var intMessages = await initial.GetMessagesFromQueueAsync(intQueue, new GetMessagesCriteria(1, Ackmodes.ack_requeue_false));

            foreach (var message in intMessages)
            {
                _logger.LogInformation($"message.payload = {message.Payload}");
            }

            _logger.LogInformation("// DeleteQueueAsync DeleteExchangeAsync");
            await initial.DeleteQueueAsync(intQueue);
            await initial.DeleteExchangeAsync(intExchange);



            _logger.LogInformation("// first create a new virtual host");
            var vhost = await initial.CreateVhostAsync("my_virtual_host");

            // next create a user for that virutal host
            var user = await initial.CreateUserAsync(new UserInfo("mike", "topSecret").AddTag("management"));

            _logger.LogInformation("// give the new user all permissions on the virtual host");
            await initial.CreatePermissionAsync(new PermissionInfo(user, vhost));
            //await initial.CreateTopicPermissionAsync(new TopicPermissionInfo(user, vhost));

            _logger.LogInformation("// now log in again as the new user");
            var management = new ManagementClient("http://localhost", user.Name, "topSecret");

            //_logger.LogInformation("// test that everything's OK");
            //await management.IsAliveAsync(vhost);

            _logger.LogInformation("// create an exchange");
            var exchange = await management.CreateExchangeAsync(new ExchangeInfo("my_exchagne", "direct"), vhost);

            _logger.LogInformation("// create an queue");
            var queue = await management.CreateQueueAsync(new QueueInfo("my_queue"), vhost);

            _logger.LogInformation("// bind the exchange to the queue");
            await management.CreateBindingAsync(exchange, queue, new BindingInfo("my_routing_key"));

            // publish a test message
            await management.PublishAsync(exchange, new PublishInfo("my_routing_key", "Hello World!"));

            // get any messages on the queue
            var messages = await management.GetMessagesFromQueueAsync(queue, new GetMessagesCriteria(1, Ackmodes.ack_requeue_false));

            foreach (var message in messages)
            {
                Console.Out.WriteLine("message.payload = {0}", message.Payload);
            }

            //delete virtual host
            await initial.DeleteVhostAsync(vhost);

            //delete virtual host
            await initial.DeleteUserAsync(user);

            _logger.LogInformation("EasyNetQClientTest End.........");
        }
    }
}
