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
            int len = random.Next(2000000);
            for(int i = 0; i < len; i++)
            {
                input.Add(random.Next());
            }
            input.Sort();
            List<int> output = MergeSort(input);
            bool isFailed = !input.SequenceEqual(output);
            Assert.IsFalse(isFailed);
        }
    }
}