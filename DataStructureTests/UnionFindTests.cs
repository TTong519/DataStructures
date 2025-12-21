namespace DataStructuresTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Trees;

[TestClass]
public class UnionFindTests
{
    [TestMethod]
    [DataRow(34856834)]
    [DataRow(93459375)]
    [DataRow(32942374)]
    [DataRow(84394574)]
    [DataRow(39566493)]
    [DataRow(45638847)]
    public void QuickFindTest(int seed)
    {
        Random rand = new Random(seed);
        var uf = new QuickFind<int>();
        int size = rand.Next(30000, 50000);
        List<int> values = new();
        int numOfSets = rand.Next(2, size / 10);
        List<int>[] sets = new List<int>[numOfSets];
        for (int i = 0; i < size; i++)
        {
            int val = rand.Next();
            while(values.Contains(val))
            {
                val = rand.Next();
            }
            uf.Add(val);
            values.Add(val);
        }
        var valuesCopy = new List<int>(values);
        for (int i = 0; i < numOfSets; i++)
        {
            sets[i] = new List<int>();
            int setSize = rand.Next(1, size / numOfSets);
            for (int j = 0; j < setSize; j++)
            {
                int index = rand.Next(valuesCopy.Count);
                int val = valuesCopy[index];
                sets[i].Add(val);
                valuesCopy.RemoveAt(index);
            }
            for (int j = 1; j < sets[i].Count; j++)
            {
                uf.Union(sets[i][0], sets[i][j]);
            }
        }
        List<List<int>> ufSets = new();
        foreach (var val in values)
        {
            int set = uf.Find(val);
            var existingSet = ufSets.FirstOrDefault(s => uf.Find(s[0]) == set);
            if (existingSet != null)
            {
                if (!existingSet.Contains(val))
                {
                    existingSet.Add(val);
                }
            }
            else
            {
                ufSets.Add(new List<int> { val });
            }
        }
        foreach (var set in sets)
        {
            var ufSet = ufSets.FirstOrDefault(s => s.Contains(set[0]));
            Assert.IsNotNull(ufSet, "Set not found in union-find structure.");
            foreach (var val in set)
            {
                Assert.IsTrue(ufSet.Contains(val), "Value missing in union-find set.");
            }
        }
    }
    [TestMethod]
    [DataRow(34856834)]
    [DataRow(93459375)]
    [DataRow(32942374)]
    [DataRow(84394574)]
    [DataRow(39566493)]
    [DataRow(45638847)]
    public void QuickUnionTest(int seed)
    {
        Random rand = new Random(seed);
        var uf = new QuickUnion<int>();
        int size = rand.Next(30000, 50000);
        List<int> values = new();
        int numOfSets = rand.Next(2, size / 10);
        List<int>[] sets = new List<int>[numOfSets];
        for (int i = 0; i < size; i++)
        {
            int val = rand.Next();
            while (values.Contains(val))
            {
                val = rand.Next();
            }
            uf.Add(val);
            values.Add(val);
        }
        var valuesCopy = new List<int>(values);
        for (int i = 0; i < numOfSets; i++)
        {
            sets[i] = new List<int>();
            int setSize = rand.Next(1, size / numOfSets);
            for (int j = 0; j < setSize; j++)
            {
                int index = rand.Next(valuesCopy.Count);
                int val = valuesCopy[index];
                sets[i].Add(val);
                valuesCopy.RemoveAt(index);
            }
            for (int j = 1; j < sets[i].Count; j++)
            {
                uf.Union(sets[i][0], sets[i][j]);
            }
        }
        List<List<int>> ufSets = new();
        foreach (var val in values)
        {
            int set = uf.Find(val);
            var existingSet = ufSets.FirstOrDefault(s => uf.Find(s[0]) == set);
            if (existingSet != null)
            {
                if (!existingSet.Contains(val))
                {
                    existingSet.Add(val);
                }
            }
            else
            {
                ufSets.Add(new List<int> { val });
            }
        }
        foreach (var set in sets)
        {
            var ufSet = ufSets.FirstOrDefault(s => s.Contains(set[0]));
            Assert.IsNotNull(ufSet, "Set not found in union-find structure.");
            foreach (var val in set)
            {
                Assert.IsTrue(ufSet.Contains(val), "Value missing in union-find set.");
            }
        }
    }
}
