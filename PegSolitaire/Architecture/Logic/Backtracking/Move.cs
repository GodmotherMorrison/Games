
namespace PegSolitaire.Architecture.Logic.Backtracking
{
    public enum Direction { Up, Down, Left, Right }

    public struct Move
    {
        public Move(Position src, Direction direction)
        {
            Src = src;
            Direction = direction;
        }

        public Position Src;
        public Direction Direction;
    }
}
