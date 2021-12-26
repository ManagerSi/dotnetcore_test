﻿using System;
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

            Console.WriteLine("---------------Rpc!---------------");
            new RpcConsume().ConsumeRPC();

            #endregion
        }
    }
}
