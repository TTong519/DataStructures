using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class SkipListNode<T> where T : IComparable<T>
    {
        public List<T> Values = new List<T>();
        public SkipListNode<T> Next;
        public SkipListNode<T> Down;
        public bool isSentinel;
        public int Height { get; }

        public SkipListNode(T Value, bool isSentinel = false)
        {
            Values.Add(Value);
            this.isSentinel = isSentinel;
        }
        public SkipListNode(List<T> Values, SkipListNode<T> down,int height, bool isSentinel = false)
        {
            this.Values = Values;
            Down = down;
            this.isSentinel = isSentinel;
        }
    }
}
