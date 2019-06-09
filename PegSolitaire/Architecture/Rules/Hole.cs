using System;

namespace PegSolitaire.Architecture.Rules
{
    [Serializable]
    internal class Hole : IBoardObject
    {
        public Hole()
        {
        }

        public Hole(Position pos)
        {
            Position = pos;
        }

        public Hole(int i, int j)
        {
            Position = new Position(i, j);
        }

        public Position Position { get; set; }
    }
}
