using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    internal class ContainerNode : BurstNode
    {
        public BinarySearchTree<string> Data;
        public override int Count => Data.Count;
        public ContainerNode(BurstTrie parent) : base(parent)
        {
            Data = new BinarySearchTree<string>();
        }

        public override BurstNode Insert(string value, int index)
        {
            Data.Insert(value);
            return this;
        }

        public override BurstNode Remove(string value, int index, out bool success)
        {
            success = Data.Remove(value);
            return this;
        }

        public override BurstNode Search(string prefix, int index)
        {
            throw new NotImplementedException();
        }

        internal override void GetAll(List<string> output)
        {
            throw new NotImplementedException();
        }
    }
}
