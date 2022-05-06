using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SuperSocket;
using SuperSocket.Channel;

namespace SuperSocketHost
{
    public class SocketServerHelper
    {
        /// <summary>
        /// 使用自定义的数据包和过滤器创建的服务宿主
        /// </summary>
        private readonly ISuperSocketHostBuilder<Message>
            superSocket = SuperSocketHostBuilder.Create<Message, SocketFilter>();
                //SuperSocketHostBuilder.Create<Message>();

        /// <summary>
        /// 会话集合
        /// </summary>
        private static ConcurrentDictionary<string, IAppSession> _sessionDic = new ConcurrentDictionary<string, IAppSession>();

        /// <summary>
        /// 启动Socket服务(只须调用此方法即可启动)
        /// </summary>
        public void Start(int[] ports)
        {
            var listeners = new List<ListenOptions>();
            foreach (var port in ports)
            {
                listeners.Add(new ListenOptions() { Ip = "127.0.0.1", Port = port });
            }

            superSocket.ConfigureSuperSocket(options =>//配置服务器如服务器名和监听端口等基本信息
            {
                options.Name = "SocketServer";
                options.ReceiveBufferSize = 100000; //缓冲大小
                options.ReceiveBufferSize = 300000;//超时时间
                options.Listeners = listeners;//开启的端口
            });

            //会话连接和关闭的事件
            superSocket.UseSessionHandler(OnConnectedAsync, OnClosedAsync);

            //接收数据的事件
            superSocket.UsePackageHandler(OnPackageAsync);

            //开启socket
            //var t = Task.Run(() => superSocket.Build().Run());
            superSocket
                .ConfigureLogging(builder => builder.AddConsole())
                .Build()
                .RunAsync();
        }

        /// <summary>
        /// 关闭所有连接会话
        /// </summary>
        /// <returns></returns>
        public void StopServer()
        {
            foreach (var v in _sessionDic)
            {
                v.Value.CloseAsync(CloseReason.ServerShutdown);
            }
            _sessionDic.Clear();
        }

        /// <summary>
        /// 会话的连接事件
        /// </summary>
        /// <param name="session"></param>
        private ValueTask OnConnectedAsync(IAppSession session)
        {
            var t= Task.Run(() =>
            {
                while (!_sessionDic.ContainsKey(session.SessionID))
                {
                    //添加不成功则重复添加
                    if (!_sessionDic.TryAdd(session.SessionID, session))
                    {
                        Thread.Sleep(0);
                    }
                }

                Console.WriteLine($"会话 [{session.SessionID}] 已连接");
            });

            Task.WaitAll(t);

            return ValueTask.CompletedTask;
        }

        /// <summary>
        /// 会话的断开事件
        /// </summary>
        private async ValueTask OnClosedAsync(IAppSession session, CloseEventArgs arg2)
        {
            await Task.Run(() =>
            {
                while (_sessionDic.ContainsKey(session.SessionID))
                {
                    //移除不成功则重复移除
                    if (!_sessionDic.TryRemove(session.SessionID, out _))
                        Thread.Sleep(1);
                }
                Console.WriteLine($"会话 [{session.SessionID}] 已断开");
            });
        }

        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ValueTask OnPackageAsync(IAppSession session, Message msg)
        {
            Console.WriteLine($"[{session.SessionID}] - {JsonConvert.SerializeObject(msg)}");
            return ValueTask.CompletedTask;
        }
    }
}
