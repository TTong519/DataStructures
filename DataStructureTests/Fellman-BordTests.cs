using DataStructures.Graphs;
using DataStructures.Graphs.Pathfinding;
using Mono.CompilerServices.SymbolWriter;
using System.Data.SqlTypes;
namespace DataStructuresTests;
internal class NullableInt32 : INullable
{
    public int Value { get; set; }
    public bool IsNull { get; set; }
    public NullableInt32(int value)
    {
        Value = value;
        IsNull = false;
    }
    public NullableInt32()
    {
        IsNull = true;
    }
}
[TestClass]
public class FellmanBordTests
{
    [TestMethod]
    public void FellmanBordTest()
    {

    }
    (DirectedWeightedGraph<NullableInt32>, bool) generateGraph()
    {
        Random rand = new Random();
        var graph = new DirectedWeightedGraph<NullableInt32>();
        bool isCycle = false;
        List<int> values = new List<int>();
        for(int i = 5; i < rand.Next(10, 30); i++)
        {
            int value = rand.Next(-10, 20);
            values.Add(value);
        }
        if (isCycle)
        {
            for(int i = 0; i < 5; i++)
            {
                int weight1 = rand.Next(0, 10);
                int weight2 = rand.Next(0, 10);
                int weight3 = rand.Next(-25, -(weight1 + weight2));
                graph.AddVertex(new NullableInt32(weight1));
                graph.AddVertex(new NullableInt32(weight2));
                graph.AddVertex(new NullableInt32(weight3));
                graph.AddEdge(new NullableInt32(weight1), new NullableInt32(weight2), weight1);
            }
        }
        return graph;
    }
}
