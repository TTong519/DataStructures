using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class SkipList<T> : ICollection<T> where T : IComparable<T>
    {
        public SkipListNode<T> HeadTop;

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

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
                if (!current.isSentinel && current.Values[0].CompareTo(value) == 0)
                {
                    current.Values.Add(value);
                }
                else if (current.Height <= height)
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
        public bool RemoveRecursive(T value, SkipListNode<T> current)
        {
            if (current == null)
            {
                return false;
            }
            if(current.Next == null || current.Next.Values[0].CompareTo(value) > 0)
            {
                return RemoveRecursive(value, current.Down);
            }
            else if(current.Next.Values[0].CompareTo(value) == 0)
            {
                if (current.Next.Values.Count > 1)
                {
                    bool toReturn = false;
                    toReturn = current.Next.Values.Remove(value);
                    RemoveRecursive(value, current.Down);
                    return toReturn;
                }
                else
                {
                    if (current.Next.Values.Contains(value))
                    {
                        current.Next = current.Next.Next;
                        if (current.Down != null)
                        {
                            RemoveRecursive(value, current.Down);
                        }
                        return true;
                    }
                    return false;
                }
            }
            else
            {
                return RemoveRecursive(value, current.Next);
            }
        }
        public bool Remove(T value)
        {
            return RemoveRecursive(value, HeadTop);
        }
        public bool Contains(T value)
        {
            SkipListNode<T> current = HeadTop;
            while (current != null)
            {
                if (current.Next == null || current.Next.Values[0].CompareTo(value) > 0)
                {
                    current = current.Down;
                }
                else if (current.Next.Values[0].CompareTo(value) == 0)
                {
                    return true;
                }
                else
                {
                    current = current.Next;
                }
            }
            return false;
        }

        public void Add(T item)
        {
            Insert(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            SkipListNode<T> current = HeadTop;

            for (int i = 0; i < 10; i++)
            {
                current = current.Next;

                yield return current.Values[0];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
