using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class LRUCache<Tkey, Tvalue>
    {
        LinkedList<KeyValuePair<Tkey, Tvalue>> values;
        Dictionary<Tkey, LinkedListNode<KeyValuePair<Tkey, Tvalue>>> cache;
        int capacity;
        public int Count { get { return values.Count; } }
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            values = new LinkedList<KeyValuePair<Tkey, Tvalue>>();
            cache = new Dictionary<Tkey, LinkedListNode<KeyValuePair<Tkey, Tvalue>>>();
        }
        public Tvalue Get(Tkey key)
        {
            if (!cache.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }
            var node = cache[key];
            values.Remove(node);
            values.AddFirst(node);
            cache[key] = values.First;
            return node.Value.Value;
        }
        public bool TryGet(Tkey key, out Tvalue value)
        {
            if (!cache.ContainsKey(key))
            {
                value = default(Tvalue);
                return false;
            }
            value = Get(key);
            return true;
        }
        public void Put(Tkey key, Tvalue value)
        {
            if (cache.ContainsKey(key))
            {
                var node = cache[key];
                values.Remove(node);
                values.AddFirst(node);
                cache[key] = values.First;
                node.Value = new KeyValuePair<Tkey, Tvalue>(key, value);
                return;
            }
            if(values.Count == capacity)
            {
                var lruNode = values.Last;
                values.RemoveLast();
                cache.Remove(lruNode.Value.Key);
            }
            values.AddFirst(new KeyValuePair<Tkey, Tvalue>(key, value));
            cache[key] = values.First;
        }
    }
}
