using System;
using System.Linq;

namespace PegSolitaire.Architecture
{
    internal class BoardCreator
    {
        public static IBoardObject[,] CreateBoard(string board, string separator = "\r\n")
        {
            var rows = board.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{board}'");
            var result = new IBoardObject[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
                for (var y = 0; y < rows.Length; y++)
                    result[x, y] = ParseBySymbol(rows[x][y], x, y);
            return result;
        }

        private static IBoardObject ParseBySymbol(char c, int i, int j)
        {
            switch (c)
            {
                case ' ':
                    return null;
                case '0': 
                    return new Peg(i, j);
                case '#':
                    {
                        Game.WinPoint = new Position(i, j);
                        return new Hole(i, j);
                    }
                default:
                    throw new Exception($"wrong symbol {c}");
            }
        }

        public const string GameIsOver = @"
  000  
  ###  
0######
0######
#######
  ###  
  ###  ";

        public const string GameIsWin = @"
  ###  
  ###  
#######
#00####
#######
  ###  
  ###  ";


        public const string Standard = @"
  000  
  000  
0000000
000#000
0000000
  000  
  000  ";

        public const string European = @"
  000  
 00000 
000#000
0000000
0000000
 00000 
  000  ";

        public const string Wiegleb = @"
   000   
   000   
   000   
000000000
0000#0000
000000000
   000   
   000   
   000   ";

        public const string Asymmetrical = @"
  000   
  000   
  000   
00000000
000#0000
00000000
  000   
  000   ";

        public const string Diamond = @"
    0    
   000   
  00000  
 0000000 
0000#0000
 0000000 
  00000  
   000   
    0    ";

    }
}
