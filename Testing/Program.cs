using DataStructures.Trees;
using DataStructures.StacksAndQueues;
using DataStructures.Graphs.Pathfinding;
using DataStructures.Graphs;
using DataStructures;
using System.Data;
using System.Text.Json;
namespace Testing
{
    internal class Program
    {
        class Edge
        { 
            public string Start { get; set; }
            public string End { get; set; }
            public int Distance { get; set; }
        }

        static void Main(string[] args)
        {
            DirectedWeightedGraph<Node<string>> graph = new();
            Dictionary<string, Node<string>> nodes = new();
            var Airports = JsonSerializer.Deserialize<string[]>(File.ReadAllText("..\\..\\..\\..\\DataStructures\\Graphs\\Pathfinding\\ExampleGraph\\AirportProblemVerticies.json"));
            foreach (var airport in Airports)
            {
                var node = new Node<string>(airport);
                graph.AddVertex(node);
                nodes.Add(airport, node);
            }
            

            var Flights = JsonSerializer.Deserialize<Edge[]>(File.ReadAllText("..\\..\\..\\..\\DataStructures\\Graphs\\Pathfinding\\ExampleGraph\\AirportProblemEdges.json"));
            foreach (var flight in Flights)
            {
                graph.AddEdge(nodes[flight.Start], nodes[flight.End], flight.Distance);
            }


        }
    }
}