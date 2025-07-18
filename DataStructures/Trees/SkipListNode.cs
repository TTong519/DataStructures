using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue.Trees
{
    public class SkipListNode<T> where T : IComparable<T>
    {
        public List<T> Values;
        public SkipListNode<T> Next;
        public SkipListNode<T> Down;
        public int Height { get; }

        public SkipListNode(List<T> Values)
        {
            this.Values = Values;
        }
        public SkipListNode(List<T> Values, SkipListNode<T> down)
        {
            this.Values = Values;
            Down = down;
        }
    }
}
