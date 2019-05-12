using System.Collections.Generic;

namespace PegSolitaire
{
     struct Peg : IBoardObject
    {
        public position position { get; set; }
        List<Peg> Neighbors { get; set; }
        public List<Hole> VarintsOfMove { get; set; }
    }

    struct Hole : IBoardObject
    {
        public position position { get; set; }
    }
}
