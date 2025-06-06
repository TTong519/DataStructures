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
            if (currentNode.Height != 1) throw new Exception();
            return currentNode.Height;
        }
        else if (currentNode.Left == null)
        {
            if (currentNode.Height != AVLInsertTestHelper(currentNode.Right) + 1) throw new Exception();
            return currentNode.Height;
        }
        else if(currentNode.Right == null)
        {
            if (currentNode.Height != AVLInsertTestHelper(currentNode.Left) + 1) throw new Exception();
            return currentNode.Height;
        }
        else
        {
            if (currentNode.Height != Math.Max(AVLInsertTestHelper(currentNode.Left), AVLInsertTestHelper(currentNode.Right))) throw new Exception();
            return currentNode.Height;
        }
    }
    [TestMethod]
    [DataRow(89435793)]
    public void AVLInsertTest(int seed)
    {
        AVLTree<int> tree = new AVLTree<int>();
        Random rand = new Random();
        for (int i = 0; i < rand.Next(1, 500); i++)
        {
            tree.Insert(rand.Next(), tree.Root);
        }
        AVLInsertTestHelper(tree.Root);
    }
}
