using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class TrieNode
    {
        public char Letter { get; private set; } // The letter of the current node
        public Dictionary<char, TrieNode> Children { get; private set; } // All known continuations from the current letter in the current prefix keyed off their beginning letters
        public bool IsWord { get; set; } // Whether or not the current node is at the end of a word
        public bool IsRoot => Letter == '\0'; // Whether or not the current node is the root node

        public TrieNode(char c, bool isWord = false)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = c;
            IsWord = isWord;
        }
    }
}
