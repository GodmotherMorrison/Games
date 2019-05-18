using System.Collections.Generic;

namespace PegSolitaire.Architecture
{
    internal class Peg : IBoardObject
    {
        public Peg(Position pos)
        {
            Position = pos;
        }

        public Peg(int i, int j)
        {
            Position = new Position(i, j);
        }

        public Position Position { get; set; }

        public List<IBoardObject> GetNeighbors()
        {
            var neighbors = new List<IBoardObject>();

            AddNeighbor(new Position(Position.I - 1, Position.J), ref neighbors);
            AddNeighbor(new Position(Position.I + 1, Position.J), ref neighbors);
            AddNeighbor(new Position(Position.I, Position.J - 1), ref neighbors);
            AddNeighbor(new Position(Position.I, Position.J + 1), ref neighbors);

            return neighbors;
        }

        private static void AddNeighbor(Position pos, ref List<IBoardObject> neighbors)
        {
            if (!OutOfMap(pos) && Game.Board[pos.I, pos.J] is Peg)
                neighbors.Add(Game.Board[pos.I, pos.J]);
        }

        private static bool OutOfMap(Position pos) => 
            pos.I < 0 || pos.I > Game.NumberOfCells - 1 ||
            pos.J < 0 || pos.J > Game.NumberOfCells - 1;


        public List<Hole> GetVariantsOfMove()
        {
            var variantsOfMove = new List<Hole>();

            foreach (var neighbor in GetNeighbors())
            {
                var i = 2 * neighbor.Position.I - Position.I;
                var j = 2 * neighbor.Position.J - Position.J;

                if (!OutOfMap(new Position(i, j)) && Game.Board[i, j] is Hole)
                    variantsOfMove.Add((Hole)Game.Board[i, j]);
            }

            return variantsOfMove;
        }
    }
}
