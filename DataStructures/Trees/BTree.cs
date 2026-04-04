using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BTree<T> where T : IComparable<T>
    {
        public BNode<T> Root;
        public BTree()
        {
            Root = null;
        }
        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new BNode<T>(value);
                return;
            }
            if (!Root.Insert(value))
            {
                if (Root.Degree == 4)
                {
                    Root = Root.Split();
                }
                Root.Insert(value);
            }
        }
        public bool Contains(T value)
        {
            if (Root == null)
            {
                return false;
            }
            return Root.Contains(value);
        }
    }
}
