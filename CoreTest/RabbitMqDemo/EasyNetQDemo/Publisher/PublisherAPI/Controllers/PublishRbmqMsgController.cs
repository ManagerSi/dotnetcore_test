using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;

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
