using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorts.BasicSorts
{
    static class BasicSorts
    {
        public static T[] BubbleSort<T>(this T[] array) where T : IComparable<T>
        {
            bool abool = true;
            while (abool)
            {
                abool = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    T current = array[i];
                    T next = array[i + 1];
                    if (current.CompareTo(next) > 0)
                    {
                        array[i] = next;
                        array[i + 1] = current;
                        abool = true;
                    }
                }
            }
            return array;
        }

        private static int FindLeast<T>(this T[] array, int startIndex) where T : IComparable<T>
        {
            int minIndex = 0;
            for (int i = startIndex; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }
        public static T[] SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = FindLeast(array, i);
                T temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
            return array;
        }

        public static T[] Swap<T>(T[] array, int indexa, int indexb) where T : IComparable<T>
        {
            T temp = array[indexa];
            array[indexa] = array[indexb];
            array[indexb] = temp;
            return array;
        }
        public static T[] InsertionSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        Swap(array, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            SortTest(BubbleSort);
            SortTest(SelectionSort);
            SortTest(InsertionSort);
            int[] array = [23, 49, 234, 54, 46, 743, 453];
            //debugger(SelectionSort, array);
        }

        public static void SortTest(Func<double[], double[]> sort)
        {
            Random randy = new Random();
            for (int i = 0; i < 100; i++)
            {
                double[] ints = new double[100];
                for (int j = 0; j < 100; j++)
                {
                    ints[j] = randy.NextDouble();
                }

                sort(ints);

                for (int j = 0; j < 99; j++)
                {
                    if (ints[j] > ints[j + 1])
                    {
                        throw new Exception("Sort No Work");
                    }
                }
            }
        }
        public static void debugger(Func<int[], int[]> sort, int[] array)
        {
            array = sort(array);
            foreach (int var in array)
            {
                Console.WriteLine(var);
            }
        }

    }
}
