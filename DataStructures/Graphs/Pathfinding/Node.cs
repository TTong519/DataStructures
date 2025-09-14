using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Pathfinding
{
    public class Node
    {
        public int KnownDistance;
        public int FinalDistance;
        public Node Founder;
        public bool Visited;
        public Node()
        {
            KnownDistance = int.MaxValue;
            FinalDistance = int.MaxValue;
            Founder = null;
            Visited = false;
        }
    }
}
