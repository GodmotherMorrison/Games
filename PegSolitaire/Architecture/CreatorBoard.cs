using System;
using System.Linq;

namespace PegSolitaire
{
    class BoardCreator
    {
        public static IBoardObject[,] CreateBoard(string board, string separator = "\r\n")
        {
            var rows = board.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{board}'");
            var result = new IBoardObject[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
                for (var y = 0; y < rows.Length; y++)
                    result[x, y] = ParseBySymbol(rows[x][y]);
            return result;
        }

        private static IBoardObject ParseBySymbol(char c)
        {
            switch (c)
            {
                case ' ':
                    return null;
                case '0':
                    return new Peg();
                case '#':
                    return new Hole();
                default:
                    throw new Exception($"wrong symbol {c}");
            }
        }
    }
}
