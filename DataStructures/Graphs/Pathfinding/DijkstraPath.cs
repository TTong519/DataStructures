using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Pathfinding
{
    public class DijkstraPath<T>
    {
        DirectedWeightedGraph<Node<T>> graph;
        public DijkstraPath(DirectedWeightedGraph<Node<T>> graph)
        {
            this.graph = graph;
        }
        public List<Node<T>> FindPath(Node<T> startVal, Node<T> endVal)
        {
            if (startVal == null || endVal == null || startVal == null || endVal == null)
            {
                return null;
            }
            foreach (var vertex in graph.Vertices)
            {
                vertex.Value.KnownDistance = int.MaxValue;
                vertex.Value.FinalDistance = int.MaxValue;
                vertex.Value.Founder = null;
                vertex.Value.Visited = false;
            }
            startVal.KnownDistance = 0;
            var priorityQueue = new SortedSet<(int distance, Node<T> node)>(Comparer<(int distance, Node<T> node)>.Create((a, b) =>
            {
                int result = a.distance.CompareTo(b.distance);
                if (result == 0)
                {
                    result = a.node.GetHashCode().CompareTo(b.node.GetHashCode());
                }
                return result;
            }));
            priorityQueue.Add((0, startVal));
            while (priorityQueue.Count > 0)
            {
                var current = priorityQueue.Min.node;
                priorityQueue.Remove(priorityQueue.Min);
                if (current.Visited)
                {
                    continue;
                }
                current.Visited = true;
                if (current == endVal)
                {
                    break;
                }
                var currentVertex = graph.Vertices.First(v => v.Value == current);
                foreach (var edge in currentVertex.Neighbors)
                {
                    var neighbor = edge.EndPoint.Value;
                    if (neighbor.Visited)
                    {
                        continue;
                    }
                    int newDistance = current.KnownDistance + (int)edge.Distance;
                    if (newDistance < neighbor.KnownDistance)
                    {
                        neighbor.KnownDistance = newDistance;
                        neighbor.Founder = current;
                        priorityQueue.Add((newDistance, neighbor));
                    }
                }
            }
            if (endVal.Founder == null && startVal != endVal)
            {
                return null; // No path found
            }
            var path = new List<Node<T>>();
            for (var at = endVal; at != null; at = at.Founder)
            {
                path.Add(at);
            }
            path.Reverse();
            return path;
        }
    }
}
