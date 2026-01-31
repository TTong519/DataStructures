using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    // Polymorphic base for the two types of nodes in the Trie
    public abstract class BurstNode
    {
        // The Trie this node belongs to
        internal BurstTrie ParentTrie;
        // The amount of values contained in this node
        public abstract int Count { get; }
        // Creates the Node referencing its parent-trie
        protected BurstNode(BurstTrie parent) => ParentTrie = parent;

        // Abstract recursive insertion function, returns replacement value for back-propagation 
        public abstract BurstNode Insert(string value, int index);
        // Abstract recursive deletion function, returns replacement value for back-propagation    
        public abstract BurstNode? Remove(string value, int index, out bool success);
        // Get a Node containing a defined prefix
        public abstract BurstNode? Search(string prefix, int index);
        // Gets all items in order recursively
        internal abstract void GetAll(List<string> output);
    }
}
