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
            currentNode.UpdateHeight();
            return currentNode;

        }
        private AVLTreeNode<T> Remove(AVLTreeNode<T> Node, T val)
        {
            if (Node.Values.Count > 1)
            {
                Node.Values.Remove(val);
                return Node;
            }
            if (Node.Left == null) return Node.Right;
            else if (Node.Right == null) return Node.Left;
            else
            {
                AVLTreeNode<T> biggestsmall = Node.Left;
                AVLTreeNode<T> parent = biggestsmall;
                if (biggestsmall.Right != null)
                {
                    biggestsmall = biggestsmall.Right;
                    biggestsmall.UpdateHeight();
                }
                while (biggestsmall.Right != null)
                {
                    parent = biggestsmall;
                    parent.UpdateHeight();
                    biggestsmall = biggestsmall.Right;
                    biggestsmall.UpdateHeight();
                }
                if (parent != biggestsmall) parent.Right = biggestsmall.Left;
                parent.Right.UpdateHeight();
                biggestsmall = Balance(biggestsmall);
                return biggestsmall;
            }
        }
        public bool RemoveRecursive(AVLTreeNode<T> current, T val)
        {
            if (current == null) return false;
            current = Balance(current);
            if (current.Values[0].CompareTo(val) > 0)
            {
                if (current.Left != null && current.Left.Values[0].CompareTo(val) == 0)
                {
                    AVLTreeNode<T> toReplace = Remove(current.Left, val);
                    if (toReplace != null)
                    {
                        if (toReplace != current.Right.Left)
                        {
                            toReplace.Left = current.Right.Left;
                        }
                        toReplace.Right = current.Left.Right;
                    }
                    current.Left = toReplace;
                    return true;
                }
                else if (current.Right != null && current.Right.Values[0].CompareTo(val) == 0)
                {
                    AVLTreeNode<T> toReplace = Remove(current.Right, val);
                    if (toReplace != null)
                    {
                        if (toReplace != current.Right.Left)
                        {
                            toReplace.Left = current.Right.Left;
                        }
                        toReplace.Right = current.Right.Right;
                    }
                    current.Right = toReplace;
                    return true;
                }
                RemoveRecursive(current.Left, val);
            }
            else if (current.Values[0].CompareTo(val) < 0)
            {
                if (current.Left != null && current.Left.Values[0].CompareTo(val) == 0)
                {
                    AVLTreeNode<T> toReplace = Remove(current.Left, val);
                    if (toReplace != null)
                    {
                        if (toReplace != current.Right.Left)
                        {
                            toReplace.Left = current.Right.Left;
                        }
                        toReplace.Right = current.Left.Right;
                    }
                    current.Left = toReplace;
                    return true;
                }
                else if (current.Right != null && current.Right.Values[0].CompareTo(val) == 0)
                {
                    AVLTreeNode<T> toReplace = Remove(current.Right, val);
                    if (toReplace != null)
                    {
                        if (toReplace != current.Right.Left)
                        {
                            toReplace.Left = current.Right.Left;
                        }
                        toReplace.Right = current.Right.Right;
                    }
                    current.Right = toReplace;
                    return true;
                }
                RemoveRecursive(current.Right, val);
            }
            return false;
        }
    }
}
