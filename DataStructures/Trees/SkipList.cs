using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue.Trees
{
    public class SkipList<T> where T : IComparable<T>
    {
        public SkipListNode<T> HeadTop;
        public int HeadHeight;
        public SkipList()
        {
            HeadTop = null;
            HeadHeight = 0;
        }
        private SkipListNode<T> RandomHeight(SkipListNode<T> node, int height = 0)
        {
            SkipListNode<T> newNode = null;
            Random random = new Random();
            if (random.Next(0, 2) == 1 && height < HeadHeight + 1)
            {
                newNode = new SkipListNode<T>(node.Value, node);
                if (height == HeadHeight)
                {
                    HeadTop = new SkipListNode<T>(HeadTop.Value, HeadTop);
                    HeadHeight++;
                    return newNode;
                }
                RandomHeight(newNode, height + 1);
            }
            if (newNode == null) return node;
            return newNode;
        }
        public void Insert(T value)
        {

        }
    }
}
