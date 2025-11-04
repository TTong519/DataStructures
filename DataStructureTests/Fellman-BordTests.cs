using DataStructures.Graphs;
using DataStructures.Graphs.Pathfinding;
using Mono.CompilerServices.SymbolWriter;
using System.Linq;
namespace DataStructuresTests;

[TestClass]
public class FellmanBordTests
{
    int Seed = 0;

    public T SelectRandomly<T>(List<T> list, int seed)
    {
        if(list.Count == 0)
        {
            throw new Exception("Cannot select from an empty list");
        }
        return list[new Random(seed).Next(0, list.Count - 1)];
    }
    [TestMethod]
    public void FellmanBordTest()
    {
        (DirectedWeightedGraph<int>, bool) thing = generateGraph();
        if (FellmanBord<int>.Compute(thing.Item1, thing.Item1.Vertices[0].Value) != thing.Item2)
        {
            Assert.Fail("Fellman-Bord algorithm did not return the expected result.");
        }
    }
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
        Random rand = new Random(Seed);
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
            int count = rand.Next(2, 5);
            if (unconnectedVals.Contains((value, count)))
            {
                value = rand.Next(-10, 20);
                count = rand.Next(2, 5);
            }
            unconnectedVals.Add((value, count));
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
        else
        {
            int weight1 = rand.Next(0, 10);
            int weight2 = rand.Next(0, 10);
            int weight3 = rand.Next(0, 10);
            graph.AddEdge(unconnectedVals[0].value, unconnectedVals[1].value, weight1);
            graph.AddEdge(unconnectedVals[0].value, unconnectedVals[2].value, weight2);
            graph.AddEdge(unconnectedVals[2].value, unconnectedVals[1].value, weight3);
            graph.AddEdge(unconnectedVals[1].value, unconnectedVals[0].value, weight1);
            graph.AddEdge(unconnectedVals[2].value, unconnectedVals[0].value, weight2);
            graph.AddEdge(unconnectedVals[1].value, unconnectedVals[2].value, weight3);
            unconnectedVals[0] = (unconnectedVals[0].value, unconnectedVals[0].count);
            unconnectedVals[1] = (unconnectedVals[1].value, unconnectedVals[1].count);
            unconnectedVals[2] = (unconnectedVals[2].value, unconnectedVals[2].count);
            connectedVals.Add(unconnectedVals[0]);
            connectedVals.Add(unconnectedVals[1]);
            connectedVals.Add(unconnectedVals[2]);
            unconnectedVals.RemoveAt(0);
            unconnectedVals.RemoveAt(1);
            unconnectedVals.RemoveAt(2);
        }
        while (unconnectedVals.Count > 0)
        {
            (int val, int count) thing = (-1000, -1000);
            while (thing == (-1000, -1000) || thing.count == 0)
            {
                thing = SelectRandomly(connectedVals, rand.Next());
            }
            graph.AddEdge(thing.val, unconnectedVals[0].value, rand.Next(0, 10));
            graph.AddEdge(unconnectedVals[0].value, thing.val, rand.Next(0, 10));
            connectedVals.Add((unconnectedVals[0].value, (unconnectedVals[0].count - 1)));
            if (thing.count - 1 == 0)
            {
                connectedVals.Remove(thing);
            }
            else
            {
                connectedVals.Remove(thing);
                connectedVals.Add((thing.val, thing.count - 1));
            }
            unconnectedVals.RemoveAt(0);
        }
        while (connectedVals.Count > 0)
        {
            (int val, int count) thing = (-1000, -1000);
            (int val, int count) otherThing = (-1000, -1000);
            while (thing == (-1000, -1000) || thing.count == 0)
            {
                thing = SelectRandomly(connectedVals, rand.Next());
            }
            while (otherThing == (-1000, -1000) || otherThing.count == 0)
            {
                otherThing = SelectRandomly(connectedVals, rand.Next());
            }
            while (!graph.AddEdge(thing.val, otherThing.val, rand.Next(0, 10))) 
            {
                thing = SelectRandomly(connectedVals, rand.Next());
                otherThing = SelectRandomly(connectedVals, rand.Next());
            }
            graph.AddEdge(otherThing.val, thing.val, rand.Next(0, 10));
            if (thing.count - 1 == 0)
            {
                connectedVals.Remove(thing);
            }
            else
            {
                connectedVals.Remove(thing);
                connectedVals.Add((thing.val, thing.count - 1));
            }
            if (otherThing.count - 1 == 0)
            {
                connectedVals.Remove(otherThing);
            }
            else
            {
                connectedVals.Remove(otherThing);
                connectedVals.Add((otherThing.val, otherThing.count - 1));
            }
        }
        return (graph, isCycle);
    }
}
