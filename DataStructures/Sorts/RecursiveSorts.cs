using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorts
{
    public static class RecursiveSorts
    {
        public static List<T> MergeSort<T>(List<T> toSort) where T : IComparable
        {
            if(toSort.Count < 2) return toSort;
            List<T> left = new List<T>();
            for(int i = 0; i < toSort.Count/2; i++)
            {
                left.Add(toSort[i]);
            }
            List<T> right = new List<T>();
            for(int i = toSort.Count / 2; i < toSort.Count; i++)
            {
                right.Add(toSort[i]);
            }
            left = MergeSort(left);
            right = MergeSort(right);
            int leftindex = 0;
            int rightindex = 0;
            List<T> result = new List<T>();
            for(int i = 0; i < toSort.Count; i++)
            {
                if (right.Count <= rightindex)
                {
                    result.Add(left[leftindex]);
                    leftindex++;
                }
                else if(left.Count <= leftindex)
                {
                    result.Add(right[rightindex]);
                    rightindex++;
                }
                else
                {
                    if (left[leftindex].CompareTo(right[rightindex]) <= 0)
                    {
                        result.Add(left[leftindex]);
                        leftindex++;
                    }
                    else
                    {
                        result.Add(left[leftindex]);
                        rightindex++;
                    }
                }
            }
            return result;
        }
    }
}
