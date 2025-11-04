using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorts
{
    public static class NonComparativeSorts
    {
        public static List<uint> CountingSort(List<uint> input, uint maxValue)
        {
            uint[] count = new uint[maxValue + 1];
            foreach (var number in input)
            {
                count[number]++;
            }
            List<uint> sortedList = new List<uint>();
            for (uint i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    sortedList.Add(i);
                }
            }
            return sortedList;
        }
    }
}
