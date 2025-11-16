using DataStructures.Sorts;
namespace DataStructuresTests;

[TestClass]
public class NonComparativeSortTests
{
    [TestMethod]
    [DataRow(423841283)]
    [DataRow(342675097)]
    [DataRow(320934237)]
    [DataRow(430529847)]
    public void CountingSortTest(int seed)
    {
        List<int> toSort = new();
        Random random = new(seed);
        for (int i = 0; i < random.Next(1000); i++)
        {
            toSort.Add(random.Next(0, 500));
        }
        toSort = NonComparativeSorts.CountingSort(toSort);
        List<int> Sorted = new(toSort);
        Sorted.Sort();
        CollectionAssert.AreEqual(Sorted, toSort);
    }
    [TestMethod]
    [DataRow(423841283)]
    [DataRow(342675097)]
    [DataRow(320934237)]
    [DataRow(430529847)]
    [DataRow(194823709)]
    [DataRow(230294582)]
    public void BucketSortTest(int seed)
    {
        List<int> toSort = new();
        Random random = new(seed);
        for (int i = 0; i < random.Next(1000); i++)
        {
            toSort.Add(random.Next(0, 500));
        }
        NonComparativeSorts.BucketSort(toSort, item => item);
        List<int> Sorted = new(toSort);
        Sorted.Sort();
        CollectionAssert.AreEqual(Sorted, toSort);
    }
    [TestMethod]
    [DataRow(423841283)]
    [DataRow(342675097)]
    [DataRow(320934237)]
    [DataRow(430529847)]
    [DataRow(194823709)]
    [DataRow(230294582)]
    public void RadixSortTest(int seed)
    {
        List<int> toSort = new();
        Random random = new(seed);
        for (int i = 0; i < random.Next(1000); i++)
        {
            toSort.Add(random.Next(0, 500));
        }
        NonComparativeSorts.RadixSort(ref toSort, item => item);
        List<int> Sorted = new(toSort);
        Sorted.Sort();
        CollectionAssert.AreEqual(Sorted, toSort);
    }
}
