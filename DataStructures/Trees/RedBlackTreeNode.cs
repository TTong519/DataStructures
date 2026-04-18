using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class RedBlackTreeNode<T> where T : IComparable<T>
    {
        private bool isRed;
        public T Value { get; private set; }
        public RedBlackTreeNode<T> Left { get; private set; }
        public RedBlackTreeNode<T> Right { get; private set; }
        public RedBlackTreeNode(bool isRed, T value, RedBlackTreeNode<T> left = null, RedBlackTreeNode<T> right = null)
        {
            this.isRed = isRed;
            Value = value;
            Left = left;
            Right = right;
        }
        public static bool IsRed(RedBlackTreeNode<T> node) => node != null && node.isRed;
        public void FlipColor()
        {
            isRed = !isRed;
            if (IsRed(Left))
            {
                Left.FlipColor();
            }
            if (IsRed(Right))
            {
                Right.FlipColor();
            }
        }
        public static RedBlackTreeNode<T> RotateLeft(RedBlackTreeNode<T> node)
        {
            RedBlackTreeNode<T> toReturn = node.Right;
            toReturn.FlipColor();
            RedBlackTreeNode<T> temp = toReturn.Left;
            toReturn.Left = node;
            toReturn.Left.Right = temp;
            toReturn.Left.FlipColor();
            return toReturn;
        }
        public static RedBlackTreeNode<T> RotateRight(RedBlackTreeNode<T> node)
        {
            RedBlackTreeNode<T> toReturn = node.Left;
            toReturn.FlipColor();
            RedBlackTreeNode<T> temp = toReturn.Right;
            toReturn.Right = node;
            toReturn.Right.Left = temp;
            toReturn.Right.FlipColor();
            return toReturn;
        }
        bool is4Node() => IsRed(Left) && IsRed(Right);
        public void Insert(T value)
        {
            if(is4Node()) FlipColor();
            if (value.CompareTo(Value) < 0)
            {
                if (Left == null)
                {
                    Left = new RedBlackTreeNode<T>(isRed, value);
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else if (value.CompareTo(Value) > 0)
            {
                if (Right == null)
                {
                    Right = new RedBlackTreeNode<T>(isRed, value);
                }
                else
                {
                    Right.Insert(value);
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
            if(IsRed(Left?.Right) && !IsRed(Left?.Left))
            {
                Left = RotateLeft(Left);
            }
            if (IsRed(Left?.Left) && IsRed(Left?.Left?.Left))
            {
                Left = RotateRight(Left);
            }
            if (IsRed(Right?.Right) && !IsRed(Right?.Left))
            {
                Right = RotateLeft(Right);
            }
            if (IsRed(Right?.Left) && IsRed(Right?.Left?.Left))
            {
                Right = RotateRight(Right);
            }
        }
    }
}
