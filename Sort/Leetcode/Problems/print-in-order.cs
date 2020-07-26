using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1114. 按序打印
    /// https://leetcode-cn.com/problems/print-in-order/
    /// </summary>
    public class print_in_order
    {
        Action printF = () => Console.WriteLine("first");
        Action printS = () => Console.WriteLine("second");
        Action printT = () => Console.WriteLine("third");

        public void test()
        {
            var foo = new Foo();
            Action[] aList = new Action[]
            {
                () => foo.First(printF),
                () => foo.Second(printS),
                () => foo.Third(printT)
            };

            //生成随机数


            Task[] tList = new Task[3];
            for (int i = aList.Length - 1; i >= 0; i--)
            {
                tList[i] = Task.Run(aList[i]);
            };

            Task.WaitAll(tList);
            Console.WriteLine("finish");
        }
    }

    #region 两个变量控制,使用volatile关键字

    //public class Foo
    //{

    //    public Foo()
    //    {

    //    }

    //    private volatile bool flag1;
    //    private volatile bool flag2;

    //    public void First(Action printFirst)
    //    {

    //        // printFirst() outputs "first". Do not change or remove this line.
    //        printFirst();

    //        flag1 = true;

    //    }

    //    public void Second(Action printSecond)
    //    {
    //        while (!flag1)
    //        {
    //            Console.WriteLine("wait first!");
    //            System.Threading.Thread.Sleep(1);
    //        }

    //        // printSecond() outputs "second". Do not change or remove this line.
    //        printSecond();

    //        flag2 = true;
    //    }

    //    public void Third(Action printThird)
    //    {
    //        while (!flag2)
    //        {
    //            Console.WriteLine("wait second!");
    //            System.Threading.Thread.Sleep(1);
    //        }

    //        // printThird() outputs "third". Do not change or remove this line.
    //        printThird();

    //    }
    //}


    #endregion

    #region 一个变量控制， volatile(变量级别，非原子级别)

    //public class Foo
    //{

    //    public Foo()
    //    {

    //    }
    //    private volatile int step = 0;
    //    public void First(Action printFirst)
    //    {
    //        // printFirst() outputs "first". Do not change or remove this line.
    //        printFirst();
    //        step = 1;
    //    }

    //    public void Second(Action printSecond)
    //    {
    //        while (step != 1)
    //        {
    //            Console.WriteLine("wait first!");
    //            Thread.Sleep(1);
    //        }
    //        // printSecond() outputs "second". Do not change or remove this line.
    //        printSecond();
    //        step = 2;
    //    }

    //    public void Third(Action printThird)
    //    {
    //        while (step != 2)
    //        {
    //            Console.WriteLine("wait second!");
    //            Thread.Sleep(1);
    //        }
    //        // printThird() outputs "third". Do not change or remove this line.
    //        printThird();
    //    }
    //}

    #endregion

    #region 一个变量控制， System.Threading.Interlocked (原子级别)

    //public class Foo
    //{

    //    public Foo()
    //    {

    //    }
    //    private int step = 0;
    //    public void First(Action printFirst)
    //    {
    //        // printFirst() outputs "first". Do not change or remove this line.
    //        printFirst();

    //        //+1操作
    //        System.Threading.Interlocked.Increment(ref step);
    //    }

    //    public void Second(Action printSecond)
    //    {
    //        while (step != 1)
    //        {
    //            Console.WriteLine("wait first!");
    //            Thread.Sleep(1);
    //        }
    //        // printSecond() outputs "second". Do not change or remove this line.
    //        printSecond();

    //        //+1操作
    //        System.Threading.Interlocked.Increment(ref step);
    //    }

    //    public void Third(Action printThird)
    //    {
    //        while (step != 2)
    //        {
    //            Console.WriteLine("wait second!");
    //            Thread.Sleep(1);
    //        }
    //        // printThird() outputs "third". Do not change or remove this line.
    //        printThird();
    //    }
    //}

    #endregion

    #region  AutoResetEvent 
    ///// <summary>
    ///// 用lock和Monitor可以很好地起到线程同步的作用，但它们无法实现线程之间传递事件。如果要实现线程同步的同时，线程之间还要有交互，就要用到同步事件。同步事件是有两个状态（终止和非终止）的对象，它可以用来激活和挂起线程。
    ///// 同步事件有两种：AutoResetEvent和 ManualResetEvent。它们之间唯一不同的地方就是在激活线程之后，状态是否自动由终止变为非终止。AutoResetEvent自动变为非终止，就是说一个AutoResetEvent只能激活一个线程。而ManualResetEvent要等到它的Reset方法被调用，状态才变为非终止，在这之前，ManualResetEvent可以激活任意多个线程。
    ///// 
    ///// 可以调用WaitOne、WaitAny或WaitAll来使线程等待事件。它们之间的区别可以查看MSDN。当调用事件的 Set方法时，事件将变为终止状态，等待的线程被唤醒。
    ///// </summary>
    //public class Foo
    //{
    //    public Foo()
    //    {
    //        eventFirst = new System.Threading.AutoResetEvent(false); //参数false表示初始状态为非终止
    //        eventSecond = new System.Threading.AutoResetEvent(false);
    //    }
    //    private static System.Threading.AutoResetEvent eventFirst;
    //    private static System.Threading.AutoResetEvent eventSecond;

    //    public void First(Action printFirst)
    //    {
    //        // printFirst() outputs "first". Do not change or remove this line.
    //        printFirst();

    //        //释放锁F
    //        //如果是true的话，初始状态则为终止
    //        eventFirst.Set();
    //    }

    //    public void Second(Action printSecond)
    //    {
    //        eventFirst.WaitOne();

    //        // printSecond() outputs "second". Do not change or remove this line.
    //        printSecond();

    //        //释放锁S
    //        //如果是true的话，初始状态则为终止
    //        eventSecond.Set();
    //    }

    //    public void Third(Action printThird)
    //    {
    //        eventSecond.WaitOne();

    //        // printThird() outputs "third". Do not change or remove this line.
    //        printThird();
    //    }
    //}


    #endregion


    #region  SpinWait（自旋锁） 代替 sleep / Thread.VolatileWrite 代替 Interlocked

    //public class Foo
    //{
    //    //第二种方式，使用自旋锁
    //    private SpinWait _spinWait = new SpinWait();
    //    private int _continueCondition = 1;

    //    public Foo()
    //    {

    //    }
    //    public void First(Action printFirst)
    //    {
    //        printFirst();
    //        Thread.VolatileWrite(ref _continueCondition, 2);//写栅栏
    //    }

    //    public void Second(Action printSecond)
    //    {

    //        while (Thread.VolatileRead(ref _continueCondition) != 2)
    //        {
    //            Console.WriteLine("wait first! ");
    //            _spinWait.SpinOnce();
    //        }
    //        printSecond();
    //        Thread.VolatileWrite(ref _continueCondition, 3);//写栅栏
    //    }

    //    public void Third(Action printThird)
    //    {
    //        while (Thread.VolatileRead(ref _continueCondition) != 3)
    //        {
    //            Console.WriteLine("wait second! ");
    //            _spinWait.SpinOnce();
    //        }
    //        printThird();
    //        Thread.VolatileWrite(ref _continueCondition, 1);//写栅栏
    //    }

    //}


    #endregion


    #region 信号量 SemaphoreSlim

    /// <summary>
    ///
    /// 解题思路:使用信号量实现线程安全。
    /// SemaphoreSlim是FCL自带的线程同步混合构造，和其内核模式构造Semaphore完全一致。
    /// 信号量（Semaphore）其实就是由内核维护的Int32变量，当信号量为0的时候，
    /// 在信号量上等待的线程会阻塞；信号大于0的时候接触阻塞。
    /// 在信号量上等待的线程解除阻塞的时候，内核自动从信号量的计数中减1。
    /// 本题要在多线程中按顺序执行三个方法，故需要维护两个信号量，semaphoreSlim1和semaphoreSlim2。
    /// Second方法等待First执行后才可以执行，所以Second需要先调用semaphoreSlim1.Wait(),
    /// 当First执行完毕后才可以执行Second中的方法。同理，Third方法需要等待Second执行。
    /// </summary>
    public class Foo
    {
        //初始化，默认1个空间
        private SemaphoreSlim _semaphoreSlimFirst = new SemaphoreSlim(1);
        private SemaphoreSlim _semaphoreSlimSecond = new SemaphoreSlim(1);

        public Foo()
        {
            _semaphoreSlimFirst.Wait();//占用
            _semaphoreSlimSecond.Wait();//占用
        }
        public void First(Action printFirst)
        {
            printFirst();

            //调用Release方法后，CurrentCount会自增1
            _semaphoreSlimFirst.Release();//释放空间
        }

        public void Second(Action printSecond)
        {
            _semaphoreSlimFirst.Wait();//占用

            printSecond();

            //调用Release方法后，CurrentCount会自增1
            _semaphoreSlimSecond.Release();//释放空间
        }

        public void Third(Action printThird)
        {
            _semaphoreSlimSecond.Wait();//占用

            printThird();
        }

    }


    #endregion


    #region 无效-- System.Threading.Monitor控制（lock是其语法糖) / ReaderWriterLock
    /// <summary>
    /// 用lock和Monitor可以很好地起到线程同步的作用，但它们无法实现线程之间传递事件
    /// 允许同一进城中的线程实现同步  
    /// 不能在不同进程中使用，类的构造方法是主进程，first是子进程，无法使用monitor处理同一个对象
    /// 报错：System.Threading.SynchronizationLockException:“Object synchronization method was called from an unsynchronized block of code.”
    /// </summary>
    //public class Foo
    //{
    //    public Foo()
    //    {
    //        //加锁
    //        System.Threading.Monitor.Enter(_lockA);
    //        System.Threading.Monitor.Enter(_lockB);
    //    }
    //    private static object _lockA=new object();
    //    private static object _lockB = new object();

    //    public void First(Action printFirst)
    //    {
    //        // printFirst() outputs "first". Do not change or remove this line.
    //        printFirst();

    //        //释放锁
    //        System.Threading.Monitor.Exit(_lockA);
    //    }

    //    public void Second(Action printSecond)
    //    {
    //        while(!System.Threading.Monitor.Wait(_lockA))
    //        {
    //            Console.WriteLine("wait first!");
    //            System.Threading.Thread.Sleep(1);
    //        }
    //        // printSecond() outputs "second". Do not change or remove this line.
    //        printSecond();

    //        //释放锁
    //        System.Threading.Monitor.Exit(_lockB);
    //    }

    //    public void Third(Action printThird)
    //    {
    //        while (!System.Threading.Monitor.IsEntered(_lockB))
    //        {
    //            Console.WriteLine("wait second! ");
    //            System.Threading.Thread.Sleep(1);
    //        }

    //        // printThird() outputs "third". Do not change or remove this line.
    //        printThird();
    //    }
    //}


    #endregion

}
