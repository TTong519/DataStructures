using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class BloomFilter<T>
    {
        private bool[] data;
        public List<Func<T, int>> hashFuncs { get; private set; } = null;
        public int Count { get; private set; }
        public BloomFilter(int cap = 1000)
        {
            data = new bool[cap];
            Count = 0;
        }

        public void LoadHashFunc(List<Func<T, int>> hashFuncs)
        {
            if (Count != 0) throw new Exception();
            this.hashFuncs = hashFuncs;
        }

        public void Insert(T item)
        {
            Count++;
            if (hashFuncs == null) throw new Exception("hash functions not loaded");
            if (Count > data.Length) throw new OutOfMemoryException("capacity reached");
            foreach (var func in hashFuncs)
            {
                data[func(item) % data.Length] = true;
            }
        }

        public bool ProbablyContains(T item)
        {
            foreach (var func in hashFuncs)
            {
                if (!data[func(item) % data.Length]) return false;
            }
            return true;
        }
    }
}
