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

        public List<T> Value { get; internal set; }

        internal int Height { get; set; }
        internal int Balance { get { return Right.Height - Left.Height; } }
        public void Node(T value) 
        {
            Value.Add(value);
        }
        internal void updateHeight()
        {

        }
    }
}
