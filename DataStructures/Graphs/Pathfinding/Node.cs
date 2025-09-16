using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Pathfinding
{
    public class Node<T>
    {
        public T Name;
        public int KnownDistance;
        public int FinalDistance;
        public Node<T> Founder;
        public bool Visited;
        public Node(T name)
        {
            KnownDistance = int.MaxValue;
            FinalDistance = int.MaxValue;
            Founder = null;
            Visited = false;
            Name = name;
        }
    }
}
