using DataStructures.StacksAndQueues;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T> Root;
        public int Count;
        public BinarySearchTree()
        {
            Count = 0;
            Root = null;
        }
        public BinarySearchTreeNode<T> Search(T value)
        {
            BinarySearchTreeNode<T> current = Root;
            while (true)
            {
                if(current == null)
                {
                    return null;
                }
                if (current.Values[0].CompareTo(value) > 0)
                {
                    current = current.Left;
                }
                else if (current.Values[0].CompareTo(value) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    for (int i = 0; i < current.Values.Count; i++)
                    {
                        if (current.Values[i].Equals(value))
                        {
                            return current;
                        }
                    }
                    return null;
                }
            }
        }
        public void Insert(T value)
        {
            Count++;
            if(Root == null)
            {
                Root = new(value);
                return;
            }
            BinarySearchTreeNode<T> current = Root;
            while(true)
            {
                if (current.Values[0].CompareTo(value) > 0)
                {
                    if(current.Left == null)
                    {
                        current.Left = new(value);
                        return;
                    }
                    else 
                    {
                        current = current.Left;
                    }
                }
                else if (current.Values[0].CompareTo(value) < 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new(value);
                        return;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    current.Values.Add(value);
                    return;
                }
            }
        }
        public BinarySearchTreeNode<T> InsertRecursive(T value, BinarySearchTreeNode<T> currentNode)
        {
            if (currentNode == null) return new(value);
            int comp = value.CompareTo(currentNode.Values[0]);
            if (comp > 0)
            {
                currentNode.Right = InsertRecursive(value, currentNode.Right);
                return null;
            }
            else if(comp < 0)
            {
                currentNode.Left = InsertRecursive(value, currentNode.Left);
                return null;
            }
            else
            {
                currentNode.Values.Add(value);
                return null;
            }
        }
        public T Minimum()
        {
            BinarySearchTreeNode<T> current = Root;
            while(true)
            {
                if(current.Left != null)
                {
                    current = current.Left;
                }
                else
                {
                    return current.Values[0];
                }
            }
        }
        public T Maximum()
        {
            BinarySearchTreeNode<T> current = Root;
            while (true)
            {
                if (current.Right != null)
                {
                    current = current.Right;
                }
                else
                {
                    return current.Values[0];
                }
            }
        }
        public Queue<T> LevelOrderTraversal()
        {
            Queue<BinarySearchTreeNode<T>> toTraverse = new();
            Queue<T> traversed = new();
            toTraverse.Enqueue(Root);
            while(toTraverse.Count != 0)
            {
                BinarySearchTreeNode<T> current = toTraverse.Dequeue();
                if (current == null) continue;

                toTraverse.Enqueue(current.Left);
                toTraverse.Enqueue(current.Right);
                foreach(var thing in current.Values)
                {
                    traversed.Enqueue(thing);
                }
            }
            return traversed;
        }
        public Queue<T> PreOrderTraversal()
        {
            Stack<BinarySearchTreeNode<T>> toTransverse = new();
            Queue<T> traversed = new();
            toTransverse.Push(Root);
            while(toTransverse.Count != 0)
            {
                BinarySearchTreeNode<T> transversing = toTransverse.Pop();
                if(transversing != null)
                {
                    foreach(var value in transversing.Values)
                    {
                        traversed.Enqueue(value);
                    }
                    toTransverse.Push(transversing.Right);
                    toTransverse.Push(transversing.Left);
                }
            }
            return traversed;
        }
        public void PreOrderTraversalRecursive(Queue<T> traversed, BinarySearchTreeNode<T> node)
        {
            foreach (var thing in node.Values)
            {
                traversed.Enqueue(thing);
            }
            if (node.Left != null) PreOrderTraversalRecursive(traversed, node.Left);
            if (node.Right != null) PreOrderTraversalRecursive(traversed, node.Right);
        }
        public Stack<T> PostOrderTraversal()
        {
            Stack<BinarySearchTreeNode<T>> toTransverse = new();
            Stack<T> traversed = new();
            toTransverse.Push(Root);
            while (toTransverse.Count != 0)
            {
                BinarySearchTreeNode<T> transversing = toTransverse.Pop();
                if (transversing != null)
                {
                    foreach (var value in transversing.Values)
                    {
                        traversed.Push(value);
                    }
                    toTransverse.Push(transversing.Left);
                    toTransverse.Push(transversing.Right);
                }
            }
            return traversed;
        }
        public void PostOrderTraversalRecursive(List<T> traversed, BinarySearchTreeNode<T> node)
        {
            if (node.Left != null) PostOrderTraversalRecursive(traversed, node.Left);
            if (node.Right != null) PostOrderTraversalRecursive(traversed, node.Right);
            foreach (var thing in node.Values)
            {
                traversed.Add(thing);
            }
        }
        public Queue<T> InOrderTraversal()
        {
            Stack<BinarySearchTreeNode<T>> Return = new();
            Queue<T> traversed = new();
            BinarySearchTreeNode<T> traversing = Root;
            while(Return.Count != 0 || traversing != null)
            {
                if(traversing != null)
                {
                    Return.Push(traversing);
                    traversing = traversing.Left;
                }
                else
                {
                    BinarySearchTreeNode<T> temp = Return.Pop();
                    foreach (var val in temp.Values)
                    {
                        traversed.Enqueue(val);
                    }
                    traversing = temp.Right;
                }
            }
            return traversed;
        }
        public void InOrderTraversalRecursive(List<T> traversed, BinarySearchTreeNode<T> node)
        {
            if (node.Left != null) InOrderTraversalRecursive(traversed, node.Left);
            foreach (var thing in node.Values)
            {
                traversed.Add(thing);
            }
            if (node.Right != null) InOrderTraversalRecursive(traversed, node.Right);
        }
        private BinarySearchTreeNode<T> Remove(BinarySearchTreeNode<T> Node, T val)
        {
           if(Node.Values.Count > 1)
           {
                Node.Values.Remove(val);
                return Node;
           }
           if(Node.Left == null) return Node.Right;
           else if (Node.Right == null) return Node.Left;
           else
           {
                BinarySearchTreeNode<T> biggestsmall = Node.Left;
                BinarySearchTreeNode<T> parent = biggestsmall;
                if (biggestsmall.Right != null) biggestsmall = biggestsmall.Right;
                while (biggestsmall.Right != null)
                {
                    parent = biggestsmall;
                    biggestsmall = biggestsmall.Right;
                }
                if(parent != biggestsmall)parent.Right = biggestsmall.Left;
                return biggestsmall;
           }
        }
        public bool Remove(T val)
        {
            BinarySearchTreeNode<T> current = Root;
            while (current != null)
            {
                if (current.Values[0].CompareTo(val) > 0)
                {
                    if (current.Left != null && current.Left.Values[0].CompareTo(val) == 0)
                    {
                        BinarySearchTreeNode<T> toReplace = Remove(current.Left, val);
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
                        BinarySearchTreeNode<T> toReplace = Remove(current.Right, val);
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
                    current = current.Left;
                }
                else if (current.Values[0].CompareTo(val) < 0)
                {
                    if (current.Left != null && current.Left.Values[0].CompareTo(val) == 0)
                    {
                        BinarySearchTreeNode<T> toReplace = Remove(current.Left, val);
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
                        BinarySearchTreeNode<T> toReplace = Remove(current.Right, val);
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
                    current = current.Right;
                }
            }
            return false;
        }
    }
}
