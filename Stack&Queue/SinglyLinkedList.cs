using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack_Queue
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedNode<T> Head { get; private set; }
        public SinglyLinkedNode<T> Tail { get; private set; }
        public int Count { get; private set; }
        public void AddFirst(T value) 
        {
            if (Head != null)
            {
                SinglyLinkedNode<T> headToBe = new SinglyLinkedNode<T>(value, Head);
                Head = headToBe;
                Count++;
            } 
            else
            {
                Head = new(value, Tail);
                Count++;
            }
        }

        public void AddLast(T value) 
        {
            if (Tail != null)
            {
                SinglyLinkedNode<T> tailToBe = new SinglyLinkedNode<T>(value);
                Tail.Next = tailToBe;
                Tail = tailToBe;
                Count++;
            }
            else
            {
                if (Head != null)
                {
                    Head.Next = new(value);
                    Tail = Head.Next;
                }
                else
                {
                    Tail = new(value);
                }
                Count++;
                }
        }

        public void AddBefore(SinglyLinkedNode<T> node, T value) 
        {
            SinglyLinkedNode<T> current = Head;
            if(Head == null)
            {
                if(Tail.Equals(node))
                {
                    Head = new(value, Tail);
                }
                else
                {
                    throw new ArgumentException("node not found", "node");
                }
                return;
            }
            for (int i = 0; i < Count; i++)
            {
                if (current.Next != node)
                {
                    current = current.Next;
                }
                else
                {
                    SinglyLinkedNode<T> nextToBe = new SinglyLinkedNode<T>(value, current.Next);
                    current.Next = nextToBe;
                    Count++;
                    return;
                }
            }
            throw new ArgumentException("node not found", "node");
        }

        public void AddAfter(SinglyLinkedNode<T> node, T value) 
        {
            SinglyLinkedNode<T> current = Head;
            for (int i = 0; i < Count; i++)
            {
                if (current != node)
                {
                    current = current.Next;
                }
                else
                {
                    SinglyLinkedNode<T> nextToBe = new SinglyLinkedNode<T>(value, current.Next);
                    current.Next = nextToBe;
                    Count++;
                    return;
                }
            }
            throw new ArgumentException("node not found", "node");
        }

        public void RemoveFirst() 
        {
            Head = Head.Next;
            Count--;
        }
        public void ReplaceHead(SinglyLinkedNode<T> node)
        {
            node.Next = Head.Next;
            Head = node;
        }
        public void ReplaceHead(T value)
        {
            SinglyLinkedNode<T> node = new(value, Head.Next);
            Head = node;
        }
        public void ReplaceTail(SinglyLinkedNode<T> node)
        {
            node.Next = null;
            Tail = node;
        }
        public void ReplaceTail(T value)
        {
            SinglyLinkedNode<T> node = new(value, null);
            Tail = node;
        }
        public bool RemoveLast() 
        {
            SinglyLinkedNode<T> current = Head;
            for (int i = 0; i < Count; i++)
            {
                if (current.Next != Tail)
                {
                    current = current.Next;
                }
                else
                {
                    Tail = current;
                    current.Next = null;
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(T value)
        {
            SinglyLinkedNode<T> current = Head;
            if (current != null)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (!current.Next.Value.Equals(value))
                    {
                        current = current.Next;
                    }
                    else
                    {
                        current.Next = current.Next.Next;
                        Count--;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Clear() 
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public SinglyLinkedNode<T> Search(T value) 
        {
            SinglyLinkedNode<T> current = Head;
            for (int i = 0; i < Count; i++)
            {
                if (!current.Value.Equals(value))
                {
                    current = current.Next;
                }
                else
                {
                    return current;
                }
            }
            return null;
        }
        public bool Contains(T value) 
        {
            SinglyLinkedNode<T> current = Head;
            for (int i = 0; i < Count; i++)
            {
                if (!current.Value.Equals(value))
                {
                    current = current.Next;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(SinglyLinkedNode<T> node) 
        {
            SinglyLinkedNode<T> current = Head;
            for (int i = 0; i < Count; i++)
            {
                if (current != node)
                {
                    current = current.Next;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
