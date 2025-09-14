using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class Edge<T>
    {
        public DirectedWeightedVertex<T> StartingPoint { get; set; }
        public DirectedWeightedVertex<T> EndPoint { get; set; }
        public float Distance { get; set; }

        public Edge(DirectedWeightedVertex<T> startingPoint, DirectedWeightedVertex<T> endingPoint, float distance) 
        {
            this.StartingPoint = startingPoint;
            this.EndPoint = endingPoint;
            this.Distance = distance;
        }
    }
}
