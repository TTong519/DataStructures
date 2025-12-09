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
            if (Data[p] == -1)
            {
                return -1;
            }
            else
            {
                int toReturn = Find(Data.Keys.ToList()[Data.Values.ToList().IndexOf(Data[p])]);
                if (toReturn != -1)
                    toReturn = Data[p];
            }
        }
        public void Union(T p, T q)
        {
            throw new NotImplementedException();
        }
        public bool areConnected(T p, T q)
        {
            throw new NotImplementedException();
        }
    }
}
