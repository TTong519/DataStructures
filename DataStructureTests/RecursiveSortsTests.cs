using DataStructures.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static DataStructures.Sorts.RecursiveSorts;


namespace DataStructuresTests
{
    [TestClass]
    public class RecursiveSortsTests
    {
        [TestMethod]
        [DataRow(834047848)]
        [DataRow(300173266)]
        [DataRow(1241957440)]
        [DataRow(36412799)]
        [DataRow(50322915)]
        [DataRow(25004)]
        public void MergeSortTests(int seed)
        {
            Random random = new Random(seed);
            List<int> input = new();
            int len = random.Next(10);
            for(int i = 0; i < len; i++)
            {
                input.Add(random.Next());
            }
            List<int> input2 = new(input);
            input.Sort();
            List<int> output = MergeSort(input2);
            bool isFailed = !input.SequenceEqual(output);
            Assert.IsFalse(isFailed);
        }

        [TestMethod]
        [DataRow(834047848)]
        [DataRow(300173266)]
        [DataRow(1241957440)]
        [DataRow(36412799)]
        [DataRow(50322915)]
        [DataRow(25004)]

        public void LomutoQuickSortTests(int seed)
        {
            Random random = new Random(seed);
            List<int> input = new();
            int len = random.Next(10000);
            for (int i = 0; i < len; i++)
            {
                input.Add(random.Next());
            }
            List<int> input2 = new(input);
            input.Sort();
            LomutoQuickSort(input2, 0, input2.Count);
            bool isFailed = !input.SequenceEqual(input2);
            Assert.IsFalse(isFailed);
        }
        [TestMethod]
        [DataRow(36412799)]
        [DataRow(834047848)]
        [DataRow(300173266)]
        [DataRow(1241957440)]
        [DataRow(50322915)]
        [DataRow(25004)]

        public void HoareQuickSortTests(int seed)
        {
            Random random = new Random(seed);
            List<int> input = new();
            int len = random.Next(10);
            for (int i = 0; i < len; i++)
            {
                input.Add(random.Next(10));
            }
            List<int> input2 = new(input);
            input.Sort();
            HoareQuickSort(input2, 0, input2.Count-1);
            bool isFailed = !input.SequenceEqual(input2);
            Assert.IsFalse(isFailed);
        }
    }
}