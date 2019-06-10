using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitaire.Architecture.Logic.Backtracking
{
    public enum Direction { UP, DOWN, LEFT, RIGHT }

    public struct Move
    {
        public Move(Position src, Direction direction)
        {
            this.src = src;
            this.direction = direction;
        }

        public Position src;
        public Direction direction;
    }
}
