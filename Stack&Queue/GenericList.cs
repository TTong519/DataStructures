using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    public class GenericList<T>
    {
        private T[] Items;
        private int insertIndex;
        public int Count { get { return insertIndex; } }
        public GenericList(int size = 10)
        {
            Items = new T[size];
            insertIndex = 0;
        }
        public T GetIndex(int index)
        {
            if(index < insertIndex && index >= 0)
            {
                return Items[index];
            }
            throw new ArgumentOutOfRangeException("index");
        }
        public void SetIndex(int index, T value)
        {
            if(index < insertIndex && index >= 0)
            {
                Items[index] = value;
            }
            throw new ArgumentOutOfRangeException("index");
        }
        public void Add(T item)
        {
            if (insertIndex >= Items.Length - 1)
            {
                T[] temp = new T[Items.Length*2];
                for (int i = 0; i < Items.Length; i++)
                {
                    temp[i] = Items[i];
                }
                Items = temp;
            }
            Items[insertIndex] = item;
            insertIndex++;
        }
        public void Remove(T item)
        {
            int index = -1;
            for (int i = 0; i < insertIndex; i++)
            {
                if (object.Equals(Items[i], item))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                for (int i = index; i < Items.Length - 2; i++)
                {
                    Items[i] = Items[i + 1];
                }
                insertIndex--;
                return;
            }
            throw new Exception(item + " is not found");
        }
        public void Clear()
        {
            T[] temp = new T[Items.Length];
            Items = temp;
            insertIndex = 0;
        }
    }
}
