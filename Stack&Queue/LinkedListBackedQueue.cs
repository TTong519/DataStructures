using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    class LinkedListBackedQueue<T>
    {
        public int Count { get { return data.Count; } }
        private SinglyLinkedList<T> data;
        public LinkedListBackedQueue(T value, T next)
        {
            data.AddFirst(next);
            data.AddLast(value);
        }
        public void Enqueue(T value)
        {
            data.AddLast(value);
        }
        public T Dequeue()
        {
            T toReturn;
            toReturn = data.Tail.Value;
            data.RemoveLast();
            return toReturn;
        }
        public T Peek()
        {
            return data.Tail.Value;
        }
        public void Clear()
        {
            data.Clear();
        }
        public bool IsEmpty()
        {
            if (data.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
