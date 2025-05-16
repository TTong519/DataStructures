using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Trees;
namespace DataStructuresTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        [DataRow(7, 5, 2, 8, 1, 92, 0, -100, -7)]
        public void Add(params int[] input)
        {
            HeapTree<int> tree = new HeapTree<int>();
            int fittest = input[0];
            foreach(int i in input)
            {
                tree.Add(i);
                if(i < fittest)
                {
                    fittest = i;
                }
                if(tree.Root != fittest)
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        [DataRow(7, 5, 2, 8, 1, 92, 0, -100, -7)]
        public void Remove(params int[] input)
        {
            HeapTree<int> tree = new HeapTree<int>();
            List<int> removed = new List<int>();
            foreach(int i in input)
            {
                tree.Add(i);
            }
            for(int i = 0; i < tree.Count; i++)
            {
                removed.Add(tree.Pop());
            }
            Array.Sort(input);
            CollectionAssert.AreEqual(input, removed);
        }
        [TestMethod]
        [DataRow(36412799)]
        [DataRow(834047848)]
        [DataRow(300173266)]
        [DataRow(1241957440)]
        [DataRow(50322915)]
        [DataRow(25004)]
        public void Add(int seed)
        {
            Random random = new Random();
            int[] array = new int[random.Next(20, 50)];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }
            Add(array);
        }
    }
}
