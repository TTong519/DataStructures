using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BNode<T> where T : IComparable<T>
    {
        public T[] Values;
        public BNode<T>[] Children;
        public int Degree { get; private set; }
        public bool IsLeaf => Children.All(c => c == null);
        public BNode(int degree)
        {
            Degree = degree;
            Values = new T[degree - 1];
            Children = new BNode<T>[degree];
        }
        public BNode<T> Split()
        public bool Expand(T value)
        {
            if(Degree == 4)
            {
                return false;
            }
            T[] newValues = new T[Degree];
            Values.CopyTo(newValues, 0);
            newValues[Degree - 1] = value;
            Children = new BNode<T>[Degree + 1];
            Degree++;
            return true;
        }
        public void Insert(T value)
        {
            if (IsLeaf)
            {
                Expand(value);
                return;
            }
            for (int i = 0; i < Degree - 1; i++)
            {
                if (value.CompareTo(Values[i]) < 0)
                {
                    Children[i].Insert(value);
                    return;
                }
            }
            Children[Degree - 1].Insert(value);
        }
    }
}
