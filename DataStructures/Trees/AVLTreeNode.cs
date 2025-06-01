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

        internal int Height { get; private set; }
        internal int Balance { get { return Right.Height - Left.Height; } }
        public AVLTreeNode(T value) 
        {
            Values.Add(value);
            Height = 0;
        }
        internal void updateHeight()
        {
            int leftHeight = 0;
            int rightHeight = 0;
            if (Left != null) leftHeight = Left.Height + 1;
            if (Right != null) rightHeight = Right.Height + 1;
            if(leftHeight >= rightHeight)
            {
                Height = leftHeight;
            }
            else
            {
                Height = rightHeight;
            }
        }
    }
}
