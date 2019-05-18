using System.Collections.Generic;

namespace PegSolitaire.Architecture
{
    public static class Game
    {
        public static IBoardObject[,] Board;
        public static Position WinPoint;

        public static int NumberOfCells => Board.GetLength(0);

        public static void CreateBoard()
        {
            Board = BoardCreator.CreateBoard(BoardCreator.Standard);
        }

        public static bool IsOver()
        {
            for (var i = 0; i < NumberOfCells; i++)
                for (var j = 0; j < NumberOfCells; j++)
                    if (Board[i, j] is Peg && ((Peg)Board[i, j]).GetVariantsOfMove().Count != 0)
                        return false;

            return true;
        }

        public static bool IsWin()
        {
            var pegs = new List<Peg>();

            for (var i = 0; i < NumberOfCells; i++)
                for (var j = 0; j < NumberOfCells; j++)
                    if (Board[i, j] is Peg)
                        pegs.Add(new Peg(i, j));

            return (pegs.Count == 1 && pegs[0].Position.Equals(WinPoint));
        }
    }
}
