using System;
using RabbitMqConsumerDemo.Sample;

namespace RabbitMqConsumerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BasicConsume

            Console.WriteLine("---------------BasicConsume!---------------");
            //BasicConsume.ConsumeFromDefaultExchange();

            BasicConsume.ConsumeFromDefaultExchange_WithPrefetch();

            #endregion;
        }
    }
}
