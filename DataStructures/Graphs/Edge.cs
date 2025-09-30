using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class Edge<T>(DirectedWeightedVertex<T> startingPoint, DirectedWeightedVertex<T> endingPoint, float distance)
    {
        public DirectedWeightedVertex<T> StartingPoint { get; set; } = startingPoint;
        public DirectedWeightedVertex<T> EndPoint { get; set; } = endingPoint;
        public float Distance { get; set; } = distance;
    }
}
