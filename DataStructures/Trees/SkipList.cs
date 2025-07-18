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
                newNode = new SkipListNode<T>(node.Values, node);
                if (height == HeadHeight)
                {
                    HeadTop = new SkipListNode<T>(HeadTop.Values, HeadTop);
                    HeadHeight++;
                    return newNode;
                }
                RandomHeight(newNode, height + 1);
            }
            if (newNode == null) return node;
            return newNode;
        }
        private void InsertRecursive(T value, SkipListNode<T> current)
        {
            if (current.Next.Values[0].CompareTo(value) > 0)
            {
                if (current.Down == null)
                {
                    // Insert at the current level
                    SkipListNode<T> newNode = RandomHeight(new SkipListNode<T>(value));
                    newNode.Next = current.Next;
                    current.Next = newNode;
                }
                else
                {
                    InsertRecursive(value, current.Down);
                }
            }
            else if (current.Next.Values[0].CompareTo(value) == 0)
            {
                current.Values.Add(value);
                return;
            }
            else
            {
                InsertRecursive(value, current.Next);
            }
        }
        public void Insert(T value)
        {
            if (HeadTop == null)
            {
                HeadTop = new SkipListNode<T>(new List<T> { value });
                HeadHeight = 1;
                return;
            }
            if (HeadTop.Values[0].CompareTo(value) > 0)
            {
                SkipListNode<T> newNode = RandomHeight(new SkipListNode<T>(new List<T> { value }));
                newNode.Next = HeadTop;
                HeadTop = newNode;
                return;
            }
            InsertRecursive(value, HeadTop);
        }
    }
}
