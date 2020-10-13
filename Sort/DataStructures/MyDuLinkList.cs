using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MyDuLinkNode<T>
    {
        public MyDuLinkNode() { }
        public MyDuLinkNode(T data)
        {
            Data = data;
        }
        public T Data;
        public MyDuLinkNode<T> Prior { get; set; }
        public MyDuLinkNode<T> Next { get; set; }

    }

    /// <summary>
    /// 双向链表
    /// https://zh.wikipedia.org/wiki/%E5%8F%8C%E5%90%91%E9%93%BE%E8%A1%A8
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyDuLinkList<T>
    {
        private MyDuLinkNode<T> Head; //头节点不存数据, index of head = 0
        private int Length;

        public MyDuLinkList()
        {
            Head = new MyDuLinkNode<T>(); //头节点不存数据
            Head.Next = Head.Prior = Head;
            Length = 0;
        }

        public void DestroyList()
        {
            // 操作结果：销毁双向循环链表L
            MyDuLinkNode<T> q, p = Head.Next; // p指向第一个结点
            while (p != Head)
            {
                // p没到表头
                q = p.Next;
                free(p);
                p = q;
            }

            Length = 0;
            free(Head);
        }

        private void free(MyDuLinkNode<T> p)
        {
            p.Next = null;
            p.Prior = null;
            p.Data = default(T);
            p = null;
        }

        public void ClearList()
        {
            // 不改变L
            // 初始条件：L已存在。操作结果：将L重置为空表
            MyDuLinkNode<T> q, p = Head.Next;
            while (p != null)
            {
                q = p.Next;
                free(p);
                p = q;
            }

            Head.Next = Head.Prior = Head; //收尾均指向自身
            Length = 0;
        }

        public bool IsListEmpty()
        {
            // 初始条件：线性表L已存在。操作结果：若L为空表，则返回TRUE，否则返回FALSE
            return Head == Head.Next && Head == Head.Prior;
        }

        public int ListLength()
        {
            //return Length;

            var p = Head.Next;
            var count = 0;
            while (p != Head)
            {
                count++;
                p = p.Next;
            }

            return count;
        }

        public T GetElemData(int i)
        {
            var p = Head.Next;
            var count = 1;
            while (p != Head && count<i)
            {
                count++;
                p = p.Next;
            }

            if (count != i) throw new IndexOutOfRangeException("未找到");

            return p.Data;
        }

        public MyDuLinkNode<T> GetElem(int i)
        {
           if(i<0 || i>ListLength() )
               throw new IndexOutOfRangeException("未找到");

           var p = Head.Next;
           for (int j = 1; j < i; j++)
           {
               p = p.Next;
           }
           return p;
        }

        public int LocateElemIndex(T data)
        {
            var p = Head.Next;
            var index = 1;
            while (p!=Head)
            {
                if (p.Data.Equals(data))
                    return index;

                index++;
                p = p.Next;
            }

            return -1;
        }

        public T PriorElemData(T cur_data)
        {
            var p = Head.Next;
            while (p != Head)
            {
                if (p.Data.Equals(cur_data))
                {
                    if (p.Prior == Head)
                        return default(T);
                    else
                        return p.Prior.Data;
                }

                p = p.Next;
            }

            return default(T);
        }

        public T NextElemData(T cur_data)
        {
            var p = Head.Next;
            while (p != Head)
            {
                if (p.Data.Equals(cur_data))
                {
                    if (p.Next == Head)
                        return default(T);
                    else
                        return p.Next.Data;
                }

                p = p.Next;
            }

            return default(T);
        }

        public MyDuLinkNode<T> ListInsert(int i, T data)
        {
            if (i < 0 || i > ListLength()+1)
                throw new IndexOutOfRangeException("未找到");

            //获取前驱
            var p = GetElem(i - 1);
            var newNode = InternalInsert(p, data);
            return newNode;
        }

        private MyDuLinkNode<T> InternalInsert(MyDuLinkNode<T> p, T data)
        {
            var newNode = new MyDuLinkNode<T>(data);

            newNode.Next = p.Next;
            newNode.Prior = p;
            p.Next.Prior = newNode;
            p.Next = newNode;

            Length++;

            return newNode;
        }

        public void ListDelete(int i)
        {
            if (i <= 0 || i > ListLength() + 1)
                throw new IndexOutOfRangeException("未找到");

            //获取前驱
            var p = GetElem(i);

            p.Prior.Next = p.Next;
            p.Next.Prior = p.Prior;

            free(p);
        }

        public void AddFirst(T data)
        {
            InternalInsert(Head, data);
        }

        public void AddLast(T data)
        {
            InternalInsert(Head.Prior, data);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var p = Head.Next;
            while (p != Head)
            {
                sb.Append(p.Data);
                sb.Append(",");
                p = p.Next;
            }

            return sb.ToString(0, sb.Length - 1);
        }

    }
}
