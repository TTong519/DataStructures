using DaraStructures.Trees;
using DataStructures.Trees;

namespace DataStructuresTests;

[TestClass]
public class AVLTreeTests
{
    public int AVLInsertTestHelper(AVLTreeNode<int> currentNode)
    {
        if (currentNode.Left == null && currentNode.Right == null)
        {
            if (currentNode.Height != 1) throw new Exception("oof1");
            return currentNode.Height;
        }
        else if (currentNode.Left == null)
        {
            if (currentNode.Height != AVLInsertTestHelper(currentNode.Right) + 1) throw new Exception("oof2");
            return currentNode.Height;
        }
        else if(currentNode.Right == null)
        {
            if (currentNode.Height != AVLInsertTestHelper(currentNode.Left) + 1) throw new Exception("oof3");
            return currentNode.Height;
        }
        else
        {
            if (currentNode.Height != Math.Max(AVLInsertTestHelper(currentNode.Left), AVLInsertTestHelper(currentNode.Right)) + 1) throw new Exception("oof4");
            return currentNode.Height;
        }
    }
    [TestMethod]
    [DataRow(89435793)]
    [DataRow(89345795)]
    [DataRow(84235270)]
    [DataRow(89442324)]
    [DataRow(28345673)]
    [DataRow(34523648)]
    public void AVLInsertTest(int seed)
    {
        AVLTree<int> tree = new AVLTree<int>();
        Random rand = new Random(seed);
        tree.Insert(rand.Next());
        for (int i = 0; i < rand.Next(1, 30); i++)
        {
            tree.Insert(rand.Next());
        }
        AVLInsertTestHelper(tree.Root);
    }
    [TestMethod]
    [DataRow(89435793)]
    [DataRow(89345795)]
    [DataRow(84235270)]
    [DataRow(89442324)]
    [DataRow(28345673)]
    [DataRow(34523648)]
    public void AVLRemoveTest(int seed)
    {
        AVLTree<int> tree = new AVLTree<int>();
        Random rand = new Random(seed);
        tree.Insert(rand.Next(1, 300));
        int len = rand.Next(1, 30);
        List<int> values = new List<int>();
        for (int i = 0; i < len; i++)
        {
            int j = rand.Next(1, 300);
            tree.Insert(j);
            values.Add(j);
        }
        for (int i = 0; i < len; i++)
        {
            //tree.RemoveRecursive(tree.Root, values[i]);
            AVLInsertTestHelper(tree.Root);
        }
    }
}
