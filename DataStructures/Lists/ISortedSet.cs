using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public interface ISortedSet<T> : IEnumerable<T>
    {
        IComparer<T> Comparer { get; }
        int Count { get; }
        void Clear();
        bool Add(T item);
        void AddRange(IEnumerable<T> items);
        bool Contains(T item);
        bool Remove(T item);
        T Max();
        T Min();
        T Ceiling(T item);
        T Floor(T item);
        ISortedSet<T> Union(ISortedSet<T> other);
        ISortedSet<T> Intersection(ISortedSet<T> other);
    }
}
