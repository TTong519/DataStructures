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
        public int Count { get; private set; }
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
        public AVLTreeNode<T> Insert(T value, AVLTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                Count++;
                return new(value);
            }
            int comp = value.CompareTo(currentNode.Values[0]);
            if (comp > 0)
            {
                currentNode.Right = Insert(value, currentNode.Right);
                currentNode.updateHeight();
                if(currentNode.Balance > 1)
                {
                    if(currentNode.Right.Balance < 0)
                    {
                        currentNode.Right = RotateRight(currentNode.Right);
                    }
                    else
                    {

                    }
                }
                return currentNode;
            }
            else if (comp < 0)
            {
                currentNode.Left = Insert(value, currentNode.Left);
                currentNode.updateHeight();
                return currentNode;
            }
            else
            {
                currentNode.Values.Add(value);
                Count++;
                return currentNode;
            }
        }
    }
}
