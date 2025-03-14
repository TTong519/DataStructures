using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BinarySearchTreeNode<T>
    {
        public BinarySearchTreeNode<T>? Left { get; internal set; }
        public BinarySearchTreeNode<T>? Right { get; internal set; }
        public List<T> Values { get; internal set; }
        public BinarySearchTreeNode(T value)
        {
            Values = [value];
        }

        public override string ToString() => string.Join(", ", Values);
    }
}
