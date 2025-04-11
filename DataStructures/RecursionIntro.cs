using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RecursionIntro
    {
        public static int ArraySum(int[] array, int index)
        {
            if (array.Length == 0) return 0;
            if (index == 0) return array[0];
            return ArraySum(array, index - 1) + array[index];
        }
        public static void CountDown(int num)
        {
            if (num == 0) return;
            Console.WriteLine(num);
            CountDown(num - 1);
        }
    }
}
