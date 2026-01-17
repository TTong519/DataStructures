using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class HuffmanNode
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
        public HuffmanNode(char character, int frequency)
        {
            Left = null;
            Right = null;
            Character = character;
            Frequency = frequency;
        }
    }
    Dictionary<char, byte> generateCodes(HuffmanNode node, byte startCode)
    {
        Dictionary<char, byte> codes = new();
        if (node.Character != '\0')
        {
            codes.Add(node.Character, startCode);
            return codes;
        }
        if (node.Left != null)
        {
            
        }
    }
    public class HuffmanEncoder
    {
        public (byte[] result, HuffmanNode root) Encode(string text)
        {
            PriorityQueue<HuffmanNode, int> pq = new();
            Dictionary<char, int> freq = new();
            foreach (char c in text)
            {
                if(!freq.ContainsKey(c))
                {
                    freq.Add(c, 0);
                }
                freq[c]++;
            }
            foreach (var kvp in freq)
            {
                pq.Enqueue(new(kvp.Key, kvp.Value), kvp.Value);
            }
            while(pq.Count > 1)
            {
                HuffmanNode left = pq.Dequeue();
                HuffmanNode right = pq.Dequeue();
                HuffmanNode parent = new('\0', left.Frequency + right.Frequency)
                {
                    Left = left,
                    Right = right
                };
                pq.Enqueue(parent, parent.Frequency);
            }
            HuffmanNode root = pq.Dequeue();
            Dictionary<char, byte> codes = new();
            
        }
        public string Decode(byte[] encodedBytes, Dictionary<char, byte> codes)
        {
            Dictionary<string, char> reverseCodes = new();
            foreach(var kvp in codes)
            {
                reverseCodes.Add(kvp.Value.ToString("B" + ((int)Math.Log2(kvp.Value)).ToString()), kvp.Key);
            }
            StringBuilder encodedString = new();
            foreach(byte b in encodedBytes)
            {
                encodedString.Append(b.ToString("B8"));
            }
            string word = "";
            StringBuilder decodedString = new();
            for (int i = 0; i < encodedString.Length; i++)
            {
                word += encodedString[i];
                if(reverseCodes.ContainsKey(word))
                {
                    decodedString.Append(reverseCodes[word]);
                    word = "";
                }
            }
            return decodedString.ToString();
        }
    }
}
