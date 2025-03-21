using DataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.StacksAndQueues
{
    public class ArrayBackedStack<T>
    {
        private GenericList<T> items;
        public int Count { get { return items.Count; } }
        public ArrayBackedStack(int capacity = 10)
        {
            items = new GenericList<T>(capacity);
        }
        public void Push(T value)
        {
            items.Add(value);
        }
        public T Pop() 
        {
            if (items.Count == 0) throw new InvalidOperationException("Stack is empty");

            T temp = items.GetIndex(items.Count - 1);
            items.Remove(temp);
            return temp;
        }
        public T Peek() 
        {
            T temp = items.GetIndex(items.Count - 1);
            return temp;
        }
        public void Clear() 
        {
            items.Clear();
        }
        public bool IsEmpty()
        {
            if(items.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
