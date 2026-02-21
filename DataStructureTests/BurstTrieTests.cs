using DataStructures.Trees;
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
            for (int j = 0; j < random.Next(1, 100000); j++)
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
    }
}
