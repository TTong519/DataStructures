using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    internal class InternalNode : BurstNode
    {
        public BurstNode[] children;
        int count;
        public override int Count => count;
        public InternalNode(BurstTrie parent) : base(parent)
        {
            children = new BurstNode[27];
            count = 0;
        }

        public override BurstNode Insert(string value, int index)
        {
            char c = value[0];
            int childIndex = c - 'a';
            if (childIndex < 0 || childIndex > 25)
            {
                throw new ArgumentException("Value must be a word only containing lowercase letters.");
            }
            if (children[childIndex] == null)
            {
                children[childIndex] = new ContainerNode(ParentTrie);
                children[childIndex].Insert(value, index + 1);
                count++;
                return this;
            }
            else
            {
                BurstNode newChild = children[childIndex].Insert(value, index + 1);
                children[childIndex] = newChild;
                count++;
                return this;
            }
        }

        public override BurstNode Remove(string value, int index, out bool success)
        {
            throw new NotImplementedException();
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
