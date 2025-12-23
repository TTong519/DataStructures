namespace DataStructuresTests;
using DataStructures.Lists;

[TestClass]
public class BloomFilterTest
{
    [TestMethod]
    public void bloomFilterTest(int seed)
    {
        Random rand = new Random(seed);
        int cap = rand.Next(100, 500);
        BloomFilter<int> filter = new(cap);
        List<int> inserted = new();
        List<int> notInserted = new();
        Dictionary<int, bool> expectedResults = new();
        filter.LoadHashFunc(x => x.GetHashCode(), x => (x.GetHashCode() * rand.Next()) + rand.Next(), x => (x.GetHashCode() * rand.Next()) + rand.Next());
        for(int i = 0; i < cap; i++)
        {
            inserted.Add(rand.Next());
            filter.Insert(inserted[inserted.Count - 1]);
        }
        for(int i = 0; i < inserted.Count; i++)
        {
            int temp = rand.Next();
            while(inserted.Contains(temp))
            {
                temp = rand.Next();
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
                if(expectedResults.ContainsKey(item))
                {
                    expectedResults[item] = expectedResults[item] || ((filter.hashFuncOne(item) % cap == filter.hashFuncOne(temp) % cap) && (filter.hashFuncTwo(item) % cap == filter.hashFuncTwo(temp) % cap) && (filter.hashFuncThree(item) % cap == filter.hashFuncThree(temp) % cap));
                }
            }
        }
        foreach(var item in notInserted)
        {
            Assert.AreEqual(expectedResults.ContainsKey(item) ? expectedResults[item] : false, filter.ProbablyContains(item));
        }
    }
}
