namespace DataStructuresTests;
using DataStructures.Lists;
[TestClass]
public class LRUCacheTests
{
    [TestMethod]
    [DataRow(345638545)]
    [DataRow(234657234)]
    [DataRow(892355754)]
    [DataRow(903498525)]
    [DataRow(345257973)]
    [DataRow(198598236)]
    public void LRUCacheTest(int seed)
    {
        Random rand = new Random(seed);
        int capacity = rand.Next(1, 1000);
        LRUCache<int, int> lruCache = new(capacity);
        Dictionary<int, int> reference = new();
        List<int> keys = new();
        for (int i = 0; i < capacity * 2; i++)
        {
            int key = rand.Next(2000);
            int value = rand.Next();
            lruCache.Put(key, value);
            reference[key] = value;
            if (!keys.Contains(key))
            {
                keys.Add(key);
            }
            if (keys.Count >= capacity)
            {
                keys.RemoveAt(keys.Count - 1);
            }
            //Assert.AreEqual(keys.Count, lruCache.Count);
            List<int> missVals = new List<int>();
            for(int j = 0; j < capacity; j++)
            {
                int val = rand.Next();
                while(missVals.Contains(val) || keys.Contains(val))
                {
                    val = rand.Next();
                }
                missVals.Add(val);
            }
            foreach(int val in missVals)
            {
                Assert.IsFalse(lruCache.TryGet(val, out int cachedValue));
            }
            foreach (var k in keys)
            {
                Assert.IsTrue(lruCache.TryGet(k, out int cachedValue));
                //Assert.AreEqual(reference[k], cachedValue);
            }
        }
    }
}
