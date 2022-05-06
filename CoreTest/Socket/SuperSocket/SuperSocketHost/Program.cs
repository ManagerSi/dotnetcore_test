// See https://aka.ms/new-console-template for more information

using System;
using SuperSocketHost;

Console.WriteLine("Hello, World!");

SocketServerHelper socketServerHelp = new SocketServerHelper();
socketServerHelp.Start(new int[] { 4567, 5678 });
Console.WriteLine("SocketServeer已开启");
Console.WriteLine("输入任意内容结结束");
Console.ReadLine();