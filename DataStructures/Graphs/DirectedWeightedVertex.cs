using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class DirectedWeightedVertex<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

        public int NeighborCount => Neighbors.Count;

        public DirectedWeightedVertex(T value) 
        {
            Value = value;
            Neighbors = new List<Edge<T>>();
        }
    }
}
