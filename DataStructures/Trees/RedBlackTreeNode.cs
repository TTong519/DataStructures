using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class RedBlackTreeNode<T> where T : IComparable<T>
    {
        public bool isRed { get; private set; }
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
            if (node.isRed) throw new Exception("rotate left was called on a red node, invalid");
            RedBlackTreeNode<T> newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            newNode.isRed = false;
            node.isRed = true;
            return newNode;
        }
        
        public static RedBlackTreeNode<T> RotateRight(RedBlackTreeNode<T> node)
        {
            if (node.isRed) throw new Exception("rotate right was called on a red node, invalid");
            RedBlackTreeNode<T> newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;
            newNode.isRed = false;
            node.isRed = true;
            return newNode;
        }
        
        private RedBlackTreeNode<T> FixUp(RedBlackTreeNode<T> node)
        {
            if (node == null) return null;
            
            if (IsRed(node.Right) && !IsRed(node.Left))
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
        
        public void Insert(T value)
        {
            // TODO: Call FixUp on self, not children
            if (value.CompareTo(Values[0]) < 0)
            {
                if (Left == null)
                {
                    Left = new RedBlackTreeNode<T>(true, value);
                }
                else
                {
                    Left.Insert(value);
                }
                Left = FixUp(Left);
            }
            else if (value.CompareTo(Values[0]) > 0)
            {
                if (Right == null)
                {
                    Right = new RedBlackTreeNode<T>(true, value);
                }
                else
                {
                    Right.Insert(value);
                }
                Right = FixUp(Right);
            }
            else
            {
                Values.Add(value);
            }
        }
    }
}