using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class QuickFind<T> : IUnionFind<T>
    {
        Dictionary<T, int> Data = new();
        public bool Add(T item)
        {
            if (Data.ContainsKey(item))
                return false;
            Data.Add(item, Data.Count);
            return true;
        }
        public int Find(T p)
        {
            return Data[p];
        }
        public void Union(T p, T q)
        {
            foreach (var key in Data.Keys)
            {
                int sID = Find(q);
                if (Find(key) == sID)
                    Data[key] = Find(p);
            }
        }
        public bool areConnected(T p, T q)
        {
            return Data[p] == Data[q];
        }
    }
}
