using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BTree
    {
        public BNode<int> Root;
        public BTree()
        {
            Root = null;
        }
        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new BNode<int>(value);
                return;
            }
            //Insert(Root, value);
        }
    }
}
