using DataStructures.Lists;
namespace DataStructuresTests;

[TestClass]
public class HashMapTests
{
    [TestMethod]
    [DataRow(32345234)]
    [DataRow(43234544)]
    [DataRow(56356354)]
    [DataRow(76723457)]
    [DataRow(45634563)]
    [DataRow(45635664)]
    public void AddTests(int seed)
    {
        HashMap<int, int> map = new();
        Random rand = new Random(seed);
        List<int> vals = new List<int>();
        int count = rand.Next(1000);
        for(int i = 0; i < count; i++)
        {
            var toAdd = rand.Next();
            map.Add(toAdd, toAdd);
            vals.Add(toAdd);
        }
        List<int> returnedVals = new();
        foreach(var i in map)
        {
            returnedVals.Add(i.Value);
        }
        returnedVals.Sort();
        vals.Sort();
        CollectionAssert.AreEquivalent(returnedVals, vals);
    }
}
