using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue.Trees
{
    public class MinHeapTree<T> where T : IComparable<T>
    {
        private T[] data;
        public int Count { get; private set; }
        public int Size { get; private set; }
        public MinHeapTree()
        {
            data = new T[10];
            Count = 0;
            Size = 10;
        }
        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            if (data[index].CompareTo(data[(index-1)/2]) < 0)
            {
                T temp = data[(index-1)/2];
                data[(index-1)/2] = data[index];
                data[index] = temp;
                HeapifyUp((index-1)/2);
            }
        }
        public void Add(T item)
        {
            if(Count == Size)
            {
                T[] data2 = new T[Size*2];
                for (int i = 0; i < Size; i++)
                {
                    data2[i] = data[i];
                }
                data = data2;
                Size = Size*2;
            }
            data[Count] = item;
            HeapifyUp(Count);
            Count++;
        }
        public T Peek()
        { 
            return data[Count-1];
        }
    }
}
