using DaraStructures;
namespace DataStructuresTests;

[TestClass]
public class NonComparativeTests
{
    public List<uint> randList(int seed)
    {
        Random rand = new Random(seed);
        List<uint> list = new List<uint>();
        for(int i = 0; i < rand.Next(500); i++)
        {
            list.Add((uint)rand.Next(1000000000));
        }
        return list;
    }
    [TestMethod]
    [DataRow(747513843)]
    [DataRow(347925703)]
    [DataRow(572934587)]
    [DataRow(543798345)]
    public void CountingTest(int seed)
    {
        var thing = randList(seed);
        var sorted = DataStructures.Sorts.NonComparativeSorts.CountingSort(thing, thing.Max());
        var expected = thing.OrderBy(x => x).ToList();
        for(int i = 0; i < sorted.Count; i++)
        {
            Assert.AreEqual(expected[i], sorted[i]);
        }
    }
}
