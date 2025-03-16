using DataStructures.StacksAndQueues;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T>? Root;
        public int Count;
        public BinarySearchTree()
        {
            Count = 0;
            Root = null;
        }
        public BinarySearchTreeNode<T>? Search(T value)
        {
            BinarySearchTreeNode<T>? current = Root;
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
            BinarySearchTreeNode<T>? current = Root;
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
        public List<T> LevelOrderTransversal()
        {
            ArrayBackedQueue<BinarySearchTreeNode<T>> toTransverse = new();
            ArrayBackedQueue<BinarySearchTreeNode<T>> transversed = new();
            List<T> output = new();
            toTransverse.Enqueue(Root);
            while(transversed.Count < Count)
            {
                BinarySearchTreeNode<T> current = toTransverse.Dequeue();
                transversed.Enqueue(current);
                if (current.Left != null)
                {
                    toTransverse.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    toTransverse.Enqueue(current.Right);
                }
                foreach(var thing in current.Values)
                {
                    output.Add(thing);
                }
            }
            return output;
        }
        public List<T> PreOrderTransversal()
        {
            ArrayBackedStack<BinarySearchTreeNode<T>> toTransverse = new();
            ArrayBackedQueue<BinarySearchTreeNode<T>> transversed = new();
            List<T> output = new();
            while(transversed.Count < Count)
            {

            }
        }
    }
}
