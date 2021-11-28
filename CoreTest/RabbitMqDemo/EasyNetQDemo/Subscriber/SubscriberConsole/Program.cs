using EasyNetQ;
using System;

namespace SubscriberConsole
{
    //连接
    //https://www.cnblogs.com/forcesoul/category/1125580.html
    //https://blog.51cto.com/lhxsoft/3182306

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string connectionStr = "host=localhost;username=guest;password=guest";

            using (var bus = RabbitHutch.CreateBus(connectionStr))
            {
                bus.PubSub.SubscribeAsync<string>(string.Empty, HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        public static void HandleTextMessage(string textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage);
            Console.ResetColor();
        }
    }

    //注意，收发必须是相同的class，包括命名空间，否则接收时报错
    [Queue("TestMessagesQueue", ExchangeName = "MyTestExchange")]
    public class TextMessage
    {
        public string Text { get; set; }
    }
}
