using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Leetcode.Problems.MutiThread
{
    /// <summary>
    /// semaphoreslim
    /// </summary>
    class print_foobar_alternately
    {
        private System.Threading.SemaphoreSlim slim1 =new System.Threading.SemaphoreSlim(1);
        private System.Threading.SemaphoreSlim slim2 = new System.Threading.SemaphoreSlim(1);
        private int n;

        public print_foobar_alternately(int n)
        {
            this.n = n;
            slim2.Wait();
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {
                slim1.Wait();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();

                slim2.Release();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                slim2.Wait();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                slim1.Release();
            }
        }
    }

    /// <summary>
    /// 只有两个线程之间的同步用AutoResetEvent或者ManualResetEvent很方便
    /// </summary>
    class print_foobar_alternately_V2
    {
        private System.Threading.AutoResetEvent slim1 = new System.Threading.AutoResetEvent(false);
        private System.Threading.AutoResetEvent slim2 = new System.Threading.AutoResetEvent(false);
        private int n;

        public print_foobar_alternately_V2(int n)
        {
            this.n = n;
            slim1.Set();
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                slim1.WaitOne();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();

                slim2.Set();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                slim2.WaitOne();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                slim1.Set();
            }
        }
    }


    /// <summary>
    /// sleep
    /// </summary>
    class print_foobar_alternately_V3
    {
        private int n;
        private int next = 1;

        public print_foobar_alternately_V3(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                while (next!=1)
                {
                    System.Threading.Thread.Sleep(0);
                }

                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();

                next = 2;
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                while (next != 2)
                {
                    System.Threading.Thread.Sleep(0);
                }

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                next = 1;
            }
        }
    }


    /// <summary>
    /// Thread.SpinWait --timeout
    /// </summary>
    class print_foobar_alternately_V4
    {
        private int n;
        private int next = 1;

        public print_foobar_alternately_V4(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                while (next != 1)
                {
                    System.Threading.Thread.SpinWait(0);
                }

                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();

                next = 2;
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                while (next != 2)
                {
                    System.Threading.Thread.SpinWait(0);
                }

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                next = 1;
            }
        }
    }



    /// <summary>
    /// lock---no work
    /// </summary>
    class print_foobar_alternately_V5
    {
        private int n;
        private static object _lock = new object();

        public print_foobar_alternately_V5(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                lock (_lock)
                {
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();

                }

            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                lock (_lock)
                {
                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();

                }

            }
        }
    }


    /// <summary>
    /// monitor -- 同lock
    /// </summary>
    class print_foobar_alternately_V6
    {
        private int n;
        private object _lock1 = new object();
        private object _lock2 = new object();

        public print_foobar_alternately_V6(int n)
        {
            this.n = n;
            Monitor.Enter(_lock2);
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                Monitor.Wait(_lock1);
                Monitor.Enter(_lock2);
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();

                Monitor.Exit(_lock2);

            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                Monitor.Wait(_lock2);

                Monitor.Enter(_lock1);
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                Monitor.Exit(_lock1);

            }
        }
    }


    /// <summary>
    /// readwritelock -- no work-- error
    /// </summary>
    class print_foobar_alternately_V7
    {
        private int n;
        private ReaderWriterLock rwl1;
        private ReaderWriterLock rwl2;

        public print_foobar_alternately_V7(int n)
        {
            this.n = n;
            rwl1 = new ReaderWriterLock();
            rwl2 = new ReaderWriterLock();

            rwl2.AcquireWriterLock(Timeout.Infinite);
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                rwl1.AcquireWriterLock(Timeout.Infinite);
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                rwl2.ReleaseWriterLock();

            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                rwl2.AcquireWriterLock(Timeout.Infinite);
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                rwl1.ReleaseWriterLock();

            }
        }
    }



}
