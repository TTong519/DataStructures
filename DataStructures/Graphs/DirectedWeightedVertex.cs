using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class DirectedWeightedVertex<T>(T value)
    {
        public T Value { get; set; } = value;
        public List<Edge<T>> Neighbors { get; set; } = [];

        public int NeighborCount => Neighbors.Count;
    }
}
