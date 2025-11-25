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
        public Tval this[Tkey key] 
        { 
            get 
            { 
                foreach (var pair in storage[Math.Abs(key.GetHashCode() % storage.Length)]) 
                { 
                    if (pair.Key.Equals(key)) return pair.Value; 
                } 
                throw new Exception(); 
            } 
            set 
            { 
                for (int i = 0; i < storage[Math.Abs(key.GetHashCode() % storage.Length)].Count; i++) 
                { 
                    var pair = storage[Math.Abs(key.GetHashCode() % storage.Length)].ElementAt(i); 
                    if (pair.Key.Equals(key)) 
                    { 
                        storage[Math.Abs(key.GetHashCode() % storage.Length)].Remove(pair); 
                        storage[Math.Abs(key.GetHashCode() % storage.Length)].AddLast(new KeyValuePair<Tkey, Tval>(key, value)); 
                        return; 
                    } 
                } 
                Add(key, value);
            } 
        }
        public ICollection<Tkey> Keys 
        {
            get 
            { 
                List<Tkey> toReturn = new(); 
                foreach (var bucket in storage) 
                { 
                    foreach (var pair in bucket) 
                    { 
                        toReturn.Add(pair.Key);
                    } 
                } return toReturn; 
            } 
        }
        public ICollection<Tval> Values 
        { 
            get 
            { 
                List<Tval> toReturn = new(); 
                foreach (var bucket in storage) 
                { 
                    foreach (var pair in bucket) 
                    { 
                        toReturn.Add(pair.Value); 
                    } 
                } return toReturn; 
            } 
        }
        private LinkedList<KeyValuePair<Tkey, Tval>>[] storage = new LinkedList<KeyValuePair<Tkey, Tval>>[50];

        public int Count { get; private set; }
        public bool IsReadOnly => false;
        public IEqualityComparer<Tkey> Comparer { get; private set; }

        public HashMap() : this(EqualityComparer<Tkey>.Default) { }
        public HashMap(IEqualityComparer<Tkey> comparer)
        {
            Comparer = comparer;
            Count = 0;
            for(int i = 0; i < storage.Length; i++)
            {
                storage[i] = new LinkedList<KeyValuePair<Tkey, Tval>>();
            }
        }

        public void Add(Tkey key, Tval value)
        {
            if (Count + 1 > storage.Length)
            {
                Rehash();
            }
            int hash = Comparer.GetHashCode(key);
            hash = Math.Abs(hash % storage.Length);
            storage[hash].AddLast(new KeyValuePair<Tkey, Tval>(key, value));
            Count++;
        }

        public void Add(KeyValuePair<Tkey, Tval> item)
        {
            if (Count + 1 > storage.Length)
            {
                Rehash();
            }
            int hash = Comparer.GetHashCode(item.Key);
            hash = Math.Abs(hash % storage.Length);
            storage[hash].AddLast(item);
            Count++;
        }

        public void Clear()
        {
            Count = 0;
            storage = new LinkedList<KeyValuePair<Tkey, Tval>>[50];
        }

        public bool Contains(KeyValuePair<Tkey, Tval> item)
        {
            foreach(var pair in storage[Math.Abs(item.Key.GetHashCode() % storage.Length)])
            {
                return item.Value.Equals(pair.Value);
            }
            return false;
        }

        public bool ContainsKey(Tkey key)
        {
            if (storage[Math.Abs(key.GetHashCode() % storage.Length)].Count == 0) return false;
            return true;
        }

        public void CopyTo(KeyValuePair<Tkey, Tval>[] array, int arrayIndex)
        {
            foreach (var bucket in storage)
            {
                foreach (var pair in bucket)
                {
                    array[arrayIndex++] = pair;
                }
            }
        }

        public IEnumerator<KeyValuePair<Tkey, Tval>> GetEnumerator()
        {
            for(int i = 0; i < storage.Length; i++)
            {
                foreach(var pair in storage[i])
                {
                    yield return pair;
                }
            }
        }

        public bool Remove(Tkey key)
        {
            foreach(var pair in storage[Math.Abs(key.GetHashCode() % storage.Length)])
            {
                if (pair.Key.Equals(key))
                {
                    storage[Math.Abs(key.GetHashCode() % storage.Length)].Remove(pair);
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<Tkey, Tval> item)
        {
            foreach(var pair in storage[Math.Abs(item.Key.GetHashCode() % storage.Length)])
            {
                if (pair.Key.Equals(item.Key) && pair.Value.Equals(item.Value))
                {
                    storage[Math.Abs(item.Key.GetHashCode() % storage.Length)].Remove(pair);
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(Tkey key, [MaybeNullWhen(false)] out Tval value)
        {
            foreach (var pair in storage[Math.Abs(key.GetHashCode() % storage.Length)])
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            value = default;
            return false;
        }

        private void Rehash()
        {
            LinkedList<KeyValuePair<Tkey, Tval>>[] newStorage = new LinkedList<KeyValuePair<Tkey, Tval>>[storage.Length * 2];
            for (int i = 0; i < newStorage.Length; i++)
            {
                newStorage[i] = new LinkedList<KeyValuePair<Tkey, Tval>>();
            }
            foreach (var bucket in storage)
            {
                foreach (var pair in bucket)
                {
                    int hash = Comparer.GetHashCode(pair.Key);
                    hash = Math.Abs(hash % newStorage.Length);
                    newStorage[hash].AddLast(pair);
                }
            }
            storage = newStorage;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
