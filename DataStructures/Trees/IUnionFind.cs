using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public interface IUnionFind<T>
    {
        int Find(T p);
        void Union(T p, T q);
        bool areConnected(T p, T q);
    }
}
