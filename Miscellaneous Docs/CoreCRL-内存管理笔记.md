## C#垃圾回收

参考连接：[.NET 垃圾回收 | Microsoft Docs](https://docs.microsoft.com/zh-cn/dotnet/standard/garbage-collection/)

### 垃圾回收基本知识

### 内存分配

初始化新进程时，运行时会为进程保留一个连续的地址空间区域。 这个保留的地址空间被称为托管堆。 托管堆维护着一个指针，用它指向将在堆中分配的下一个对象的地址。 最初，该指针设置为指向托管堆的基址。 托管堆上部署了所有引用类型。 应用程序创建第一个引用类型时，将为托管堆的基址中的类型分配内存。 应用程序创建下一个对象时，垃圾回收器在紧接第一个对象后面的地址空间内为它分配内存。 只要地址空间可用，垃圾回收器就会继续以这种方式为新对象分配空间。

从托管堆中分配内存要比非托管内存分配速度快。 由于运行时通过为指针添加值来为对象分配内存，所以这几乎和从堆栈中分配内存一样快。 另外，由于连续分配的新对象在托管堆中是连续存储，所以应用程序可以快速访问这些对象。

### 垃圾回收的条件

当满足以下条件之一时将发生垃圾回收：

- 系统具有低的物理内存。 这是通过 OS 的内存不足通知或主机指示的内存不足检测出来。
- 由托管堆上已分配的对象使用的内存超出了可接受的阈值。 随着进程的运行，此阈值会不断地进行调整。
- 调用 [GC.Collect](https://docs.microsoft.com/zh-cn/dotnet/api/system.gc.collect) 方法。 几乎在所有情况下，你都不必调用此方法，因为垃圾回收器会持续运行。 此方法主要用于特殊情况和测试。

#### CoreCRL 执行c#代码流程

> c#代码 ---编译--> IL ---编译--> 二进制码 ---执行--> 操作系统 ---调用--> 硬件

![image-20220301210708048](C:\Users\Sigen\AppData\Roaming\Typora\typora-user-images\image-20220301210708048.png)

其中从  IL 到 操作系统都是由CoreCRL管理

#### 对象的创建

对象会创建在托管堆上

对象使用完毕不会立即释放

#### **如何定位内存泄露**

> 步骤项目准备
>
> 1、创建内存溢出的项目
>
> dotnet-counters准备
> ​	1、先安装dotnet-counters   dotnet tool install --global dotnet-counters
> ​	2、然后找到进程编号   dotnet-counters ps
> ​	3、然后监视进程  dotnet-counters monitor --refresh-interval 1 -p 43332(进程编号)
> ​	4、最后查看显示统计信息   找到 GC Heap Size 。然后统计这个程序的增长，为了找出内存泄露的代码
> 
> dotnet-dump准备 
> ​	1、先安装dotnet-counters   dotnet tool install --global dotnet-dump
> ​	2、然后执行项目接口   https://localhost:5001/api/diagscenario/memleak/200002、然后生成转储文件(内存文件)   dotnet-dump collect -p 43332(进程编号)
> ​	3、然后分析转储文件  dotnet-dump analyze core_20190430_185145（转储文件名）  
> ​		3.1 开始分析      dumpheap -stat      找到内存比较大的类型，通过查看内存占用大小和对象数量  
> ​		3.2 然后分析类型具体对象     dumpheap -mt 00007faddaa50f90 为类型编号  
> ​		3.3 然后找出引用根(目的是找出在哪里被引用了)     gcroot -all 00007f6ad09421f8 对象编号

#### 解决内存泄漏的方法

```c#
            //解决内存泄露--WeakReference 虚引用
            //WeakReference weakReference = new WeakReference();
            //weakReference.Target(new Customer(Guid.NewGuid().ToString()));
```

