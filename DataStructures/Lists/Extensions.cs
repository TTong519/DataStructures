using DataStructures.Lists.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures.Lists
{
    static class Extensions
    {
        public static T[] Swap<T>(T[] array, int indexa, int indexb)
        {
            T temp = array[indexa];
            array[indexa] = array[indexb];
            array[indexb] = temp;
            return array;
        }
        public static void Sort<TComparable>(this TComparable[] array) where TComparable : IComparable
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
        }
        public static void Sort<TComparable>(this SinglyLinkedList<TComparable> array) where TComparable : IComparable
        {
            bool thingy = true;
            while (thingy)
            {
                SinglyLinkedNode<TComparable> node = array.Head;
                thingy = false;
                for(int i = 0; i < array.Count - 1; i++)
                {
                    if(node.Value.CompareTo(node.Next.Value) > 0)
                    {
                        thingy = true;
                        TComparable val = node.Value;
                        node.Value = node.Next.Value;
                        node.Next.Value = val;
                        node = node.Next;
                    }
                }
            }
        }
    }
}
