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
            _array = new T[]();
            _size = 0;
        }

        public MyArray(int length)
        {
            _array = new T[length]();
            _size = length;
        }

        public int Length
        {
            get { return _leanth;}
            private set;
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


    }
}
