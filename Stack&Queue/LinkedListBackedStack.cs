namespace Stack_Queue
{
    public class LinkedListBackedStack<T>
    {
        public int Count { get { return data.Count; }}
        private SinglyLinkedList<T> data;
        public LinkedListBackedStack(T value, T next) 
        {
            data.AddFirst(next);
            data.AddLast(value);
        }
        public void Push(T value) 
        {
            data.AddFirst(value);
        }
        public T Pop()
        {
            T toReturn;
            toReturn = data.Head.Value;
            data.RemoveFirst();
            return toReturn;
        }
        public T Peek() 
        {
            return data.Head.Value;
        }
        public void Clear() 
        {
            data.Clear();
        }
        public bool IsEmpty()
        {
            if(data.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
