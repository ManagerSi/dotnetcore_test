using System;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreServiceDependencyInjectionTest.Samples
{
    public class Test01
    {
        public static void Run()
        {
            //namespace: Microsoft.Extensions.DependencyInjection
            using (var root = new ServiceCollection()
                .AddTransient<IMessage, Message>()  //瞬时，每次都新建
                .AddScoped<IAccount, Account>()     //作用域
                .AddSingleton<ITool, Tool>()        //单例
                .BuildServiceProvider())
            {
                Console.WriteLine("-------------root Scope--------------");
                {
                    var account = root.GetService<IAccount>();  //创建
                    var message = root.GetService<IMessage>();  //创建
                    var tool = root.GetService<ITool>();        //创建
                }

                //子作用域
                using (var childScope = root.CreateScope()) //申请子作用域
                {
                    var child = childScope.ServiceProvider;
                    Console.WriteLine("-------------child Scope, create first-------------");
                    {
                        var message = child.GetService<IMessage>();  //创建新的，单次用完释放
                        var account = child.GetService<IAccount>();  //使用child作用域的，所用域内不释放
                        var tool = child.GetService<ITool>();        //使用root的对象，root作用域内不释放

                    }
                    Console.WriteLine("-------------child Scope, create second-------------");
                    {
                        var message = child.GetService<IMessage>();  //创建新的
                        var account = child.GetService<IAccount>();  //使用child作用域的，
                        var tool = child.GetService<ITool>();        //使用root的对象

                    }
                    Console.WriteLine("-------------child Scope, disposed-------------");
                }
                Console.WriteLine("-------------root Scope, disposed-------------");
            }
        }


        public interface IAccount { }
        public interface IMessage { }
        public interface ITool { }

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
        public class Message : Base, IMessage
        {
            public Message() { Console.WriteLine($"child create:{GetType().Name}"); }
            /// <summary>
            /// new 无法覆写
            /// </summary>
            public new void Dispose() { Console.WriteLine($"child Dispose:{GetType().Name}"); }
        }
        public class Tool : Base, ITool
        {
            public Tool() { Console.WriteLine($"child create:{GetType().Name}"); }
            public new void Dispose() { Console.WriteLine($"child Dispose:{GetType().Name}"); }
        }
    }

}
