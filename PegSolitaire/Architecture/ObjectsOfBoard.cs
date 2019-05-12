using System.Collections.Generic;
using System.Drawing;

namespace PegSolitaire
{
     class Peg : IBoardObject
    {
        public Point position { get; set; }
        List<Peg> Neighbors { get; set; }
        public List<Hole> VarintsOfMove { get; set; }
    }

    class Hole : IBoardObject
    {
        public Point position { get; set; }
    }
}
