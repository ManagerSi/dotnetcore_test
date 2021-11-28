using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishRbmqMsgController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult("ok");
        }

        [HttpGet]
        [Route("PublishMsage")]
        public async Task<IActionResult> PublishMsage(string msg, int times =1, string exchangeName="defaultExc", string queueName="defaultQue")
        {
            string connectionStr = "host=localhost;username=guest;password=guest";

            using (var bus = RabbitHutch.CreateBus(connectionStr))
            {
                msg = msg?? "default msg";
                Console.WriteLine("PublishDefaultMsage: PubSub.PublishAsync");
                var exchange = await bus.Advanced.ExchangeDeclareAsync(exchangeName, ExchangeType.Topic, false);
                var queue = await bus.Advanced.QueueDeclareAsync(queueName, false, false, false);
                var binding = await bus.Advanced.BindAsync(exchange, queue, "",
                    new Dictionary<string, object>()
                    {
                        //{"id",msg}
                    });
                
                int count = 0;
                while (count < times)
                {
                    var message = new Message<string>(msg);
                    message.Properties.AppId = msg + "id_"+count;
                    message.Properties.ReplyTo = "my_reply_queue";
                    await bus.Advanced.PublishAsync(exchange, queueName, false, message);
                    count++;
                }
            }
            return new JsonResult("ok");
        }

        #region For SubscriberConsole

        [HttpGet]
        [Route("PublishDefaultMsage")]
        public async Task<IActionResult> PublishDefaultMsage()
        {
            string connectionStr = "host=localhost;username=guest;password=guest";

            using (var bus = RabbitHutch.CreateBus(connectionStr))
            {
                var input = "abcd";
                Console.WriteLine("PublishDefaultMsage: PubSub.PublishAsync");
                await bus.PubSub.PublishAsync(input);
            }
            return new JsonResult("ok");
        }

        #endregion For SubscriberConsole

        
        [HttpGet]
        [Route("PublishClassMsage")]
        public async Task<IActionResult> PublishClassMsage()
        {
            string connectionStr = "host=localhost;username=guest;password=guest";

            using (var bus = RabbitHutch.CreateBus(connectionStr))
            {
                var input = "abcd";
                Console.WriteLine("PublishDefaultMsage: PubSub.PublishAsync");
                await bus.PubSub.PublishAsync<TextMessage>(new TextMessage { Text = input});//注意，收发必须是相同的class，包括命名空间，否则接收时报错
            }
            return new JsonResult("ok");
        }

        [Queue("TestMessagesQueue", ExchangeName = "MyTestExchange")]
        public class TextMessage
        {
            public string Text { get; set; }
        }
    }
}
