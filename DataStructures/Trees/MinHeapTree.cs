using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue.Trees
{
    public class MinHeapTree<T> where T : IComparable<T>
    {
        T[] data;
        public int Count { get; private set; }
        public int Size { get; private set; }
        public MinHeapTree()
        {
            data = new T[10];
            Count = 0;
            Size = 10;
        }
        private void HeapifyUp( int index)
        {

        }
    }
}
