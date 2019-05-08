using System;
using System.Linq;

namespace PegSolitaire
{
    class BoardCreator
    {
        public static Game.CellState[,] CreateBoard(string board, string separator = "\r\n")
        {
            var rows = board.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{board}'");
            var result = new Game.CellState[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
                for (var y = 0; y < rows.Length; y++)
                    result[x, y] = ParseBySymbol(rows[x][y]);
            return result;
        }

        private static Game.CellState ParseBySymbol(char c)
        {
            switch (c)
            {
                case ' ':
                    return Game.CellState.notExit;
                case '0':
                    return Game.CellState.peg;
                case '#':
                    return Game.CellState.hole;
                default:
                    throw new Exception($"wrong symbol {c}");
            }
        }
    }
}
