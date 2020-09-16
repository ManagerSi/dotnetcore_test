using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    /// <summary>
    /// ADT 线性表（List）
    /// Data
    /// 线性表的数据对象集合为{$a_1$,$a_2$,...,$a_n$},每个元素的类型均为DataType。其中，除第一个元素$a_1$外，每个元素有且只有一个直接前驱元素，除了最后一个元素$a_n$外，每一个元素有且只有一个直接后继元素。数据元素之间的关系是一对一的关系。
    /// Operation
    /// InitList(*L):初始化操作，建立一个空的线性表L.
    /// ListEmpty(L):判断线性表是否为空表，若线性表为空表，返回true，否则返回false
    /// ClearList(*L):将线性表清空。
    /// GetElem(L,i,*e):将线性表L中的第i个位置的元素返回给e。
    /// LocateElem(L,e):在线性表L中查找与给定值e相等的元素，如果查找成功，返回该元素在表中序号表示成功；否则，返回0表示失败。
    /// ListInsert(*L,i,e):在线性表L中第i个位置插入新元素e。
    /// ListDelete(*L,i,*e):删除线性表L中第i个位置元素，并用e返回其值。
    /// ListLength(L):返回线性表L的元素个数。
    /// endADT
    /// https://mp.weixin.qq.com/s/pAJdtJFiH3Gh_ca-MWF7xg
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyArray<T>
    {
        private const int _defaultSize = 20;
        private T[] _array { get; set; }

        /// <summary>
        /// 线性表的最大存储容量：数组的长度MAXSIZE
        /// </summary>
        private int _maxSize { get; set; }

        /// <summary>
        /// 线性表的当前长度：length
        /// </summary>
        private int _dataLength { get; set; }

        public MyArray()
        {
            _maxSize = _defaultSize;
            _array = new T[_maxSize];
        }

        public MyArray(int size)
        {
            _maxSize = size;
            _array = new T[_maxSize];
        }

        public int Length
        {
            get { return _dataLength;}
        }

        public bool IsEmpty()
        {
            return _dataLength == 0;
        }
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if(index<0 || index>=_dataLength)
                    throw new IndexOutOfRangeException("超出数组范围");
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _dataLength)
                    throw new IndexOutOfRangeException("超出数组范围"); 
                _array[index] = value;
            }
        }

        public int GetIndex(T data)
        {
            for (int i = 0; i < _dataLength; i++)
            {
                if (_array[i].Equals(data))
                    return i + 1;
            }

            return -1;
        }

        public void Add(T data)
        {
            if (_dataLength<_maxSize)
            {
                _array[_dataLength++] = data;
            }
            else
            {
                CapacityExpansion();

                _array[_dataLength++] = data;
            }
        }

        public void Insert(int index, T data)
        {
            if (index < 1 || index > _dataLength + 1)
                throw new IndexOutOfRangeException();
            if (_dataLength == _maxSize)
                CapacityExpansion();

            for (int i = _dataLength-1; i >= index-1; i--)
            {
                _array[i+1] = _array[i];
            }
            _array[index-1] = data;

            _dataLength++;
        }

        public void RemoveAt(int index)
        {
            if (_dataLength == 0)
                throw new OverflowException();
            if (index < 0 || index >= _dataLength)
                throw new IndexOutOfRangeException();

            _dataLength--;
            for (int i = index-1; i < _dataLength; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[_dataLength] = default(T);

        }

        public void Remove<T>(T data) where T : IComparable
        {
            for (int i = 0; i < _dataLength ; i++)
            {
                if (data.CompareTo(_array[i])==0)
                    RemoveAt(i);
            }
        }

        public void RemoveAll()
        {
            _maxSize = _defaultSize;
            _array=new T[_maxSize];
            _dataLength = 0;
        }

        public void Clear()
        {
            RemoveAll();
        }

        public override string ToString()
        {
            if (_dataLength > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(_array[0].ToString());
                for (int i = 1; i < _dataLength; i++)
                {
                    sb.Append(',');
                    sb.Append(_array[i].ToString());
                }

                return sb.ToString();
            }
            return String.Empty;
        }




        /// <summary>
        /// 扩容
        /// </summary>
        private void CapacityExpansion()
        {
            T[] tempArray = new T[_maxSize + _defaultSize];
            for (int i = 0; i < _maxSize; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = null;
            _array = tempArray;
            _maxSize += _defaultSize;

            tempArray = null;
        }



        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }



        public static void Clear(T[] array) { }

        public static int IndexOf(T[] array, T data)
        {
            //todo implation

            return 0;
        }
        public static int LastIndexOf(T[] array, T data)
        {
            //todo implation

            return 0;
        }
        public static T[] Copy(T[] array)
        {
            //todo implation

            return array;
        }

        public static T[] Reverse(T[] array)
        {
            //todo implation

            return array;
        }

        public static T[] QuickSort(T[] array)
        {
            //todo implation

            return array;
        }

        public static T[] BinarySort(T[] array)
        {
            //todo implation

            return array;
        }
    }
}
