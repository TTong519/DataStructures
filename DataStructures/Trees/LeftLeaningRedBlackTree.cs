using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class LeftLeaningRedBlackTree<T> where T : IComparable<T>
    {
        public RedBlackTreeNode<T> Root { get; private set; }
        public int Count { get; private set; }
        public LeftLeaningRedBlackTree(T value)
        {
            Root = new RedBlackTreeNode<T>(false, value);
            Count = 1;
        }
        public LeftLeaningRedBlackTree()
        {
            Root = null;
            Count = 0;
        }
        public void Insert(T value)
        {
            if(Count == 0) Root = new RedBlackTreeNode<T>(false, value);
            else Root = Root.Insert(value);

            if(RedBlackTreeNode<T>.IsRed(Root)) Root.isRed = false;

            Count++;
        }
    }
}
