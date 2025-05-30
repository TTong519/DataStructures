using DaraStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLTreeNode<T> Root;
        public AVLTreeNode<T> RotateLeft(AVLTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node cannot be null");
            if (node.Right == null) throw new ArgumentNullException("node.Right cannot be null");
            AVLTreeNode<T> nodeRight = node.Right;
            node.Right = nodeRight.Left;
            nodeRight.Left = node;
            return nodeRight;
        }
        public AVLTreeNode<T> RotateRight(AVLTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node cannot be null");
            if (node.Left == null) throw new ArgumentNullException("node.Left cannot be null");
            AVLTreeNode<T> nodeLeft = node.Left;
            node.Left = nodeLeft.Right;
            nodeLeft.Right = node;
            return nodeLeft;
        }
    }
}
