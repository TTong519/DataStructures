namespace DataStructuresTests;
using DataStructures.Trees;

[TestClass]
public class SkipListTest
{
    [TestMethod]
    [DataRow(1)]
    public void InsertTest(int seed)
    {
        SkipList<int> skipList = new SkipList<int>();
        List<int> values = new List<int>();
        Random random = new Random(seed);
        for (int i = 0; i < 10; i++)
        {
            int value = random.Next(1, 101);
            skipList.Insert(value);
            values.Add(value);
        }
        ;
    }
}
