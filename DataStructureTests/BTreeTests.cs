namespace DataStructuresTests;

using DataStructures.Trees;
[TestClass]
public class BTreeTests
{
    [TestMethod]
    [DataRow(129561304)]
    [DataRow(272417955)]
    [DataRow(652701558)]
    [DataRow(652701558, 10)]
    public void BTreeTest(int seed, int length = -1)
    {
        Random rand = new(seed);
        BTree<int> tree = new();
        HashSet<int> values = new();
        int len;
        if (length == -1) len = rand.Next(500, 750);
        else len = length;
        while (values.Count < len)
        {
            int value = rand.Next(1000);
            values.Add(value);
        }
        foreach (int value in values)
        {
            tree.Insert(value);
        }
        foreach (int value in values)
        {
            Assert.IsTrue(tree.Contains(value));
        }
    }
}
