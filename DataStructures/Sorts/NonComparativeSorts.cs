using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace DataStructures.Sorts
{
    public static class NonComparativeSorts
    {
        public static List<int> CountingSort(List<int> toSort)
        {
            int maxValue = toSort.Max();

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
            int bucketSize = (max - min) / buckets.Length;
            foreach (var item in items)
            {
                int bucketIndex = (keySelector(item) - min) / bucketSize;

                if (bucketIndex == buckets.Length) bucketIndex -= 1;

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
        public static void RadixSort<T>(ref List<T> data, Func<T, int> keySelector)
        {
            List<T>[] buckets = new List<T>[10];
            Dictionary<T, int> itemKeys = new();
            Dictionary<T, int> keyDigits = new();
            foreach (var item in data)
            {
                itemKeys[item] = keySelector(item);
            }
            int min = itemKeys.Values.Min();
            int max = itemKeys.Values.Max();
            int maxDigits = max.ToString().Length;
            for(int digitPlace = 0; digitPlace < maxDigits; digitPlace++)
            {
                foreach (var item in data)
                {
                    int key = itemKeys[item];
                    int digit = ((int)Math.Floor(key / Math.Pow(10, digitPlace)) % 10);
                    keyDigits[item] = digit;
                }
                buckets = new List<T>[10];
                for(int i = data.Count; i > 0; i--)
                {
                    var item = data[i - 1];
                    int digit = keyDigits[item];
                    if (buckets[digit] == null)
                    {
                        buckets[digit] = new List<T>();
                    }
                    buckets[digit].Insert(0, item);
                }
                foreach (var bucket in buckets)
                {
                    if (bucket == null)
                    {
                        buckets[Array.IndexOf(buckets, bucket)] = new List<T>();
                    }
                }
                List<T> sorted = new List<T>();
                for(int i = 0; i < buckets.Length; i++)
                {
                    for(int j = 0; j < buckets[i].Count; j++)
                    {
                        sorted.Add(buckets[i][j]);
                    }
                }
                data = sorted.ToList();
            }
        }
    }
}
