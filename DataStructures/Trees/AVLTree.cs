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
        private AVLTreeNode<T> RotateLeft(AVLTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node cannot be null");
            if (node.Right == null) throw new ArgumentNullException("node.Right cannot be null");
            AVLTreeNode<T> nodeRight = node.Right;
            node.Right = nodeRight.Left;
            if (node.Right != null) node.Right.UpdateHeight();
            nodeRight.Left = node;
            nodeRight.UpdateHeight();
            return nodeRight;
        }
        private AVLTreeNode<T> RotateRight(AVLTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node cannot be null");
            if (node.Left == null) throw new ArgumentNullException("node.Left cannot be null");
            AVLTreeNode<T> nodeLeft = node.Left;
            node.Left = nodeLeft.Right;
            if (node.Left != null) node.Left.UpdateHeight();
            nodeLeft.Right = node;
            nodeLeft.UpdateHeight();
            return nodeLeft;
        }
        private AVLTreeNode<T> Balance(AVLTreeNode<T> currentNode)
        {
            if (currentNode.Balance > 1)
            {
                if (currentNode.Right.Balance < 0)
                {
                    currentNode.Right = RotateRight(currentNode.Right);
                    currentNode.Right.UpdateHeight();
                }
                currentNode = RotateLeft(currentNode);

            }
            else if (currentNode.Balance < -1)
            {
                if (currentNode.Left.Balance > 0)
                {
                    currentNode.Left = RotateLeft(currentNode.Left);
                    currentNode.Left.UpdateHeight();
                }
                currentNode = RotateRight(currentNode);

            }
            currentNode.UpdateHeight();
            return currentNode;
        }
        
        public void Insert(T value)
        {
            var node=InsertRec(value, Root);
            Root = node;
        }
        public AVLTreeNode<T> InsertRec(T value, AVLTreeNode<T> currentNode)
        {
            if(currentNode == null)
            {
                Count++;
                return new AVLTreeNode<T>(value);
            }
            if (currentNode.Values[0].CompareTo(value) > 0)
            {
                currentNode.Left = InsertRec(value, currentNode.Left);
            }
            else if (currentNode.Values[0].CompareTo(value) < 0)
            {
                currentNode.Right = InsertRec(value, currentNode.Right);
            }
            else
            {
                currentNode.Values.Add(value);
                Count++;
                return currentNode;
            }
            currentNode.UpdateHeight();
            currentNode = Balance(currentNode);
            return currentNode;

        }

    }
}
