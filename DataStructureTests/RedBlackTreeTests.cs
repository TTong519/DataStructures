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
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(4)]
    [DataRow(5)]
    public void InsertTest(int seed)
    {
        Random rand = new(seed);
        LeftLeaningRedBlackTree<int> tree = new();
        for (int i = 0; i < 1000; i++)
        {
            tree.Insert(rand.Next(100000));
        }
        Assert.IsFalse(areRedsTouching(tree));
        Assert.IsTrue(isLeftLeaningOrBalanced(tree));
        Assert.IsFalse(tree.Root != null && tree.Root.isRed);
    }
}
