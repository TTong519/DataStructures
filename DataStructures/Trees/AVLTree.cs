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
            AVLTreeNode<T> nodeRight = node.Right;
            node.Right = nodeRight.Left;
            if (node.Right != null) node.Right.UpdateHeight();
            nodeRight.Left = node;
            nodeRight.UpdateHeight();
            return nodeRight;
        }
        private AVLTreeNode<T> RotateRight(AVLTreeNode<T> node)
        {
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
            if (currentNode.Left != null) currentNode.Left.UpdateHeight();
            if (currentNode.Right != null) currentNode.Right.UpdateHeight();
            return currentNode;
        }

        public void Insert(T value)
        {
            var node = InsertRec(value, Root);
            Root = node;
        }
        public AVLTreeNode<T> InsertRec(T value, AVLTreeNode<T> currentNode)
        {
            if (currentNode == null)
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
            currentNode.UpdateHeight();
            return currentNode;

        }
        public AVLTreeNode<T> Find(T value)
        {
            if (Root == null) return null;
            return FindRecursive(Root, value);
        }
        public AVLTreeNode<T> FindRecursive(AVLTreeNode<T> current, T value)
        {
            if (current == null) return null;
            if (current.Values.Contains(value)) return current;
            if (current.Values[0].CompareTo(value) > 0)
            {
                return FindRecursive(current.Left, value);
            }
            else
            {
                return FindRecursive(current.Right, value);
            }
        }
        private AVLTreeNode<T> RemoveNode(AVLTreeNode<T> Node)
        {
            if (Node.Left == null && Node.Right == null)
            {
                return null;
            }
            else if (Node.Left != null && Node.Right != null)
            {
                AVLTreeNode<T> tempNode = Node.Left;
                while (tempNode.Right != null)
                {
                    tempNode = tempNode.Right;
                }
                Node.Values = tempNode.Values;
                Node.Left = RemoveRecursive(Node.Left, tempNode.Values[0]);
                return Node;
            }
            else if (Node.Left != null)
            {
                return Node.Left;
            }
            else
            {
                return Node.Right;
            }
        }
        public AVLTreeNode<T> RemoveRecursive(AVLTreeNode<T> currentNode, T val)
        {
            if (currentNode == null) return null;
            if (currentNode.Values.Contains(val))
            {
                if (currentNode.Values.Count > 1)
                {
                    currentNode.Values.Remove(val);
                    return currentNode;
                }
                else
                {
                    currentNode = RemoveNode(currentNode);
                    if(currentNode != null)
                    {
                        currentNode.UpdateHeight();
                        Balance(currentNode);
                    }
                }
            }
            else if (currentNode.Values[0].CompareTo(val) > 0)
            {
                currentNode.Left = RemoveRecursive(currentNode.Left, val);
                if (currentNode.Left != null)
                {
                    currentNode.Left.UpdateHeight();
                    currentNode.Left = Balance(currentNode);
                }
                currentNode.UpdateHeight();
                currentNode = Balance(currentNode);
            }
            else
            {
                currentNode.Right = RemoveRecursive(currentNode.Right, val);
                if (currentNode.Right != null)
                {
                    currentNode.Left.UpdateHeight();
                    currentNode = Balance(currentNode);
                }
                currentNode.UpdateHeight();
                currentNode = Balance(currentNode);
            }
            return currentNode;
        }
    }
}