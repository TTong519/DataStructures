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
        public Edge<T> GetEdge(T from, T to)
        {
            var fromVertex = Search(from);
            var toVertex = Search(to);
            if (fromVertex != null && toVertex != null)
            {
                return fromVertex.Neighbors.FirstOrDefault(x => x.EndPoint.Equals(toVertex));
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
                    v.Neighbors.RemoveAll(x => x.Equals(vertex));
                }
                return true;
            }
            return false;
        }
        public bool AddEdge(T from, T to, float weight)
        {
            var fromVertex = Search(from);
            var toVertex = Search(to);
            if (fromVertex != null && toVertex != null && GetEdge(from, to) == null)
            {
                fromVertex.Neighbors.Add(new(fromVertex, toVertex, weight));
                return true;
            }
            return false;
        }
        public bool RemoveEdge(T from, T to)
        {
            var edge = GetEdge(from, to);
            if (edge != null)
            {
                edge.StartingPoint.Neighbors.Remove(edge);
                return true;
            }
            return false;
        }
        public List<DirectedWeightedVertex<T>> DepthFirstPathfinding(T start, T end)
        {
            var startVertex = Search(start);
            var endVertex = Search(end);
            if (startVertex == null || endVertex == null) return null;
            Stack<DirectedWeightedVertex<T>> stack = new();
            HashSet<DirectedWeightedVertex<T>> visited = new();
            Dictionary<DirectedWeightedVertex<T>, DirectedWeightedVertex<T>> parentMap = new();
            stack.Push(startVertex);
            visited.Add(startVertex);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.Equals(endVertex))
                {
                    List<DirectedWeightedVertex<T>> path = new();
                    while (current != null)
                    {
                        path.Add(current);
                        parentMap.TryGetValue(current, out current);
                    }
                    path.Reverse();
                    return path;
                }
                foreach (var edge in current.Neighbors)
                {
                    var neighbor = edge.EndPoint;
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parentMap[neighbor] = current;
                        stack.Push(neighbor);
                    }
                }
            }
            return null;
        }
        public List<DirectedWeightedVertex<T>> BreadthFirstPathfinding(T start, T end)
        {
            var startVertex = Search(start);
            var endVertex = Search(end);
            if (startVertex == null || endVertex == null) return null;
            Queue<DirectedWeightedVertex<T>> queue = new();
            HashSet<DirectedWeightedVertex<T>> visited = new();
            Dictionary<DirectedWeightedVertex<T>, DirectedWeightedVertex<T>> parentMap = new();
            queue.Enqueue(startVertex);
            visited.Add(startVertex);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Equals(endVertex))
                {
                    List<DirectedWeightedVertex<T>> path = new();
                    while (current != null)
                    {
                        path.Add(current);
                        parentMap.TryGetValue(current, out current);
                    }
                    path.Reverse();
                    return path;
                }
                foreach (var edge in current.Neighbors)
                {
                    var neighbor = edge.EndPoint;
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parentMap[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return null;
        }
    }
}
