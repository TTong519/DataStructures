using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    public class SinglyLinkedNode<T>
    {
        public T Value;
        public SinglyLinkedNode<T> Next;
        public SinglyLinkedNode(T value)
        {
            Value = value;
            Next = null;
        }
        public SinglyLinkedNode(T value, SinglyLinkedNode<T> Next)
        {
            Value = value;
            this.Next = Next;
        }
    }
}
