using System;

namespace PegSolitaire.Architecture.Logic
{
    [Serializable]
    public struct Position
    {
        public int I;
        public int J;

        public Position(int i, int j)
        {
            I = i;
            J = j;
        }

        public Position delta(int dx, int dy)
        {
            return new Position(I + dx, J + dy);
        }
    }
}
