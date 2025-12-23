namespace DataStructuresTests;
using DataStructures.Lists;

[TestClass]
public class BloomFilterTest
{
    [TestMethod]
    [DataRow(427423443)]
    [DataRow(739853457)]
    [DataRow(439835745)]
    [DataRow(493857355)]
    [DataRow(238475923)]
    [DataRow(984573298)]
    public void bloomFilterTest(int seed)
    {
        Random rand = new Random(seed);
        int cap = rand.Next(10);
        BloomFilter<int> filter = new(cap);
        List<int> inserted = new();
        List<int> notInserted = new();
        Dictionary<int, bool> expectedResults = new();
        filter.LoadHashFunc(new List<Func<int, int>> { x => x.GetHashCode() });
        for(int i = 0; i < cap; i++)
        {
            inserted.Add(rand.Next(50));
            filter.Insert(inserted[inserted.Count - 1]);
        }
        for(int i = 0; i < inserted.Count; i++)
        {
            int temp = rand.Next(50);
            while(inserted.Contains(temp))
            {
                temp = rand.Next(50);
            }
            notInserted.Add(temp);
        }
        foreach (var item in inserted)
        {
            Assert.IsTrue(filter.ProbablyContains(item));
        }
        foreach(var item in notInserted)
        {
            foreach(var temp in inserted)
            {
                if (expectedResults.ContainsKey(item))
                {
                    bool result = true;
                    foreach(var hashFunc in filter.hashFuncs)
                    {
                        result = result && (hashFunc(item) % cap == hashFunc(temp) % cap);
                    }
                    expectedResults[item] = expectedResults[item] || result;
                }
                else
                {
                    bool result = true;
                    foreach (var hashFunc in filter.hashFuncs)
                    {
                        result = result && (hashFunc(item) % cap == hashFunc(temp) % cap);
                    }
                    expectedResults[item] = result;
                }
            }
        }
        foreach(var item in notInserted)
        {
            Assert.AreEqual(expectedResults.ContainsKey(item) ? expectedResults[item] : false, filter.ProbablyContains(item));
        }
    }
}
