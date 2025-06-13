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
        public int Balance { get { return GetBalance(); } }
        int GetBalance()
        {
            int leftHeight = 0;
            int rightHeight = 0;
            if (Left != null) { leftHeight = Left.Height; }
            if (Right != null) { rightHeight = Right.Height; }
            return rightHeight - leftHeight;
        }
        public AVLTreeNode(T value) 
        {
            Values = new List<T>();
            Values.Add(value);
            Height = 1;
        }
        internal void UpdateHeight()
        {
            int leftHeight =0 ;
            int rightHeight =0;
            if (Left != null) leftHeight = Left.Height;
            if (Right != null) rightHeight = Right.Height;
            Height = Math.Max(leftHeight, rightHeight)+1;
        }
    }
}
