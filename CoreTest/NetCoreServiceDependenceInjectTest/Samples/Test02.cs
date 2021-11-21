using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreServiceDependencyInjectionTest.Samples
{
    public class Test02
    {
        public static void Run()
        {
            using (var root = new ServiceCollection()
                .AddTransient<IAccount,Account>()
                .AddScoped<ITool,Tool>()
                .AddTransient<IMessage,Message>()
                .AddTransient<IArticle,Article>()
                .BuildServiceProvider())
            {
                var message = root.GetService<IMessage>();//使用入参最多的那个构造方法
                var message2 = root.GetRequiredService<IMessage>(); //GetRequiredService --> GetService

                try
                {
                    var article = root.GetService<IArticle>();//构造参数没有优先级，所以数量一致的话，不知选哪个，报错
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }



        public interface IAccount { }
        public interface IMessage { }
        public interface ITool { }
        public interface IArticle { }

        public class Base : IDisposable
        {
            public Base() { Console.WriteLine($"Base create:{GetType().Name}"); }
            /// <summary>
            /// virtual 子类可以覆写
            /// </summary>
            public virtual void Dispose() { Console.WriteLine($"Base Dispose:{GetType().Name}"); }
        }

        public class Account : Base, IAccount
        {
            public Account() { Console.WriteLine($"child create:{GetType().Name}"); }
            /// <summary>
            /// override 覆写
            /// </summary>
            public override void Dispose() { Console.WriteLine($"child Dispose:{GetType().Name}"); }
        }
    
        public class Tool : Base, ITool
        {
            public Tool() { Console.WriteLine($"child create:{GetType().Name}"); }
            public new void Dispose() { Console.WriteLine($"child Dispose:{GetType().Name}"); }
        }
        public class Message : Base, IMessage
        {
            public Message(IAccount account) { Console.WriteLine($"child create by:{account.GetType().Name}"); }
            public Message(ITool tool) { Console.WriteLine($"child create:{tool.GetType().Name}"); }
            public Message(IAccount account,ITool tool) { Console.WriteLine($"child create:{account.GetType().Name},{tool.GetType().Name}"); }
            /// <summary>
            /// new 无法覆写
            /// </summary>
            public new void Dispose() { Console.WriteLine($"child Dispose:{GetType().Name}"); }
        }
        public class Article : Base, IArticle
        {
            public Article(IAccount account, ITool tool) { Console.WriteLine($"child create:{account.GetType().Name},{tool.GetType().Name}"); }
            public Article(IAccount account, IMessage message) { Console.WriteLine($"child create:{account.GetType().Name},{message.GetType().Name}"); }
            /// <summary>
            /// new 无法覆写
            /// </summary>
            public new void Dispose() { Console.WriteLine($"child Dispose:{GetType().Name}"); }
        }
    }

}
