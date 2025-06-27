using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue.Trees
{
    internal class SkipListNode<T> where T : IComparable<T>
    {
        public T Value;
        public SkipListNode<T> Next;
        public SkipListNode<T> Down;
        public int Height { get; }

        public SkipListNode(T value)
        {
            Value = value;
        }
        public SkipListNode(T value, SkipListNode<T> down)
        {
            Value = value;
            Down = down;
        }
    }
}
