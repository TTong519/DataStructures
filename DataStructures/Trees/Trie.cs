using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareAMFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class Trie
    {
        public TrieNode Root { get; private set; }
        public Trie()
        {
            Root = new TrieNode('\0');
        }
        public void Clear()
        {
            Root = new TrieNode('\0');
        }
        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word)) return;
            TrieNode currentNode = Root;
            foreach (char letter in word)
            {
                if (!currentNode.Children.ContainsKey(letter))
                {
                    currentNode.Children[letter] = new TrieNode(letter);
                }
                currentNode = currentNode.Children[letter];
            }
            currentNode.IsWord = true;
        }

        private TrieNode SearchNode(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) return null;
            TrieNode currentNode = Root;
            foreach (char letter in prefix)
            {
                if (!currentNode.Children.ContainsKey(letter))
                {
                    return null;
                }
                currentNode = currentNode.Children[letter];
            }
            return currentNode;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrEmpty(word)) return false;
            TrieNode node = SearchNode(word);
            return node != null && node.IsWord;
        }
        private void GetAllWordsFromNode(TrieNode node, string currentPrefix, List<string> results)
        {
            if (node.IsWord)
            {
                results.Add(currentPrefix);
            }
            foreach (var child in node.Children)
            {
                GetAllWordsFromNode(child.Value, currentPrefix + child.Key, results);
            }
        }
        public List<string> GetAllMatchingPrefix(string prefix)
        {
            if(string.IsNullOrEmpty(prefix)) return new List<string>();
            TrieNode startNode = SearchNode(prefix);
            if (startNode == null) return new List<string>();
            List<string> results = new List<string>();
            GetAllWordsFromNode(startNode, prefix, results);
            return results;
        }
        private bool RemoveHelper(TrieNode current,string word, int index)
        {
            if(index >= word.Length)
            {
                current.IsWord = false;
                return current.Children.Count == 0;
            }
            TrieNode childNode = current.Children[word[index]];
            bool shouldDeleteChild = RemoveHelper(childNode, word, index + 1);   
            if (shouldDeleteChild)
            {
                current.Children.Remove(word[index]);
                return current.Children.Count == 0;
            }
            return false;
        }
        public bool Remove(string word) 
        {
            if (string.IsNullOrEmpty(word)) return false;
            if(!Contains(word)) return false;
            RemoveHelper(Root, word, 0);
            return true;
        }
    }
}
