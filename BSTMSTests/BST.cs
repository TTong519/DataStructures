﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Trees;

namespace DataStructuresTests
{
    [TestClass]
    public class BSTTests
    {
        [TestMethod]
        [DataRow(834047848)]
        [DataRow(300173266)]
        [DataRow(1241957440)]
        [DataRow(36412799)]
        [DataRow(50322915)]
        [DataRow(25004)]
        public void InOrderTest(int seed)
        {
            //make unit test for testing your BST traveral
            Random random = new();
            Queue<int> results = new();
            List<int> trialresults = new();
            BinarySearchTree<int> ints = new();
            for (int j = 0; j < 1000000; j++)
            {
                ints.Insert(random.Next(seed));
            }
            results = ints.InOrderTraversal();
            ints.InOrderTraversalRecursive(trialresults, ints.Root);
            bool isFailed = !results.SequenceEqual(trialresults);
            Assert.IsFalse(isFailed);
        }
    }
}
