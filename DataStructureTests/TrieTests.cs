namespace DataStructuresTests;

[TestClass]
public class TrieTests
{
    [TestMethod]
    [DataRow]
    public void InsertTest()
    {
        var trie = new DataStructures.Trees.Trie();
        trie.Insert("hello");
        trie.Insert("world");
        trie.Insert("hi");
        Assert.IsTrue(trie.Contains("hello"));
        Assert.IsTrue(trie.Contains("world"));
        Assert.IsTrue(trie.Contains("hi"));
        Assert.IsFalse(trie.Contains("hell"));
        Assert.IsFalse(trie.Contains("helloo"));
    }
}
