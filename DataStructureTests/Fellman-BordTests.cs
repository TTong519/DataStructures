using DataStructures.Graphs;
using DataStructures.Graphs.Pathfinding;
using Mono.CompilerServices.SymbolWriter;
using System.Linq;
namespace DataStructuresTests;

[TestClass]
public class FellmanBordTests
{
    public T SelectRandomly<T>(List<T> list)
    {
        return list[new Random().Next(0, list.Count)];
    }
    [TestMethod]
    public void FellmanBordTest()
    {
        // Create a small graph
        var graph = new DirectedWeightedGraph<int>();

        // Add vertices
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);
        graph.AddVertex(5);

        // Add edges with weights
        graph.AddEdge(1, 2, 1);  // Positive weight
        graph.AddEdge(2, 3, 1);  // Positive weight
        graph.AddEdge(4, 2, 1);  // Positive weight
        graph.AddEdge(2, 5, -1);  // Positive weight
        graph.AddEdge(5, 4, 1);  // Positive weight

        // Run the Fellman-Bord algorithm
        bool result = FellmanBord<int>.Compute(graph, 1);

        // Assert that there is no negative cycle
        Assert.IsFalse(result, "The graph should not contain a negative cycle.");

        // Add a negative cycle
        graph.RemoveEdge(2, 5);
        graph.AddEdge(2, 5, -10);

        // Run the algorithm again
        result = FellmanBord<int>.Compute(graph, 1);

        // Assert that the graph contains a negative cycle
        Assert.IsTrue(result, "The graph should contain a negative cycle.");
    }
    (DirectedWeightedGraph<int>, bool) generateGraph()
    {
        Random rand = new Random();
        var graph = new DirectedWeightedGraph<int>();
        bool isCycle = false;
        List<(int value, int count)> unconnectedVals = new List<(int, int)>();
        List<(int value, int count)> connectedVals = new List<(int, int)>();
        if (rand.Next(0, 2) == 1)
        {
            isCycle = true;
        }
        for (int i = 0; i < rand.Next(30, 50); i++)
        {
            int value = rand.Next(-10, 20);
            unconnectedVals.Add((value, rand.Next(2, 5)));
        }
        foreach (var value in unconnectedVals)
        {
            graph.AddVertex(value.value);
        }
        if (isCycle)
        {
            for(int i = 0; i < 5; i++)
            {
                int weight1 = rand.Next(0, 10);
                int weight2 = rand.Next(0, 10);
                int weight3 = rand.Next(-25, -(weight1 + weight2));
                graph.AddEdge(unconnectedVals[0].value, unconnectedVals[1].value, weight1);
                graph.AddEdge(unconnectedVals[0].value, unconnectedVals[2].value, weight2);
                graph.AddEdge(unconnectedVals[2].value, unconnectedVals[1].value, weight3);
                graph.AddEdge(unconnectedVals[1].value, unconnectedVals[0].value, weight1);
                graph.AddEdge(unconnectedVals[2].value, unconnectedVals[0].value, weight2);
                graph.AddEdge(unconnectedVals[1].value, unconnectedVals[2].value, weight3);
                unconnectedVals[0] = (unconnectedVals[0].value, unconnectedVals[0].count - 2);
                unconnectedVals[1] = (unconnectedVals[1].value, unconnectedVals[1].count - 2);
                unconnectedVals[2] = (unconnectedVals[2].value, unconnectedVals[2].count - 2);
                connectedVals.Add(unconnectedVals[0]);
                connectedVals.Add(unconnectedVals[1]);
                connectedVals.Add(unconnectedVals[2]);
                unconnectedVals.RemoveAt(0);
                unconnectedVals.RemoveAt(1);
                unconnectedVals.RemoveAt(2);
            }
        }
        while (unconnectedVals.Count > 0)
        {
            (int val, int count) thing = (-1000, -1000);
            while (thing == (-1000, -1000) || thing.count == 0)
            {
                thing = SelectRandomly(connectedVals);
            }

        }
        return (graph, isCycle);
    }
}
