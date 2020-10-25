using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructures
{
    public interface IMyQueue<T>
    {
        void Clear();

        void Enqueue(T item);

        T Dequeue();

        T Peek();

        bool Contains(T item);

        T GetElement(int i);
    }

    /// <summary>
    /// 单链表结构与顺序存储结构优缺点分析
    /// 
    /// 我们分别从存储分配方式、时间性能、空间性能三方面来做对比。
    /// 
    /// 存储分配方式：
    /// 
    /// 顺序存储结构用一段连续的存储单元依次存储线性表的数据元素。
    /// 
    /// 单链表采用链式存储结构，用一组任意的存储单元存放线性表的元素。
    /// 
    /// 时间性能：
    /// 
    /// 顺序存储结构需要平均移动表长一半的元素，时间为O(n)
    /// 
    /// 单链表在计算出某位置的指针后，插入和删除时间仅为O(1)
    /// 
    /// 顺序存储结构O(1)
    /// 
    /// 单链表O(n)
    /// 
    /// 查找
    /// 
    /// 插入和删除
    /// 
    /// 空间性能：
    /// 
    /// 顺序存储结构需要预分配存储空间，分大了，容易造成空间浪费，分小了，容易发生溢出。
    /// 
    /// 单链表不需要分配存储空间，只要有就可以分配，元素个数也不受限制。
    /// </summary>
    public class MyQueueNode<T> 
    {
        public T Data;
        public MyQueueNode<T> Next;
        public MyQueueNode(T value)
        {
            Data = value;
        }
    }

    public class MyQueueWithNode<T>: IMyQueue<T>
    {
        private int _size { get; set; }
        private MyQueueNode<T> _head { get; set; } //头节点不含数据

        public MyQueueWithNode()
        {
            _head=new MyQueueNode<T>(default(T));
            _size = 0;
        }

        public override string ToString()
        {
            if(_size==0)
                return String.Empty;
            var tempH = _head.Next;
            StringBuilder sb = new StringBuilder();
            while (tempH!=null)
            {
                sb.Append(tempH.Data?.ToString());
                sb.Append(",");

                tempH = tempH.Next;
            }

            return sb.ToString(0, sb.Length - 1);
        }

        public void Clear()
        {
            var tempH = _head.Next;
            _head.Next = null;
            _size = 0;

            while (tempH != null)
            {
                var temp = tempH;
                tempH = tempH.Next;

                temp.Data = default(T);
                temp.Next = null;
            }

        }

        public void Enqueue(T item)
        {
            var tempH = _head;
            while (tempH.Next != null)
                tempH = tempH.Next;

            tempH.Next = new MyQueueNode<T>(item);
            _size++;
        }

        public T Dequeue()
        {
            if(_size==0)
                throw new InvalidOperationException("queue is empty");

            var temp = _head.Next;
            _head.Next = temp.Next;
            _size--;

            var date = temp.Data;
            temp.Next = null;
            temp = null;

            return date;
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("queue is empty");
            
            return _head.Next.Data;
        }

        public bool Contains(T item)
        {
            if (_size == 0)
                return false;

            var match = EqualityComparer<T>.Default;
            var tempH = _head.Next;
            while (tempH!=null)
            {
                if (item == null && tempH.Data == null)
                    return true;
                if (match.Equals(item, tempH.Data))
                    return true;

                tempH = tempH.Next;
            }

            return false;
        }

        public T GetElement(int i)
        {
            if (_size == 0)
                throw new InvalidOperationException("queue is empty");

            if(i>_size || i<=0)
                throw new ArgumentOutOfRangeException();

            var tempH = _head.Next;
            while (i-- > 0 && tempH!=null)
            {
                tempH = tempH.Next;
            }

            return tempH.Data;
        }
    }

    public class MyQueueWithArray<T>
    {
        private int _head { get; set; }
        private int _tail { get; set; }
        private int _size { get; set; }

        private T[] _array;
        private int _defaultCapacity =>50;

        public MyQueueWithArray(int capacity=0)
        {
            if(capacity==0)
                _array = new T[_defaultCapacity];
            else
                _array = new T[capacity];
        }

        public override string ToString()
        {
            if (_size == 0) return string.Empty;

            StringBuilder sb = new StringBuilder();
            var h = _head;
            var s = _size;
            while (s-- > 0)
            {
                sb.Append(_array[h].ToString());
                sb.Append(",");

                h = (h + 1) % _array.Length;
            }

            return sb.ToString(0, sb.Length - 1);
        }

        public void Clear()
        {
            if (_head < _tail)
            {
                Array.Clear(_array,_head,_size);
            }
            else
            {
                Array.Clear(_array, _head, _array.Length - _head);
                Array.Clear(_array, 0, _tail);
            }

            _head = 0;
            _tail = 0;
            _size = 0;
        }

        public void Enqueue(T item)
        {
            if(_size >= _array.Length)
                throw new OverflowException("超出数组范围");

            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0 || _head == _tail)
            {
                throw new InvalidOperationException("queue is empty");
            }

            T result = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            _size--;

            return result;
        }

        public T Peek()
        {
            if(_size==0)
                throw new InvalidOperationException("queue is empty");

            return _array[_head];
        }

        public bool Contains(T item)
        {
            if (_size == 0)
                return false;
            var compare = EqualityComparer<T>.Default;

            var head = _head;
            var size = _size;
            while (size-->0)
            {
                if (item == null && _array[head] == null)
                    return true;
                else if (compare.Equals(item, _array[head]))
                    return true;
                head = (head + 1) % _array.Length;
            }

            return false;
        }

        internal T GetElement(int i)
        {
            if (_size == 0)
                throw new InvalidOperationException("queue is empty");
            if(i<0 ||i>_size)
                throw new ArgumentOutOfRangeException("超出索引");

            return _array[(_head + i) % _array.Length];
        }

    }

}
