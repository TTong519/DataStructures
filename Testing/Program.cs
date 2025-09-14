using DataStructures.Trees;
using DataStructures.StacksAndQueues;
using DataStructures;
using System.Data;
namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructures.Graphs.DirectedWeightedGraph<int> graph = new();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddVertex(9);
            graph.AddVertex(10);
            graph.AddEdge(1, 2, 0);
            graph.AddEdge(1, 3, 0);
            graph.AddEdge(2, 1, 0);
            graph.AddEdge(3, 1, 0);
            graph.AddEdge(2, 3, 0);
            graph.AddEdge(3, 2, 0);
            graph.AddEdge(2, 7, 0);
            graph.AddEdge(7, 9, 0);
            graph.AddEdge(9, 1, 0);
            graph.AddEdge(6, 7, 0);
            graph.AddEdge(7, 6, 0);
            graph.AddEdge(6, 1, 0);
            graph.AddEdge(3, 5, 0);
            graph.AddEdge(4, 5, 0);
            graph.AddEdge(5, 4, 0);
            graph.AddEdge(9, 4, 0);
            graph.AddEdge(9, 8, 0);
            graph.AddEdge(5, 8, 0);
            graph.AddEdge(8, 10, 0);
            var path = graph.BreadthFirstPathfinding(1, 10);
            foreach (DataStructures.Graphs.DirectedWeightedVertex<int> item in path)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
