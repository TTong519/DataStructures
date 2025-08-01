namespace DataStructuresTests;
using DataStructures.Trees;

[TestClass]
public class SkipListTest
{
    class Cat : IComparable<Cat>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(Cat? other)
        {
            if (other == null) return 1;
            return Age.CompareTo(other.Age);
        }
    }
        
    [TestMethod]
    [DataRow(1)]
    
    public void InsertTest(int seed)
    {
        SkipList<Cat> catList =
        [
            new Cat { Name = "Whiskers", Age = 3 },
            new Cat { Name = "Mittens", Age = 5 },
            new Cat { Name = "Shadow", Age = 1 },
            new Cat { Name = "Simba", Age = 4 },
            new Cat { Name = "Luna", Age = 1 },
            new Cat { Name = "Bella", Age = 3 },
            new Cat { Name = "Oliver", Age = 7 },
            new Cat { Name = "Leo", Age = 5 },
            new Cat { Name = "Chloe", Age = 1 },
        ];

       // catList.Remove(new Cat() { Name = "Alex", Age = 1});

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
