using DataStructures.Trees;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    internal class SortedSet<T> : ISortedSet<T> where T : IComparable<T>
    {
        private LeftLeaningRedBlackTree<T> data;

        public IComparer<T> Comparer { get; private set; }

        public int Count => data.Count;

        public SortedSet(IComparer<T>? Comparer)
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
            throw new NotImplementedException();
        }

        public T Ceiling(T item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ISortedSet<T> Intersection(ISortedSet<T> other)
        {
            throw new NotImplementedException();
        }

        public T Max()
        {
            throw new NotImplementedException();
        }

        public T Min()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public ISortedSet<T> Union(ISortedSet<T> other)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
