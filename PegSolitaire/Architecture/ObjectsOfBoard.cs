using System;
using System.Collections.Generic;

namespace PegSolitaire
{
    class Peg : IBoardObject
    {
        public position position { get; set; }

        public Peg(position pos)
        {
            this.position = pos;
        }

        public Peg(int i, int j)
        {
            this.position = new position(i, j);
        }

        public List<IBoardObject> GetNeighbors()
        {
            var neighbors = new List<IBoardObject>();

            AddNeighbor(new position(this.position.i - 1, this.position.j), ref neighbors);
            AddNeighbor(new position(this.position.i + 1, this.position.j), ref neighbors);
            AddNeighbor(new position(this.position.i, this.position.j - 1), ref neighbors);
            AddNeighbor(new position(this.position.i, this.position.j + 1), ref neighbors);

            return neighbors;
        }

        private void AddNeighbor(position pos, ref List<IBoardObject> neighbors)
        {
            if (!OutOfMap(pos) && Game.Board[pos.i, pos.j] is Peg)
                neighbors.Add(Game.Board[pos.i, pos.j]);
        }

        private bool OutOfMap(position pos) => pos.i < 0 || pos.i > Game.NumberOfCells - 1 ||
                                                 pos.j < 0 || pos.j > Game.NumberOfCells - 1;


        public List<Hole> GetVariantsOfMove()
        {
            var VariantsOfMove = new List<Hole>();
            var neighbors = ((Peg)Game.Board[this.position.i, this.position.j]).GetNeighbors();

            foreach (var neighbour in neighbors)
            {
                int i = 2 * neighbour.position.i - this.position.i;
                int j = 2 * neighbour.position.j - this.position.j;

                if (!OutOfMap(new position(i, j)) && Game.Board[i, j] is Hole)
                    VariantsOfMove.Add((Hole)Game.Board[i, j]);
            }

            return VariantsOfMove;
        }
    }

    class Hole : IBoardObject
    {
        public position position { get; set; }

        public Hole(position pos)
        {
            this.position = pos;
        }

        public Hole(int i, int j)
        {
            this.position = new position(i, j);
        }

    }
}
