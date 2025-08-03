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

        public int Count => count;
        private int count;
        public bool IsReadOnly => true;

        public SkipList()
        {
            HeadTop = new SkipListNode<T>(default, null, 1, true);
            count = 0;
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
                    if(current.Height == 1)
                    {
                        count++;
                    }
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
            if (current.Next == null || current.Next.Values[0].CompareTo(value) > 0)
            {
                return RemoveRecursive(value, current.Down);
            }
            else if (current.Next.Values[0].CompareTo(value) == 0)
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
                        if(current.Height == 1)
                        {
                            count--;
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
            HeadTop = new SkipListNode<T>(default, null, 1, true);
            count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex = 0)
        {
            SkipListNode<T> current = HeadTop;
            while (current.Down != null)
            {
                current = current.Down;
            }
            current = current.Next;
            for (int i = 0;i < arrayIndex; i++)
            {
                if (current.Next == null) break;
                current = current.Next;
            }
            int j = 0;
            while (current != null)
            {
                foreach (var value in current.Values)
                {
                    if (j >= array.Length) break;
                    array[j] = value;
                    j++;
                }
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            SkipListNode<T> current = HeadTop;
            while (current.Down != null)
            {
                current = current.Down;
            }
            while (current.Next != null)
            {
                current = current.Next;
                foreach (var value in current.Values)
                {
                    yield return value;
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
