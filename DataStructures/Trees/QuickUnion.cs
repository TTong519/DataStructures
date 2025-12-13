using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class QuickUnion<T> : IUnionFind<T>
    {
        Dictionary<T, int> Data = new();
        public bool Add(T item)
        {
            if (Data.ContainsKey(item))
                return false;
            Data.Add(item, -1);
            return true;
        }
        public int Find(T p)
        {
            int toReturn;
            if (Data[p] == -1)
            {
                return -1;
            }
            else
            {
                toReturn = Find(Data.Keys.ToList()[Data.Values.ToList().IndexOf(Data[p])]);
                if (toReturn != -1)
                    toReturn = Data[p];
            }
            return toReturn;
        }
        public void Union(T p, T q)
        {
            Data[q] = Find(p);
        }
        public bool areConnected(T p, T q)
        {
            if(Find(p) == Find(q))
                return true;
            return false;
        }
    }
}
