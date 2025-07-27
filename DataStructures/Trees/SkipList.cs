using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class SkipList<T> where T : IComparable<T>
    {
        public SkipListNode<T> HeadTop;

        public SkipList()
        {
            HeadTop = new SkipListNode<T>(default, null, 1, true);
        }
        private int RandomHeight()
        {
            int height = 1;

            while (new Random().Next(2) == 0 && height <= HeadTop.Height)
            {
                height++;
                if (height > HeadTop.Height)
                {
                    HeadTop = new SkipListNode<T>(default, HeadTop, height, true);
                }
            }

            return height;

        }
        private SkipListNode<T> InsertRecursive(T value, SkipListNode<T> current, int height)
        {
            if (current == null)
            {
                return null;
            }
            if (current.Next == null || current.Next.Values[0].CompareTo(value) > 0)
            {
                var temp = InsertRecursive(value, current.Down, height);
                var newNode = new SkipListNode<T>(new([value]), temp, current.Height);
                if (current.Height >= height)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                }
                return newNode;
            }
            else
            {
                var temp = InsertRecursive(value, current.Next, height);
                return temp;
            }
        }
        public void Insert(T value)
        {
            InsertRecursive(value, HeadTop, RandomHeight());
        }
    }
}
