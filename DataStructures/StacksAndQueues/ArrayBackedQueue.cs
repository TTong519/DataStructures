namespace DataStructures.StacksAndQueues
{
    public class ArrayBackedQueue<T>
    {
        private T[] data = new T[10];
        public int Length { get { return data.Length; } }
        public int Count = 0;
        private int head = 0;
        private int tail = 0;
        public void Enqueue(T value)
        {
            data[tail] = value;
            tail++;
            if(tail >= Length)
            {
                tail = 0;
            }
            if(head == tail)
            {
                T[] data2 = new T[Length * 2];
                for(int i = 0; i < Length; i++)
                {
                    if(tail + i < Length)
                    {
                        data2[i] = data[tail + i];
                    }
                    else
                    {
                        data2[i] = data[i - Length - 1];
                    }
                }
                data = data2;
            }
            Count++;
        }
        public T Dequeue()
        {
            if (Count <= 0) throw new InvalidOperationException("no info");

            T toReturn = data[head];
            Count--;
            head++;
            if (head >= Length)
            {
                head = 0;
            }
            
            return toReturn;
        }
        public T Peek()
        {
            if (Count <= 0) throw new InvalidOperationException("no info");

            T toReturn = data[head];
            return toReturn;
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }
        public void Clear()
        {
            data = new T[10];
            Count = 0;
            head = 0;
            tail = 0;
        }
    }
}
