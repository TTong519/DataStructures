using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class Vertex<T>
    {
        public T Value { get; set; }
        public List<Vertex<T>> Neighbors { get; set; }

        public int NeighborCount => Neighbors.Count;

        public Vertex(T value)
        {
            this.Value = value;
            Neighbors = new List<Vertex<T>>();
        }
    }
}
