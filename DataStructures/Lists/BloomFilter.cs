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
        public Func<T, int> hashFuncOne { get; private set; } = null;
        public Func<T, int> hashFuncTwo { get; private set; } = null;
        public Func<T, int> hashFuncThree { get; private set; } = null;
        public int Count { get; private set; }
        public BloomFilter(int cap = 1000)
        {
            data = new bool[cap];
            Count = 0;
        }

        public void LoadHashFunc(Func<T, int> hashFuncOne, Func<T, int> hashFuncTwo, Func<T, int> hashFuncThree)
        {
            if (Count != 0) throw new Exception();
            this.hashFuncOne = hashFuncOne;
            this.hashFuncTwo = hashFuncTwo;
            this.hashFuncThree = hashFuncThree;
        }

        public void Insert(T item)
        {
            Count++;
            if (hashFuncOne == null || hashFuncTwo == null || hashFuncThree == null) throw new InvalidOperationException("Hash functions must be loaded before inserting items.");
            if (Count >= data.Length) throw new OutOfMemoryException("capacity reached");
            int hash1 = hashFuncOne(item) % data.Length;
            int hash2 = hashFuncTwo(item) % data.Length;
            int hash3 = hashFuncThree(item) % data.Length;
            data[Math.Abs(hash1)] = true;
            data[Math.Abs(hash2)] = true;
            data[Math.Abs(hash3)] = true;
        }

        public bool ProbablyContains(T item)
        {
            return data[hashFuncOne(item) % data.Length] && data[hashFuncTwo(item) % data.Length] && data[hashFuncThree(item) % data.Length];
        }
    }
}
