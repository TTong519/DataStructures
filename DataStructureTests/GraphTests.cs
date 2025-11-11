using DataStructures.Graphs;

namespace DataStructuresTests;

[TestClass]
public class GraphTests
{
    [TestMethod]
    [DataRow(7475138)]
    [DataRow(3485935)]
    [DataRow(5473455)]
    [DataRow(4398562)]
    [DataRow(5346532)]
    [DataRow(4356864)]
    public void TestGraphTraversal(int seed)
    {
        var graph = new DataStructures.Graphs.Graph<int>();
        for(int i = 0; i < 9; i++)
        {
            graph.AddVertex(i);
        }
        graph.AddEdge(graph.Search(0), graph.Search(1));
        graph.AddEdge(graph.Search(0), graph.Search(2));
        graph.AddEdge(graph.Search(0), graph.Search(3));
        graph.AddEdge(graph.Search(0), graph.Search(4));
        graph.AddEdge(graph.Search(1), graph.Search(5));
        graph.AddEdge(graph.Search(2), graph.Search(6));
        graph.AddEdge(graph.Search(3), graph.Search(7));
        graph.AddEdge(graph.Search(4), graph.Search(8));
        List<Vertex<int>> visited = graph.DepthFirstTraversalIterative(0);
        List<int> expected = new List<int> { 0, 4, 8, 3, 7, 2, 6, 1, 5 };
        for(int i = 0; i < visited.Count; i++)
        {
            Assert.AreEqual(expected[i], visited[i].Value);
        }
    }
}
