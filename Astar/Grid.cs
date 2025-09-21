using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs;

namespace Astar
{
    public class Grid
    {
        public Rectangle Size;
        public Graph<Rectangle> Graph = new Graph<Rectangle>();

        public Grid() { }
    }
}
