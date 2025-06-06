using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaraStructures.Trees
{
    public class AVLTreeNode<T> where T : IComparable<T>
    {
        public AVLTreeNode<T> Left { get; internal set; }
        public AVLTreeNode<T> Right { get; internal set; }

        public List<T> Values { get; internal set; }

        public int Height { get; private set; }
        public int Balance { get { return Right.Height - Left.Height; } }
        public AVLTreeNode(T value) 
        {
            Values = new List<T>();
            Values.Add(value);
            Height = 1;
        }
        internal void UpdateHeight()
        {
            int leftHeight = 0;
            int rightHeight = 0;
            if (Left != null) leftHeight = Left.Height + 1;
            if (Right != null) rightHeight = Right.Height + 1;
            Height = Math.Max(leftHeight, rightHeight);
        }
    }
}
