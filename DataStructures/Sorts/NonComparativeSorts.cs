using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorts
{
    public static class NonComparativeSorts
    {
        public static List<int> CountingSort(List<int> toSort, int maxValue)
        {
            List<int> counts = new(maxValue + 1);
            for (int i = 0; i <= maxValue; i++)
            {
                counts.Add(0);
            }
            foreach (var item in toSort)
            {
                counts[item]++;
            }
            List<int> sorted = new();
            for (int i = 0; i < counts.Count; i++)
            {
                for (int j = 0; j < counts[i]; j++)
                {
                    sorted.Add(i);
                }
            }
            return sorted;
        }
        public static void BucketSort<T>(List<T> items, Func<T, int> keySelector)
        {
            List<T>[] buckets = new List<T>[(int)Math.Sqrt(items.Count)];
            Dictionary<T, int> itemKeys = new();
            foreach (var item in items)
            {
                itemKeys[item] = keySelector(item);
            }
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<T>();
            }
            int min = itemKeys.Values.Min();
            int max = itemKeys.Values.Max();
            foreach (var item in items)
            {
                int bucketIndex = (keySelector(item) - min) / buckets.Length;
                buckets[bucketIndex].Add(item);
            }
            for(int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = BasicSorts.InsertionSort(buckets[i].ToArray(),Comparer<T>.Create((item, other) => itemKeys[item].CompareTo(itemKeys[other]))).ToList();
            }
            items.Clear();
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    items.Add(buckets[i][j]);
                }
            }
        }
    }
}
