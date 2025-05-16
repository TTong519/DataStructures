using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class HeapTree<T> where T : IComparable<T>
    {
        private T[] data;
        public T Root { get { return data[0]; } }
        public int Count { get; private set; }
        public int Capacity { get { return data.Length; } }
        public HeapTree()
        {
            data = new T[10];
            Count = 0;
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
        private void HeapifyDown(int index)
        {
            int leftIndex = 2 * index + 1;
            int rightIndex = 2 * index + 2;
            bool left = false;
            bool right = false;
            if (leftIndex > Count)
            {
                left = true;
            }
            if (rightIndex > Count)
            {
                right = true;
            }
            if (left && right)
            {
                return;
            }
            else if (left)
            {
                T temp = data[index];
                data[index] = data[rightIndex];
                data[rightIndex] = temp;
                HeapifyDown(rightIndex);
            }
            else if (right)
            {
                T temp = data[index];
                data[index] = data[leftIndex];
                data[leftIndex] = temp;
                HeapifyDown(leftIndex);
            }
            else
            {
                if (data[leftIndex].CompareTo(data[rightIndex]) > 0)
                {
                    T temp = data[index];
                    data[index] = data[leftIndex];
                    data[leftIndex] = temp;
                    HeapifyDown(leftIndex);
                }
                else
                {
                    T temp = data[index];
                    data[index] = data[rightIndex];
                    data[rightIndex] = temp;
                    HeapifyDown(rightIndex);
                }
            }
        }
        public void Add(T item)
        {
            if(Count == Capacity)
            {
                T[] data2 = new T[Capacity*2];
                for (int i = 0; i < Capacity; i++)
                {
                    data2[i] = data[i];
                }
                data = data2;
            }
            data[Count] = item;
            HeapifyUp(Count);
            Count++;
        }
        public T Pop()
        {
            T toReturn = Root;
            data[0] = data[Count - 1];
            data[Count - 1] = default;
            Count--;
            HeapifyDown(0);
            return toReturn;
        }
    }
}
