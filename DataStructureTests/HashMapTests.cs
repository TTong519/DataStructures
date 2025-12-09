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
        Assert.IsTrue(map.Count == vals.Count);
    }
    [TestMethod]
    [DataRow(32345234)]
    [DataRow(43234544)]
    [DataRow(56356354)]
    [DataRow(76723457)]
    [DataRow(45634563)]
    [DataRow(45635664)]
    public void RemoveTests(int seed)
    {
        HashMap<int, int> map = new();
        Random rand = new Random(seed);
        List<int> vals = new List<int>();
        int count = rand.Next(1000);
        for (int i = 0; i < count; i++)
        {
            var toAdd = rand.Next();
            map.Add(toAdd, toAdd);
            vals.Add(toAdd);
        }
        for(int i = 0; i < map.Count;)
        {
            int temp = vals[0];
            vals.Remove(temp);
            map.Remove(temp);
            CollectionAssert.AreEquivalent(map.Values.ToList(), vals);
            Assert.AreEqual(map.Count, vals.Count);
        }
        Assert.IsTrue(map.Count == 0);
    }
    [TestMethod]
    [DataRow(32345234)]
    [DataRow(43234544)]
    [DataRow(56356354)]
    [DataRow(76723457)]
    [DataRow(45634563)]
    [DataRow(45635664)]
    public void IndexerTests(int seed)
    {
        HashMap<int, int> map = new();
        Random rand = new Random(seed);
        List<int> vals = new List<int>();
        int count = rand.Next(1000);
        for (int i = 0; i < count; i++)
        {
            var toAdd = rand.Next();
            map.Add(toAdd, toAdd);
            vals.Add(toAdd);
        }
        List<int> returnedVals = new();
        for(int i = 0; i < map.Count; i++)
        {
            var key = vals[i];
            var val = map[key];
            returnedVals.Add(val);
        }
        returnedVals.Sort();
        vals.Sort();
        CollectionAssert.AreEquivalent(returnedVals, vals);
    }
}
