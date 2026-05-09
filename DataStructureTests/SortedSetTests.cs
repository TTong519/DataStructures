using DataStructures.Lists;
using DataStructures.Trees;
namespace DataStructuresTests;

[TestClass]
public class SortedSetTests
{
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void InsertTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        CollectionAssert.AreEqual(list, set.ToList());
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void InsertRangeTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            list.Add(rand.Next());
        }
        set.AddRange(list);
        list.Sort();
        CollectionAssert.AreEqual(list, set.ToList());
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void CeilingTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        for (int i = 0; i < 100; i++)
        {
            int temp = rand.Next();
            int ceiling = set.Ceiling(temp);
            int expectedCeiling = list.Where(x => x >= temp).FirstOrDefault();
            Assert.AreEqual(expectedCeiling, ceiling);
        }
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void ClearTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        set.Clear();
        list.Clear();
        CollectionAssert.AreEqual(list, set.ToList());
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void ContainsTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        for (int i = 0; i < 100; i++)
        {
            int temp = rand.Next();
            bool containsInSet = set.Contains(temp);
            bool containsInList = list.Contains(temp);
            Assert.AreEqual(containsInList, containsInSet);
        }
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void FloorTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        for (int i = 0; i < 100; i++)
        {
            int temp = rand.Next();
            int floor = set.Floor(temp);
            int expectedFloor = list.Where(x => x <= temp).DefaultIfEmpty().Max();
            Assert.AreEqual(expectedFloor, floor);
        }
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void EnumeratorTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        List<int> enumeratedList = new List<int>();
        foreach (int i in set)
        {
            enumeratedList.Add(i);
        }
        CollectionAssert.AreEqual(list, enumeratedList);
        CollectionAssert.AreEqual(list, set.ToList());
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void IntersectionTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set1 = new DataStructures.Lists.SortedSet<int>();
        DataStructures.Lists.SortedSet<int> set2 = new DataStructures.Lists.SortedSet<int>();
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp1 = rand.Next();
            int temp2 = rand.Next();
            set1.Add(temp1);
            set2.Add(temp2);
            list1.Add(temp1);
            list2.Add(temp2);
        }
        list1.Sort();
        list2.Sort();
        var intersectionSet = set1.Intersection(set2);
        var expectedIntersection = list1.Intersect(list2).ToList();
        CollectionAssert.AreEqual(expectedIntersection, intersectionSet.ToList());
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void MaxTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        int maxInSet = set.Max();
        int maxInList = list.Max();
        Assert.AreEqual(maxInList, maxInSet);
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void MinTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        int minInSet = set.Min();
        int minInList = list.Min();
        Assert.AreEqual(minInList, minInSet);
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void RemoveTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        for (int i = 0; i < list.Count; i += 0)
        {
            int toRomove = list[rand.Next(0, list.Count)];
            list.Remove(toRomove);
            set.Remove(toRomove);
            list.Sort();
            CollectionAssert.AreEqual(list, set.ToList());
        }
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void UnionTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set1 = new DataStructures.Lists.SortedSet<int>();
        DataStructures.Lists.SortedSet<int> set2 = new DataStructures.Lists.SortedSet<int>();
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp1 = rand.Next();
            int temp2 = rand.Next();
            set1.Add(temp1);
            set2.Add(temp2);
            list1.Add(temp1);
            list2.Add(temp2);
        }
        list1.Sort();
        list2.Sort();
        var unionSet = set1.Union(set2).ToList();
        var expectedUnion = list1.Union(list2).ToList();
        expectedUnion.Sort();
        CollectionAssert.AreEqual(expectedUnion, unionSet);
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void ToListTest(int seed)
    {
        DataStructures.Lists.SortedSet<int> set = new DataStructures.Lists.SortedSet<int>();
        List<int> list = new List<int>();
        Random rand = new Random(seed);
        for (int i = 0; i < rand.Next(1000, 2000); i++)
        {
            int temp = rand.Next();
            set.Add(temp);
            list.Add(temp);
        }
        list.Sort();
        CollectionAssert.AreEqual(list, set.ToList());
    }
}
