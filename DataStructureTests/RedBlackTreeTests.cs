using DataStructures.Trees;
using static DataStructures.Trees.RedBlackTreeNode<int>;
namespace DataStructuresTests;

[TestClass]
public class RedBlackTreeTests
{
    private bool areRedsTouching(LeftLeaningRedBlackTree<int> tree)
    {
        if (tree.Root == null)
            return false;
        var queue = new Queue<RedBlackTreeNode<int>>();
        queue.Enqueue(tree.Root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (IsRed(node))
            {
                if (IsRed(node.Left) || IsRed(node.Right)) return true;
            }
            if (node.Left != null)
                queue.Enqueue(node.Left);
            if (node.Right != null)
                queue.Enqueue(node.Right);
        }
        return false;
    }
    private bool isLeftLeaningOrBalanced(LeftLeaningRedBlackTree<int> tree)
    {
        if (tree.Root == null)
            return true;
        var queue = new Queue<RedBlackTreeNode<int>>();
        queue.Enqueue(tree.Root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (IsRed(node.Right)) return false;
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
        }
        return true;
    }
    [TestMethod]
    [DataRow(432729379)]
    [DataRow(493953605)]
    [DataRow(279920844)]
    [DataRow(111516869)]
    [DataRow(460235788)]
    [DataRow(528813664)]
    public void InsertTest(int seed)
    {
        Random rand = new(seed);
        LeftLeaningRedBlackTree<int> tree = new();
        for (int i = 0; i < 1000; i++)
        {
            tree.Insert(rand.Next());
        }
        Assert.IsFalse(areRedsTouching(tree));
        Assert.IsTrue(isLeftLeaningOrBalanced(tree));
        Assert.IsFalse(tree.Root != null && tree.Root.isRed);
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
        Random rand = new(seed);
        LeftLeaningRedBlackTree<int> tree = new();
        List<int> values = new();
        for (int i = 0; i < 1000; i++)
        {
            int toInsert = rand.Next();
            tree.Insert(toInsert);
            values.Add(toInsert);
        }
        foreach (int n in values)
        {
            Assert.IsTrue(tree.Contains(n));
        }
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
        Random rand = new(seed);
        LeftLeaningRedBlackTree<int> tree = new();
        List<int> values = new();
        for (int i = 0; i < 1000; i++)
        {
            int toInsert = rand.Next();
            tree.Insert(toInsert);
            values.Add(toInsert);
        }
        for(int i = 0; i < 1000; i++)
        {
            int toRemove = values[rand.Next(values.Count)];
            tree.Remove(toRemove);
            values.Remove(toRemove);
            Assert.IsFalse(areRedsTouching(tree));
            Assert.IsTrue(isLeftLeaningOrBalanced(tree));
            Assert.IsFalse(tree.Root != null && tree.Root.isRed);
            Assert.AreEqual(tree.Contains(toRemove), values.Contains(toRemove));
            foreach (int n in values)
            {
                Assert.IsTrue(tree.Contains(n));
            }
        }
    }
}
