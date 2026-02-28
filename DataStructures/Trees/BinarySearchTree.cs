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
        private BinarySearchTreeNode<T> HelperInsertRecursive(T value, BinarySearchTreeNode<T> currentNode)
        {
            if (currentNode == null) 
            {
                Count++;
                return new(value); 
            }
            int comp = value.CompareTo(currentNode.Values[0]);
            if (comp > 0)
            {
                currentNode.Right = HelperInsertRecursive(value, currentNode.Right);
                return currentNode;
            }
            else if(comp < 0)
            {
                currentNode.Left = HelperInsertRecursive(value, currentNode.Left);
                return currentNode;
            }
            else
            {
                currentNode.Values.Add(value);
                Count++;
                return currentNode;
            }
        }
        public void InsertRecursive(T value)
        {
            if(Root == null)
            { 
               Root = HelperInsertRecursive(value, null);
            }
            else
            {
                HelperInsertRecursive(value, Root);
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
            if (Node == null) return null;

            int comp = val.CompareTo(Node.Values[0]);
            if (comp < 0)
            {
                Node.Left = Remove(Node.Left, val);
                return Node;
            }
            else if (comp > 0)
            {
                Node.Right = Remove(Node.Right, val);
                return Node;
            }
            else
            {
                // Found the node that contains the value
                if (Node.Values.Count > 1)
                {
                    // If there are duplicates stored in this node, remove one occurrence
                    bool removed = Node.Values.Remove(val);
                    if (removed) Count--;
                    return Node;
                }

                // No duplicates: remove the node from the tree
                Count--;

                // If one child is null, return the other
                if (Node.Left == null) return Node.Right;
                if (Node.Right == null) return Node.Left;

                // Both children exist: find inorder predecessor (max in left subtree)
                BinarySearchTreeNode<T> predecessor = Node.Left;
                while (predecessor.Right != null)
                {
                    predecessor = predecessor.Right;
                }

                // Copy predecessor's values into current node
                Node.Values = new System.Collections.Generic.List<T>(predecessor.Values);

                // Remove the predecessor node (remove by its representative value)
                Node.Left = Remove(Node.Left, predecessor.Values[0]);

                return Node;
            }
        }
        public bool RemoveRecursive(BinarySearchTreeNode<T> current, T val)
        {
            int before = Count;
            // Always perform removal starting from the root to ensure tree integrity
            Root = Remove(Root, val);
            return Count < before;
        }
        public bool Remove(T val)
        {
            int before = Count;
            Root = Remove(Root, val);
            return Count < before;
        }
    }
}
