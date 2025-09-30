using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Pathfinding
{
    [DebuggerDisplay("{Value}")]
    public class Node<T>(T name)
    {
        public T Value = name;
        public int KnownDistance = int.MaxValue;
        public int FinalDistance = int.MaxValue;
        public Node<T> Founder = null;
        public bool Visited = false;
    }
}
