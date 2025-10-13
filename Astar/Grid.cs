using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs;
using DataStructures.Graphs.Pathfinding;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Astar
{
    public class Grid
    {
        static readonly float Sqrt2 = (float)Math.Sqrt(2);

        public Rectangle Size { get; }
        public DirectedWeightedGraph<Node<Rectangle>> Graph { get; private set; }
        public Point Dimensions { get; private set; }
        private List<Rectangle> LastPath { get; set; }
        public Grid(Rectangle size, Point dimensions) 
        {
            Graph = new DirectedWeightedGraph<Node<Rectangle>>();
            LastPath = new();
            Size = size;
            Dimensions = dimensions;
            int cellWidth = size.Width / dimensions.X;
            int cellHeight = size.Height / dimensions.Y;
            for (int y = 0; y < dimensions.Y; y++)
            {
                for (int x = 0; x < dimensions.X; x++)
                {
                    Rectangle cell = new(size.X + x * cellWidth, size.Y + y * cellHeight, cellWidth, cellHeight);
                    Graph.AddVertex(new Node<Rectangle>(cell));
                }
            }
            foreach (var vertex in Graph.Vertices)
            {
                foreach (var neighbor in from neighbor in Graph.Vertices
                                         where vertex != neighbor && vertex.Value.Value.Intersects(new Rectangle(neighbor.Value.Value.X - 1, neighbor.Value.Value.Y - 1, neighbor.Value.Value.Width + 2, neighbor.Value.Value.Height + 2))
                                         select neighbor)
                {
                    if(neighbor.Value.Value.X == vertex.Value.Value.X || neighbor.Value.Value.Y == vertex.Value.Value.Y)
                        Graph.AddEdge(vertex.Value, neighbor.Value, 1);
                    else
                        Graph.AddEdge(vertex.Value, neighbor.Value, Sqrt2);
                }
            }
        }
        public void AddObstacle(Node<Rectangle> obstacle)
        {
            var vertex = Graph.Search(obstacle);
            if (vertex != null)
            {
                for(int i = 0; i < vertex.NeighborCount; i++)
                {
                    Graph.RemoveEdge(vertex.Neighbors[i].EndPoint.Value, obstacle);
                    Graph.RemoveEdge(obstacle, vertex.Neighbors[i].EndPoint.Value);
                }
            }
        }
        public void RemoveObstacle(Node<Rectangle> obstacle)
        {
            if (Graph.Search(obstacle) != null)
            {
                var vertex = Graph.Search(obstacle);
                foreach (var neighbor in from neighbor in Graph.Vertices
                                         where vertex != neighbor && vertex.Value.Value.Intersects(new Rectangle(neighbor.Value.Value.X - 1, neighbor.Value.Value.Y - 1, neighbor.Value.Value.Width + 2, neighbor.Value.Value.Height + 2))
                                         select neighbor)
                {
                    if (neighbor.Value.Value.X == vertex.Value.Value.X || neighbor.Value.Value.Y == vertex.Value.Value.Y)
                        Graph.AddEdge(vertex.Value, neighbor.Value, 1);
                    else
                        Graph.AddEdge(vertex.Value, neighbor.Value, Sqrt2);
                }
            }
        }
        private static float HeuristicCostEstimate(DirectedWeightedVertex<Node<Rectangle>> a, DirectedWeightedVertex<Node<Rectangle>> b)
        {
            Point apos = new(a.Value.Value.X/a.Value.Value.Width, a.Value.Value.Y/a.Value.Value.Height);
            Point bpos = new(b.Value.Value.X/b.Value.Value.Width, b.Value.Value.Y/b.Value.Value.Height);
            return (Math.Abs(apos.X - bpos.X) + Math.Abs(apos.Y - bpos.Y)) + (Sqrt2 - 2) * Math.Min(Math.Abs(apos.X - bpos.X), Math.Abs(apos.Y - bpos.Y));
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
        public void AStarPathFind(Node<Rectangle> start, Node<Rectangle> end)
        {
            var startVertex = Graph.Search(start);
            var endVertex = Graph.Search(end);
            if (startVertex == null || endVertex == null)
            {
                LastPath = null;
            }
            var openSet = new List<DirectedWeightedVertex<Node<Rectangle>>> { startVertex };
            var cameFrom = new Dictionary<DirectedWeightedVertex<Node<Rectangle>>, DirectedWeightedVertex<Node<Rectangle>>>();
            var gScore = new Dictionary<DirectedWeightedVertex<Node<Rectangle>>, float>();
            var fScore = new Dictionary<DirectedWeightedVertex<Node<Rectangle>>, float>();
            foreach (var vertex in Graph.Vertices)
            {
                gScore[vertex] = float.MaxValue;
                fScore[vertex] = float.MaxValue;
                vertex.Value.Visited = false;
            }
            gScore[startVertex] = 0;
            fScore[startVertex] = HeuristicCostEstimate(startVertex, endVertex);
            while (openSet.Count > 0)
            {
                var current = openSet.OrderBy(v => fScore[v]).First();
                if (current == endVertex)
                {
                    LastPath = ReconstructPath(cameFrom, current);
                    break;
                }
                openSet.Remove(current);
                foreach (var edge in current.Neighbors)
                {
                    var neighbor = edge.EndPoint;

                    float tentativeGScore = gScore[current] + edge.Distance;

                    if (tentativeGScore < gScore[neighbor])
                    {
                        neighbor.Value.Visited = false;
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + HeuristicCostEstimate(neighbor, endVertex);
                    }

                    if (!openSet.Contains(neighbor) && !neighbor.Value.Visited)
                    {
                        openSet.Add(neighbor);
                    }
                }
                current.Value.Visited = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {      
            if (LastPath != null)
            {
                foreach (var thing in Graph.Vertices)
                {
                    if (LastPath.Contains(thing.Value.Value) || !thing.Value.Visited) continue;
                    var rect = thing.Value.Value;

                    spriteBatch.FillRectangle(rect, Color.Blue * 0.5f);
                }
                foreach (var rect in LastPath)
                {
                    spriteBatch.FillRectangle(rect, Color.Green * 0.5f);
                }
            }

            foreach (var vertex in Graph.Vertices)
            {
                if(vertex.NeighborCount == 0)
                {
                    spriteBatch.FillRectangle(vertex.Value.Value, Color.Red * 0.5f);
                    continue;
                }
                spriteBatch.DrawRectangle(vertex.Value.Value, Color.Gray);
            }
        }
    }
}
