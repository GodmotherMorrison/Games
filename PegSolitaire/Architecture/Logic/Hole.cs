using System;
using System.Collections.Generic;

namespace PegSolitaire.Architecture.Logic
{
    [Serializable]
    public class Hole : IBoardObject
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

        public List<IBoardObject> GetNeighbors(Game game)
        {
            var neighbors = new List<IBoardObject>();

            AddNeighbor(new Position(Position.I - 1, Position.J), ref neighbors, game);
            AddNeighbor(new Position(Position.I + 1, Position.J), ref neighbors, game);
            AddNeighbor(new Position(Position.I, Position.J - 1), ref neighbors, game);
            AddNeighbor(new Position(Position.I, Position.J + 1), ref neighbors, game);

            return neighbors;
        }

        private static void AddNeighbor(Position pos, ref List<IBoardObject> neighbors, Game game)
        {
            if (!OutOfMap(pos, game.NumberOfCells) && game.Board[pos.I, pos.J] is Peg)
                neighbors.Add(game.Board[pos.I, pos.J]);
        }

        private static bool OutOfMap(Position pos, int numberOfCells) =>
            pos.I < 0 || pos.I > numberOfCells - 1 ||
            pos.J < 0 || pos.J > numberOfCells - 1;


        public List<Peg> GetVariantsOfMove(Game game)
        {
            var variantsOfMove = new List<Peg>();

            foreach (var neighbor in GetNeighbors(game))
            {
                var i = 2 * neighbor.Position.I - Position.I;
                var j = 2 * neighbor.Position.J - Position.J;

                if (!OutOfMap(new Position(i, j), game.NumberOfCells) && game.Board[i, j] is Peg)
                    variantsOfMove.Add((Peg)game.Board[i, j]);
            }

            return variantsOfMove;
        }
    }
}
