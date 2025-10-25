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
