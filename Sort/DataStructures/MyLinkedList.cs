using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public sealed class MyLinkedListNode<T>
    {
        public T Data { get; set; }
        public MyLinkedListNode<T> Prev { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
    }

    /// <summary>
    /// https://mp.weixin.qq.com/s?__biz=MzA4NDE4MzY2MA==&mid=2647520238&idx=1&sn=caa8b3344610484cfbc7bce5dfbd200c&chksm=87d24cedb0a5c5fbf4a27e23421fd83a71d859e906aa1061b07c827ea93e744111913e35851e&scene=178#rd
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyLinkedList<T>
    {
        /// <summary>
        /// check the struct by ILSpy
        /// </summary>
        private LinkedList<T> h;


        internal MyLinkedListNode<T> head =new MyLinkedListNode<T>();
        

        #region 单链表常规操作

        public T GetElem(int index)
        {
            var tempH = head.Next;
            int i = 1;
            while (i < index && tempH != null)
            {
                i++;
                tempH = tempH.Next;
            }

            if(tempH == null)
                throw new IndexOutOfRangeException("超出长度");

            return tempH.Data;
        }

        public void InsertElem(int index, T data)
        {
            var tempH = head;
            int i = 1;
            while (i < index && tempH != null)
            {
                i++;
                tempH = tempH.Next;
            }

            if (tempH == null)
                throw new IndexOutOfRangeException("超出长度");

            var node = new MyLinkedListNode<T>(){Data = data};
            node.Next = tempH.Next;
            tempH.Next = node;
        }


        public T DeleteElem(int index)
        {
            var tempH = head;
            int i = 1;
            while (i < index && tempH != null)
            {
                i++;
                tempH = tempH.Next;
            }

            if (tempH == null)
                throw new IndexOutOfRangeException("超出长度");

            var node = tempH.Next;
            tempH.Next = node.Next;
            
            return node.Data;
        }

        /// <summary>
        /// 头插法
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public void AddFromHead(T data)
        {
           if(head == null)
               head = new MyLinkedListNode<T>();

           var node = new MyLinkedListNode<T>(){Data = data};
           node.Next = head.Next;
           head.Next = node;
        }

        /// <summary>
        /// 头插法
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public void AddFromTail(T data)
        {
            var node = new MyLinkedListNode<T>() { Data = data };

            if (head == null)
            {
                head = new MyLinkedListNode<T>
                {
                    Next = node
                };
            }
            else
            {
                var temp = head;
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = node;
            }
        }
        #endregion 单链表常规操作
    }
}
