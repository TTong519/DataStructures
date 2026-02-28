using DataStructures.Trees;
using System.Text;
namespace DataStructuresTests;

[TestClass]
public class BurstTrieTests
{
    [TestMethod]
    [DataRow(43374259)]
    [DataRow(78347520)]
    [DataRow(24910245)]
    [DataRow(62805627)]
    [DataRow(85357439)]
    [DataRow(37045568)]
    public void BurstTrieTest(int seed)
    {
        Random random = new Random(seed);
        BurstTrie trie = new BurstTrie(2);
        List<string> words = new List<string>();
        for (int i = 0; i < 1000; i++)
        {
            string word = "";
            for (int j = 0; j < random.Next(1, 10); j++)
            {
                word += (char)('a' + random.Next(0, 26));
            }
            trie.Insert(word);
            words.Add(word);
        }
        Assert.AreEqual(1000, trie.Count);
        foreach (var word in words)
        {
            List<string> result = trie.Search(word);
            Assert.IsTrue(result.Contains(word));
        }
        words.Sort();
        CollectionAssert.AreEqual(words, trie.GetAll());
        int temp = 1;
        while (temp < words.Count)
        {
            string word = words[random.Next(0, words.Count)];
            Assert.IsTrue(trie.Remove(word));
            words.Remove(word);
            temp++;
        }
    }

    [TestMethod]
    public void DuplicateTest()
    { 
        BurstTrie  burstTrie = new BurstTrie(10);
        for (int j = 1; j < 1001; j++)
        {
            StringBuilder word = new();
            for (int i = 0; i < j; i++)
            {
                word.Append("a");
            }
            burstTrie.Insert(word.ToString());
        }
        Assert.AreEqual(1000, burstTrie.Count);
    }
}
