using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public int VertexCount => Vertices.Count;

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public Vertex<T> Search(T value)
        {
            foreach (var vertex in Vertices)
            {
                if (vertex.Value.Equals(value))
                {
                    return vertex;
                }
            }
            return null;
        }
        public bool AddVertex(T value)
        {
            if (Search(value) == null)
            {
                Vertices.Add(new Vertex<T>(value));
                return true;
            }
            return false;
        }
        public bool RemoveVertex(T value)
        {
            var vertex = Search(value);
            if (vertex != null)
            {
                Vertices.Remove(vertex);
                foreach (var v in Vertices)
                {
                    v.Neighbors.Remove(vertex);
                }
                return true;
            }
            return false;
        }
        public bool AddEdge(Vertex<T> fromVertex, Vertex<T> toVertex)
        {
            if (fromVertex != null && toVertex != null && !fromVertex.Neighbors.Contains(toVertex))
            {
                fromVertex.Neighbors.Add(toVertex);
                toVertex.Neighbors.Add(fromVertex);
                return true;
            }
            return false;
        }
        public bool RemoveEdge(Vertex<T> fromVertex, Vertex<T> toVertex)
        {
            if (fromVertex != null && toVertex != null && fromVertex.Neighbors.Contains(toVertex))
            {
                fromVertex.Neighbors.Remove(toVertex);
                return true;
            }
            return false;
        }
        public List<Vertex<T>> DepthFirstTraversalIterative(T startValue)
        {
            var startVertex = Search(startValue);
            if (startVertex == null) return new List<Vertex<T>>();
            var visited = new List<Vertex<T>>();
            var stack = new Stack<Vertex<T>>();
            var result = new List<Vertex<T>>();
            stack.Push(startVertex);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    result.Add(current);
                    foreach (var neighbor in current.Neighbors)
                    {
                        stack.Push(neighbor);
                    }
                }
            }
            return result;
        }
        public List<Vertex<T>> DepthFirstTraversalRecursive(T startValue)
        {
            var startVertex = Search(startValue);
            if (startVertex == null) return new List<Vertex<T>>();
            var visited = new List<Vertex<T>>();
            var result = new List<Vertex<T>>();
            DepthFirstTraversalRecursiveHelper(startVertex, visited, result);
            return result;
        }
        private void DepthFirstTraversalRecursiveHelper(Vertex<T> vertex, List<Vertex<T>> visited, List<Vertex<T>> result)
        {
            visited.Add(vertex);
            result.Add(vertex);
            foreach (var neighbor in vertex.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    DepthFirstTraversalRecursiveHelper(neighbor, visited, result);
                }
            }
        }
        public List<Vertex<T>> BreadthFirstTraversal(T startValue)
        {
            var startVertex = Search(startValue);
            if (startVertex == null) return new List<Vertex<T>>();
            var visited = new List<Vertex<T>>();
            var queue = new Queue<Vertex<T>>();
            var result = new List<Vertex<T>>();
            queue.Enqueue(startVertex);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    result.Add(current);
                    foreach (var neighbor in current.Neighbors)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return result;
        }
        public List<Vertex<T>> SingleSourceShortestPath(T startValue, T endValue)
        {
            var startVertex = Search(startValue);
            var endVertex = Search(endValue);
            if (startVertex == null || endVertex == null) return new List<Vertex<T>>();
            var visited = new List<Vertex<T>>();
            var queue = new Queue<Vertex<T>>();
            var result = new List<Vertex<T>>();
            queue.Enqueue(startVertex);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    result.Add(current);
                    if(current.Value.Equals(endValue))
                    {
                        return result;
                    }
                    foreach (var neighbor in current.Neighbors)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return new List<Vertex<T>>();
        }
    }
}
