using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataStructures.Lists
{
    public class HashMap<Tkey, Tval> : IDictionary<Tkey, Tval>
    {
        public Tval this[Tkey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Tkey> Keys => throw new NotImplementedException();
        public ICollection<Tval> Values => throw new NotImplementedException();
        private LinkedList<KeyValuePair<Tkey, Tval>>[] storage = new LinkedList<KeyValuePair<Tkey, Tval>>[50];

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();
        public IEqualityComparer<Tkey> Comparer { get; private set; }

        public HashMap() : this(EqualityComparer<Tkey>.Default) { }
        public HashMap(IEqualityComparer<Tkey> comparer)
        {
            Comparer = comparer;
            Count = 0;
        }

        public void Add(Tkey key, Tval value)
        {
            //TODO: Rehash
            if (Count + 1 > storage.Length)
            {
                throw new NotImplementedException();
            }
            int hash = Comparer.GetHashCode(key);
            int index = Math.Abs(hash % storage.Length);

        }

        public void Add(KeyValuePair<Tkey, Tval> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Tkey, Tval> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Tkey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Tkey, Tval>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Tkey, Tval>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Tkey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Tkey, Tval> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Tkey key, [MaybeNullWhen(false)] out Tval value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
