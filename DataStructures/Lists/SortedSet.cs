using DataStructures.Trees;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class SortedSet<T> : ISortedSet<T> where T : IComparable<T>
    {
        private LeftLeaningRedBlackTree<T> data;

        public IComparer<T> Comparer { get; private set; }

        public int Count => data.Count;

        public SortedSet(IComparer<T>? Comparer = null)
        {
            this.Comparer = Comparer ?? Comparer<T>.Default;
            data = new();
        }

        public bool Add(T item)
        {
            data.Insert(item);
            return true;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                Add(item);
            }
        }

        public T Ceiling(T item)
        {
            List<T> list = new List<T>();
            list = data.toList();
            list.Add(item);
            list.Sort(Comparer);
            int index = list.IndexOf(item);
            if (index < list.Count - 1) return list[index + 1];
            return default(T);
        }

        public void Clear()
        {
            data = new();
        }

        public bool Contains(T item)
        {
            return data.Contains(item);
        }

        public T Floor(T item)
        {
            List<T> list = new List<T>();
            list = data.toList();
            list.Add(item);
            list.Sort(Comparer);
            int index = list.IndexOf(item);
            if (index > 0) return list[index - 1];
            return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> dataList = data.toList();
            return dataList.GetEnumerator();
        }

        public ISortedSet<T> Intersection(ISortedSet<T> other)
        {
            SortedSet<T> result = new SortedSet<T>(Comparer);
            foreach (var item in this)
            {
                if (other.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public T Max()
        {
            return data.toList().Max();
        }

        public T Min()
        {
            return data.toList().Min();
        }

        public bool Remove(T item)
        {
            return data.Remove(item);
        }

        public ISortedSet<T> Union(ISortedSet<T> other)
        {
            SortedSet<T> result = new SortedSet<T>(Comparer);
            foreach (var item in this)
            {
                result.Add(item);
            }
            foreach (var item in other)
            {
                if (result.Contains(item)) continue;
                result.Add(item);
            }
            return result;
        }

        public List<T> ToList()
        {
            return data.toList();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
