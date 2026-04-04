using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BNode<T> : IComparable<BNode<T>> where T : IComparable<T>
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
        public BNode(T value)
        {
            Degree = 2;
            Values = new T[1];
            Children = new BNode<T>[2];
            Values[0] = value;
        }
        public BNode<T> Split()
        {
            BNode<T> toReturn = new(2);
            toReturn.Children[0] = new(2);
            toReturn.Children[1] = new(2);
            toReturn.Values[0] = Values[1];
            toReturn.Children[0].Values[0] = Values[0];
            toReturn.Children[1].Values[0] = Values[2];
            toReturn.Children[0].Children[0] = Children[0];
            toReturn.Children[0].Children[1] = Children[1];
            toReturn.Children[1].Children[0] = Children[2];
            toReturn.Children[1].Children[1] = Children[3];
            return toReturn;
        }
        public bool Expand(T value)
        {
            if(Degree == 4)
            {
                return false;
            }
            List<T> newValues = Values.ToList();
            newValues.Add(value);
            newValues.Sort();
            Values = newValues.ToArray();
            Children = new BNode<T>[Degree + 1];
            Degree++;
            return true;
        }
        public bool Expand(BNode<T> node)
        {
            List<T> newValues = Values.ToList();
            newValues.Add(node.Values[0]);
            newValues.Sort();
            List<BNode<T>> newChildren = Children.ToList();
            newChildren.Remove(node);
            foreach(BNode<T> child in node.Children)
            {
                newChildren.Add(child);
            }
            newChildren.Sort();
            Degree++;
            Values = newValues.ToArray();
            Children = newChildren.ToArray();
            return true;
        }
        public bool Insert(T value)
        {
            if(Degree == 4)
            {
                return false;
            }
            if (IsLeaf)
            { 
                return Expand(value);
            }
            for (int i = 0; i < Degree - 1; i++)
            {
                if (Values[i].CompareTo(value) > 0)
                {
                    if (!Children[i].Insert(value))
                    {
                        BNode<T> toReplace = Children[i].Split();
                        Expand(toReplace);
                        return false;
                    }
                    return true;
                }
                else if(Values[i].CompareTo(value) == 0)
                {
                    throw new Exception("duplicate");
                }
            }
            if (!Children[Degree - 1].Insert(value))
            {
                BNode<T> toReplace = Children[Degree - 1].Split();
                Expand(toReplace);
                return false;
            }
            return true;
        }
        public bool Contains(T value)
        {
            if(IsLeaf)
            {
                return Values.Contains(value);
            }
            for (int i = 0; i < Degree - 1; i++)
            {
                if (Values[i].CompareTo(value) > 0)
                {
                    return Children[i].Contains(value);
                }
                else if (Values[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }
            return Children[Degree - 1].Contains(value);
        }

        public int CompareTo(BNode<T> other)
        {
            if (other.Values[other.Degree - 2].CompareTo(Values[0]) < 0)
            {
                return -1;
            }
            else if (other.Values[0].CompareTo(Values[Degree - 2]) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
