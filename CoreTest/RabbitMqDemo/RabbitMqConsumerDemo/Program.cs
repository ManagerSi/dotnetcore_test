using System;
using RabbitMqConsumerDemo.Sample;

namespace RabbitMqConsumerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BasicConsume

            //Console.WriteLine("---------------BasicConsume!---------------");
            //BasicConsume.ConsumeFromDefaultExchange();

            //BasicConsume.ConsumeFromDefaultExchange_WithPrefetch();

            //BasicConsume.ConsumeWithAck();

            #endregion

            #region Transaction

            //Console.WriteLine("---------------Transaction!---------------");
            //TransactionConsume.ConsumeWithTransaction();

            #endregion

            #region Rpc

            //Console.WriteLine("---------------Rpc!---------------");
            //var rpcConsume= new RpcConsume();
            //rpcConsume.ConsumeRPC();
            //rpcConsume.Close();

            #endregion

            #region direct

            //Console.WriteLine("---------------Direct Consume!---------------");
            //DirectConsumer.Consume();

            #endregion

            #region Fanout

            //Console.WriteLine("---------------Fanout Consume!---------------");
            //FanoutConsumer.Consume();

            #endregion

            #region Fanout

            Console.WriteLine("---------------Topic Consume!---------------");
            TopicConsumer.Consume();

            #endregion
        }
    }
}
