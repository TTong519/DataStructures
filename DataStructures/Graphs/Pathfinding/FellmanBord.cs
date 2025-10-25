using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs;
using DataStructures.Graphs.Pathfinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DataStructures.Graphs.Pathfinding
{
    public static class FellmanBord<T>
    {
        public static bool Compute(DirectedWeightedGraph<T> Graph, T startValue)
        {
            Dictionary<T, float> Distance = [];
            if (Graph.Search(startValue) == null)
            {
                return false;
            }
            Distance[startValue] = 0;
            int vertexCount = Graph.VertexCount;
            for (int i = 1; i <= vertexCount - 1; i++)
            {
                foreach (var edge in Graph.Edges)
                {
                    T u = edge.StartingPoint.Value;
                    T v = edge.EndPoint.Value;
                    float weight = edge.Distance;
                    if (Distance[u] != float.MaxValue && Distance[u] + weight < Distance[v])
                    {
                        Distance[v] = Distance[u] + weight;
                    }
                }
            }
            foreach (var edge in Graph.Edges)
            {
                T u = edge.StartingPoint.Value;
                T v = edge.EndPoint.Value;
                float weight = edge.Distance;
                if (Distance[u] != float.MaxValue && Distance[u] + weight < Distance[v])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
