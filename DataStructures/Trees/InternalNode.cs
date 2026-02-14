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
            if (index == value.Length)
            {
                char ca = value[value.Length - 1];
                int childindex = ca - 'a';
                if (childindex < 0 || childindex > 25)
                {
                    throw new ArgumentException("Value must be a word only containing lowercase letters.");
                }
                if (children[0] == null)
                {
                    children[0] = new ContainerNode(ParentTrie);
                    children[0].Insert(value, index + 1);
                    count++;
                    return this;
                }
                else
                {
                    BurstNode newChild = children[0].Insert(value, index + 1);
                    children[0] = newChild;
                    count++;
                    return this;
                }
            }
            char c = value[index];
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
            if (index == value.Length)
            {
                char ca = value[value.Length - 1];
                int childindex = ca - 'a';
                if (childindex < 0 || childindex > 25)
                {
                    throw new ArgumentException("Value must be a word only containing lowercase letters.");
                }
                if (children[0] == null)
                {
                    success = false;
                    return this;
                }
                else
                {
                    BurstNode? newChild = children[0].Remove(value, index + 1, out success);
                    if (success)
                    {
                        children[0] = newChild;
                        count--;
                    }
                    return this;
                }
            }
            char c = value[index];
            int childIndex = c - 'a';
            if (childIndex < 0 || childIndex > 25)
            {
                throw new ArgumentException("Value must be a word only containing lowercase letters.");
            }
            if (children[childIndex] == null)
            {
                success = false;
                return this;
            }
            else
            {
                BurstNode? newChild = children[childIndex].Remove(value, index + 1, out success);
                if (success)
                {
                    children[childIndex] = newChild;
                    count--;
                }
                return this;
            }
        }

        public override BurstNode Search(string prefix, int index)
        {
            char c = prefix[index];
            int childIndex = c - 'a';
            if (childIndex < 0 || childIndex > 25)
            {
                throw new ArgumentException("Prefix must be a word only containing lowercase letters.");
            }
            if (children[childIndex] == null)
            {
                return null;
            }
            else
            {
                return children[childIndex].Search(prefix, index + 1);
            }
        }

        internal override void GetAll(List<string> output)
        {
            foreach (var child in children)
            {
                if (child != null)
                {
                    child.GetAll(output);
                }
            }
        }
    }
}
