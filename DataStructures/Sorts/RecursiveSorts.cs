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
            int leftIndex = 0;
            int rightIndex = 0;
            List<T> result = new List<T>();
            for(int i = 0; i < toSort.Count; i++)
            {
                if (right.Count <= rightIndex)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if(left.Count <= leftIndex)
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
                else
                {
                    if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
            }
            return result;
        }
        public static void LomutoQuickSort<T>(List<T> toSort, int start, int end) where T : IComparable
        {
            int wall = start;
            int index = start;
            if(end - start < 2)
            {
                return;
            }
            T pivot = toSort[end-1];
            while (index < end)
            {
                if (toSort[index].CompareTo(pivot) < 0)
                {
                    T temp1 = toSort[index];
                    toSort.RemoveAt(index);
                    toSort.Insert(wall, temp1);
                    wall++;
                    index++;
                }
                else
                {
                    index++;
                }
            }
            toSort.RemoveAt(end - 1);
            toSort.Insert(wall, pivot);
            LomutoQuickSort(toSort, start, wall);//no worky
            LomutoQuickSort(toSort, wall + 1, end);
            return;
        }
        public static void HoareQuickSort<T>(List<T> toSort, int start, int end) where T : IComparable
        {
            int LEFT = start;
            int RIGHT = end;
            if (toSort.Count < 2) return;
            T pivot = toSort[start];
            while (LEFT.CompareTo(RIGHT) >= 0)
            {
                while (toSort[LEFT].CompareTo(pivot) < 0)
                {
                    LEFT++;
                }
                while (toSort[RIGHT].CompareTo(pivot) > 0)
                {
                    RIGHT--;
                }
                T temp = toSort[LEFT];
                toSort[LEFT] = toSort[RIGHT];
                toSort[RIGHT] = temp;
            }
            HoareQuickSort<T>(toSort, start, LEFT);
            HoareQuickSort(toSort, RIGHT, end);
        }
    }
}
