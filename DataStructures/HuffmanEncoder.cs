using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HuffmanEncoder
    {
        public (byte[] result, Dictionary<char, byte> codes) Encode(string text)
        {
            PriorityQueue<char, int> pq = new();
            Dictionary<char, int> freq = new();
            Dictionary<char, byte> codes = new();
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
                pq.Enqueue(kvp.Key, kvp.Value);
            }
            byte code = 0;
            while (pq.Count >= 1)
            {
                var item = pq.Dequeue();
                if(!codes.ContainsKey(item))
                {
                    codes.Add(item, code);
                    code++;
                }
            }
            string encodedString = "";
            List<byte> encodedBytes = new();
            for (int i = 0; i < text.Length; i++)
            {
                encodedString += codes[text[i]].ToString("B" + (codes[text[i]] / 2).ToString());
            }
            for (int i = 0; i < encodedString.Length; i += 8)
            {
                encodedBytes.Add(Convert.ToByte(encodedString.Substring(i, 8), 2));
            }

            return (encodedBytes.ToArray(), codes);
        }
        public string Decode(byte[] encodedBytes, Dictionary<char, byte> codes)
        {
            Dictionary<string, char> reverseCodes = new();
            foreach(var kvp in codes)
            {
                reverseCodes.Add(kvp.Value.ToString("B" + (kvp.Value / 2).ToString()), kvp.Key);
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
