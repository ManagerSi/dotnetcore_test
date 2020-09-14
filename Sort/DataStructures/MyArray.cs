using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MyArray<T>
    {
        private T[] _array { get; set; }
        private int _size { get; set; }

        public MyArray()
        {
            _size = 0;
            _array = new T[_size];
        }

        public MyArray(int length)
        {
            _array = new T[length];
            _size = length;
        }

        public int Length
        {
            get { return _size;}
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        public void Add(T data)
        {
            T[] tempArray = new T[_size+1];
            for (int i = 0; i < _size; i++)
            {
                tempArray[i] = _array[i];
            }
            tempArray[_size] = data;

            _array = null;
            _array = tempArray;
            _size++;

            tempArray = null;
        }

        public void Insert(int index, T data)
        {
            if (index >= _size)
                Add(data);
            else
            {

                T[] tempArray = new T[_size + 1];
                for (int i = 0; i < index; i++)
                {
                    tempArray[i] = _array[i];
                }
                tempArray[index] = data;
                for (int i = index+1; i <= _size; i++)
                {
                    tempArray[i] = _array[i-1];
                }

                _array = null;
                _array = tempArray;
                _size++;

                tempArray = null;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
                return;

            _size--;
            for (int i = index; i < _size; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[_size] = default(T);

        }

        public void Remove<T>(T data) where T : IComparable
        {
            for (int i = 0; i < _size ; i++)
            {
                if (data.CompareTo(_array[i])==0)
                    RemoveAt(i);
            }
        }

        public void RemoveAll()
        {
            _size = 0;
            _array=new T[_size];
        }

        public override string ToString()
        {
            if(_size>0)
                return string.Join(',',_array);
            return String.Empty;
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
