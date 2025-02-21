using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    //https://eishaaya.itch.io/tetris-boogaloo
    public class DoublyLinkedNode<T>
    {
        public T Value;
        public DoublyLinkedNode<T> Next;
        public DoublyLinkedNode<T> Previous;
        public CircularDoublyLinkedList<T> Owner { get; internal set; }
        public DoublyLinkedNode(T value, CircularDoublyLinkedList<T> owner, DoublyLinkedNode<T>? next = null, DoublyLinkedNode<T>? previous = null)
        {
            Value = value;
            Next = next!;
            Previous = previous!;
            Owner = owner;
        }
    }
}
