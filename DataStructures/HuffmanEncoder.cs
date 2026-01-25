using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HuffmanNode
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

    public class HuffmanEncoder
    {
        Dictionary<char, (byte code, int length)> GenerateCodes(HuffmanNode root)
        {
            return helper(root, 0, 0);

            Dictionary<char, (byte code, int length)> helper(HuffmanNode node, byte startCode, int startCodeLength)
            {
                Dictionary<char, (byte code, int length)> codes = new();
                if (node.Character != '\0')
                {
                    codes.Add(node.Character, (startCode, startCodeLength));
                    return codes;
                }
                if (node.Left != null)
                {
                    var temp = helper(node.Left, (byte)(startCode << 1), startCodeLength + 1);
                    foreach (var item in temp)
                    {
                        codes.Add(item.Key, item.Value);
                    }
                }
                if (node.Right != null)
                {
                    var temp = helper(node.Right, (byte)((startCode << 1) | 1), startCodeLength + 1);
                    foreach (var item in temp)
                    {
                        codes.Add(item.Key, item.Value);
                    }
                }
                return codes;
            }
        }


        public (byte[] result, HuffmanNode root, uint length) Encode(string text)
        {
            PriorityQueue<HuffmanNode, int> pq = new();
            Dictionary<char, int> freq = new();
            foreach (char c in text)
            {
                if (!freq.ContainsKey(c))
                {
                    freq.Add(c, 1);
                }
                freq[c]++;
            }
            foreach (var kvp in freq)
            {
                pq.Enqueue(new(kvp.Key, kvp.Value), kvp.Value);
            }
            while (pq.Count > 1)
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
            Dictionary<char, (byte code, int length)> codes = new();
            codes = GenerateCodes(root);

            StringBuilder encodedBuilder = new();

            int poop = 0;
            foreach (char c in text)
            {
                poop++;
                encodedBuilder.Append(codes[c].code.ToString("B" + codes[c].length.ToString()));
            }

            string encodedString = encodedBuilder.ToString();

            List<byte> encodedBytes = new();
            for (int i = 0; i < encodedString.Length; i += 8)
            {
                string byteString = encodedString.Substring(i, Math.Min(8, encodedString.Length - i));
                while (byteString.Length < 8)
                {
                    byteString += "0";
                }
                encodedBytes.Add(Convert.ToByte(byteString, 2));
            }
            return (encodedBytes.ToArray(), root, (uint)encodedString.Length);
        }
        public string Decode(byte[] encodedBytes, HuffmanNode root, uint length)
        {
            StringBuilder encodedString = new();
            foreach (byte b in encodedBytes)
            {
                encodedString.Append(b.ToString("B8"));
            }
            encodedString.Append("0");
            StringBuilder decodedString = new();
            HuffmanNode currentNode = root;
            for (int i = 0; i < (int)length + 1; i++)
            {
                if (encodedString[i] == '0')
                {
                    if (currentNode.Character == '\0') currentNode = currentNode.Left;
                    else
                    {
                        decodedString.Append(currentNode.Character);
                        currentNode = root.Left;
                    }
                }
                else
                {
                    if (currentNode.Character == '\0') currentNode = currentNode.Right;
                    else
                    {
                        decodedString.Append(currentNode.Character);
                        currentNode = root.Right;
                    }
                }
            }
            return decodedString.ToString();
        }
    }
}
