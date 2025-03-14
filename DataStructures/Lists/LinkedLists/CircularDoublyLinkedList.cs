using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists.LinkedLists
{
    public class CircularDoublyLinkedList<T>
    {
        public DoublyLinkedNode<T>? Head;
        public int Count { get; private set; }
        public CircularDoublyLinkedList()
        {

        }
        public CircularDoublyLinkedList(T headval, T tailval)
        {
            Head = new DoublyLinkedNode<T>(headval, this);
            Head.Previous = new DoublyLinkedNode<T>(tailval, this, Head, Head);
            Head.Next = Head.Previous;
            Count = 2;
        }
        private DoublyLinkedNode<T> SetHead(T value)
        {
            DoublyLinkedNode<T> node;
            if (Head != null)
            {
                node = new(value, this, Head, Head.Previous);
                Head.Previous.Next = node;
                Head.Previous = node;
                Count++;
            }
            else
            {
                Head = node = new DoublyLinkedNode<T>(value, this);
                Head.Next = Head.Previous = Head;
                Count++;
            }
            return node;
        }
        public void AddFirst(T value) => Head = SetHead(value);

        public void AddLast(T value) => SetHead(value);
        
        public void AddBefore(DoublyLinkedNode<T> node, T value)
        {
            if (node != null && node.Owner == this)
            {
                DoublyLinkedNode<T> temp = new(value, this, node, node.Previous);
                node.Previous.Next = temp;
                node.Previous = temp;
                Count++;
            }
            else
            {
                throw new Exception("nope");
            }
        }
        public void AddAfter(DoublyLinkedNode<T> node, T value)
        {
            if (node != null && node.Owner == this)
            {
                DoublyLinkedNode<T> temp = new(value, this, node.Next, node);
                node.Next = temp;
                node.Next.Previous = temp;
                if(node == Head)
                {
                    Head = temp;
                }
                Count++;
            }
            else
            {
                throw new Exception("nope");
            }
        }
        public bool RemoveFirst()
        {
            if (Head != null)
            {
                Head.Next.Previous = Head.Previous;
                Head.Previous.Next = Head.Next;
                Head = Head.Next;
                if (Count == 1)
                {
                    Head = null;
                }
                Count--;
                return true;
            }
            return false;
        }
        public bool RemoveLast()
        {
            if (Head != null)
            {
                Head.Previous.Previous.Next = Head;
                Head.Previous = Head.Previous.Previous;
                if (Count == 1)
                {
                    Head = null;
                }
                Count--;
                return true;
            }
            return false;
        }
        public bool Remove(T value)
        {
            DoublyLinkedNode<T> current = Head!;
            if(Equals(current.Value, value))
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                Head = current.Next;
                return true;
            }
            for (int i = 0; i < Count; i++)
            {
                if (Equals(current.Value, value))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    return true;
                }
                current = current.Next!;
            }
            return false;
        }
        public void Clear()
        {
            Head = null;
            Count = 0;
        }
        public DoublyLinkedNode<T>? Search(T value)
        {
            DoublyLinkedNode<T> current = Head!;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next!;
            }
            return null;
        }
        public bool Contains(T value)
        {
            DoublyLinkedNode<T> current = Head;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public bool Contains(DoublyLinkedNode<T> node)
        {
            return node.Owner == this;
        }
    }
}
