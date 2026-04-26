using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class RedBlackTreeNode<T> where T : IComparable<T>
    {
        public bool isRed { get; set; }
        public List<T> Values { get; private set; }
        public RedBlackTreeNode<T> Left { get; private set; }
        public RedBlackTreeNode<T> Right { get; private set; }
        public RedBlackTreeNode(bool isRed, T value, RedBlackTreeNode<T> left = null, RedBlackTreeNode<T> right = null)
        {
            this.isRed = isRed;
            Values = new();
            Values.Add(value);
            Left = left;
            Right = right;
        }
        public static bool IsRed(RedBlackTreeNode<T> node) => node != null && node.isRed;
        
        public void FlipColor()
        {
            isRed = !isRed;
            if (Left != null) Left.isRed = !Left.isRed;
            if (Right != null) Right.isRed = !Right.isRed;
        }
        
        public static RedBlackTreeNode<T> RotateLeft(RedBlackTreeNode<T> node)
        {
            RedBlackTreeNode<T> newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            bool temp = newNode.isRed;
            newNode.isRed = node.isRed;
            node.isRed = temp;
            return newNode;
        }
        
        public static RedBlackTreeNode<T> RotateRight(RedBlackTreeNode<T> node)
        {
            RedBlackTreeNode<T> newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;
            bool temp = newNode.isRed;
            newNode.isRed = node.isRed;
            node.isRed = temp;
            return newNode;
        }
        
        private RedBlackTreeNode<T> FixUp(RedBlackTreeNode<T> node)
        {
            if (node == null) return null;

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                node.FlipColor();
            }

            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                node.FlipColor();
            }

            return node;
        }
        
        public RedBlackTreeNode<T> Insert(T value)
        {
            if (value.CompareTo(Values[0]) < 0)
            {
                if (Left == null)
                {
                    Left = new RedBlackTreeNode<T>(true, value);
                }
                else
                {
                    Left = Left.Insert(value);
                }
            }
            else if (value.CompareTo(Values[0]) > 0)
            {
                if (Right == null)
                {
                    Right = new RedBlackTreeNode<T>(true, value);
                }
                else
                {
                    Right = Right.Insert(value);
                }
            }
            else
            {
                Values.Add(value);
                return this;
            }
            return FixUp(this);
        }

        public (bool, RedBlackTreeNode<T>) Remove(T value)
        {
            if (value.CompareTo(Values[0]) < 0)
            {
                if (Left == null) return (false, this);
                if (!IsRed(Left) && !IsRed(Left.Left))
                {
                    var temp = FixUp(this);
                    if (temp != this) return temp.Remove(value);
                }
                var result = Left.Remove(value);
                Left = result.Item2;
                return (result.Item1, FixUp(this));
            }
            else if (value.CompareTo(Values[0]) > 0)
            {
                if (Right == null) return (false, this);
                if (!IsRed(Right) && !IsRed(Right.Left))
                {
                    var temp = FixUp(this);
                    if (temp != this) return temp.Remove(value);
                }
                var result = Right.Remove(value);
                Right = result.Item2;
                return (result.Item1, FixUp(this));
            }
            else
            {
                if (Values.Count > 1)
                {
                    Values.RemoveAt(Values.Count - 1);
                    return (true, this);
                }
                if (Right == null) return (true, Left);
                RedBlackTreeNode<T> minNode = Right;
                while (minNode.Left != null)
                    minNode = minNode.Left;
                Values[0] = minNode.Values[0];
                var result = Right.Remove(minNode.Values[0]);
                Right = result.Item2;
                return (true, FixUp(this));
            }
        }
    }
}