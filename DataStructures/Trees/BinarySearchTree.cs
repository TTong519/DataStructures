using DataStructures.StacksAndQueues;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
    }
}
