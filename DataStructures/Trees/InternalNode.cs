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
            throw new NotImplementedException();
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
