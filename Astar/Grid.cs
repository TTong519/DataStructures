using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs;
using DataStructures.Graphs.Pathfinding;
using MonoGame.Extended;
using Microsoft.Xna.Framework;

namespace Astar
{
    public class Grid
    {
        public Rectangle Size { get; }
        public DirectedWeightedGraph<Node<Rectangle>> Graph { get; private set; }
        public Point Dimentions { get; private set; }
        public List<Rectangle> lastPath { get; private set; }
        public Grid(Rectangle size, Point dimentions) 
        {
            Graph = new DirectedWeightedGraph<Node<Rectangle>>();
            Size = size;
            Dimentions = dimentions;
            int cellWidth = size.Width / dimentions.X;
            int cellHeight = size.Height / dimentions.Y;
            for (int y = 0; y < dimentions.Y; y++)
            {
                for (int x = 0; x < dimentions.X; x++)
                {
                    Rectangle cell = new Rectangle(size.X + x * cellWidth, size.Y + y * cellHeight, cellWidth, cellHeight);
                    Graph.AddVertex(new Node<Rectangle>(cell));
                }
            }
            foreach (var vertex in Graph.Vertices)
            {
                foreach (var neighbor in from neighbor in Graph.Vertices
                                         where vertex != neighbor && vertex.Value.Value.IntersectsWith(new Rectangle(neighbor.Value.Value.X - 1, neighbor.Value.Value.Y - 1, neighbor.Value.Value.Width + 2, neighbor.Value.Value.Height + 2))
                                         select neighbor)
                {
                    Graph.AddEdge(vertex.Value, neighbor.Value, 1);
                }
            }
        }
        public void AddObstacle(Node<Rectangle> obstacle)
        {
            if (Graph.Search(obstacle) != null)
            {
                foreach(var thing in Graph.Search(obstacle).Neighbors)
                {
                    Graph.RemoveEdge(thing.StartingPoint.Value, thing.EndPoint.Value);
                    Graph.RemoveEdge(thing.EndPoint.Value, thing.StartingPoint.Value);
                }
            }
        }
        public void RemoveObstacle(Node<Rectangle> obstacle)
        {
            if (Graph.Search(obstacle) != null)
            {
                foreach (var (vertex, neighbor) in from vertex in Graph.Vertices
                                                   where vertex.Value.Value.IntersectsWith(new Rectangle(obstacle.Value.X - 1, obstacle.Value.Y - 1, obstacle.Value.Width + 2, obstacle.Value.Height + 2))
                                                   from neighbor in vertex.Neighbors
                                                   select (vertex, neighbor))
                {
                    Graph.AddEdge(vertex.Value, neighbor.EndPoint.Value, 1);
                    Graph.AddEdge(neighbor.EndPoint.Value, vertex.Value, 1);
                }
            }
        }
        private static float HeuristicCostEstimate(DirectedWeightedVertex<Node<Rectangle>> a, DirectedWeightedVertex<Node<Rectangle>> b)
        {
            return Math.Abs(a.Value.Value.X - b.Value.Value.X) + Math.Abs(a.Value.Value.Y - b.Value.Value.Y);
        }
        private static List<Rectangle> ReconstructPath(Dictionary<DirectedWeightedVertex<Node<Rectangle>>, DirectedWeightedVertex<Node<Rectangle>>> cameFrom, DirectedWeightedVertex<Node<Rectangle>> current)
        {
            var totalPath = new List<Rectangle> { current.Value.Value };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                totalPath.Add(current.Value.Value);
            }
            totalPath.Reverse();
            return totalPath;
        }
        public void AStarPathFind(Node<Rectangle> Start, Node<Rectangle> End)
        {
            var startVertex = Graph.Search(Start);
            var endVertex = Graph.Search(End);
            if (startVertex == null || endVertex == null)
            {
                lastPath = null;
            }
            var openSet = new List<DirectedWeightedVertex<Node<Rectangle>>> { startVertex };
            var cameFrom = new Dictionary<DirectedWeightedVertex<Node<Rectangle>>, DirectedWeightedVertex<Node<Rectangle>>>();
            var gScore = new Dictionary<DirectedWeightedVertex<Node<Rectangle>>, float>();
            var fScore = new Dictionary<DirectedWeightedVertex<Node<Rectangle>>, float>();
            foreach (var vertex in Graph.Vertices)
            {
                gScore[vertex] = float.MaxValue;
                fScore[vertex] = float.MaxValue;
            }
            gScore[startVertex] = 0;
            fScore[startVertex] = HeuristicCostEstimate(startVertex, endVertex);
            while (openSet.Count > 0)
            {
                var current = openSet.OrderBy(v => fScore[v]).First();
                if (current == endVertex)
                {
                    lastPath = ReconstructPath(cameFrom, current);
                }
                openSet.Remove(current);
                foreach (var edge in current.Neighbors)
                {
                    var neighbor = edge.EndPoint;
                    float tentativeGScore = gScore[current] + edge.Distance;
                    if (tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + HeuristicCostEstimate(neighbor, endVertex);
                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }
            lastPath = null;
        }
        public void draw()
        {
            foreach (var vertex in Graph.Vertices)
            {
                
            }
        }
    }
}
