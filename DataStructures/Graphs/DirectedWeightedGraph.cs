using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class DirectedWeightedGraph<T>
    {
        private List<DirectedWeightedVertex<T>> vertices;

        public IReadOnlyList<DirectedWeightedVertex<T>> Vertices => vertices;
        public IReadOnlyList<Edge<T>> Edges { get { List<Edge<T>> Edges = new(); foreach (var item in vertices) { foreach (var item1 in item.Neighbors) { if (!Edges.Contains(item1)) { Edges.Add(item1); } } } return Edges; } }

        public int VertexCount => vertices.Count;

        public DirectedWeightedGraph() 
        {
            vertices = new List<DirectedWeightedVertex<T>>();
        }
        public DirectedWeightedVertex<T> Search(T value)
        {
            foreach (var vertex in vertices)
            {
                if (vertex.Value.Equals(value))
                {
                    return vertex;
                }
            }
            return null;
        }
        public bool AddVertex(DirectedWeightedVertex<T> vertex)
        {
            if (vertex != null && !vertices.Contains(vertex) && vertex.NeighborCount == 0)
            {
                vertices.Add(vertex);
                return true;
            }
            return false;
        }
        public bool AddVertex(T value)
        {
            if (Search(value) == null)
            {
                vertices.Add(new DirectedWeightedVertex<T>(value));
                return true;
            }
            return false;
        }
        public bool RemoveVertex(T value)
        {
            var vertex = Search(value);
            if (vertex != null)
            {
                vertices.Remove(vertex);
                foreach (var v in vertices)
                {
                    //go over lambda expression/anonymous method
                    v.Neighbors.RemoveAll(x => x.Equals(vertex));
                }
                return true;
            }
            return false;
        }
    }
}
