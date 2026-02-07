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
            if(Data.Count > ParentTrie.MaxContainerSize)
            {
                var newNode = new InternalNode(ParentTrie);
                foreach (var item in Data.InOrderTraversal())
                {
                    newNode.Insert(item, index);
                }
                return newNode;
            }
            return this;
        }
        public override BurstNode Remove(string value, int index, out bool success)
        {
            success = Data.Remove(value);
            return this;
        }
        public override BurstNode Search(string prefix, int index)
        {
            return this;
        }
        internal override void GetAll(List<string> output)
        {
            output = Data.InOrderTraversal().ToList();
        }
    }
}
