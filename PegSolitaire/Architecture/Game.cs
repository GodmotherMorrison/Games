using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitaire
{
    public static class Game
    {
        private const string standart = @"
  000  
  000  
0000000
000#000
0000000
  000  
  000  ";

        private const string european = @"
  000  
 00000 
000#000
0000000
0000000
 00000 
  000  ";

        private const string wiegleb = @"
   000   
   000   
   000   
000000000
0000#0000
000000000
   000   
   000   
   000   ";

        private const string asymmetrical = @"
  000   
  000   
  000   
00000000
000#0000
00000000
  000   
  000   ";

        private const string diamond = @"
    0    
   000   
  00000  
 0000000 
0000#0000
 0000000 
  00000  
   000   
    0    ";

        public enum CellState { notExit, hole, peg };
        public static IBoardObject[,] Board;
        public static int NumberOfCells => Board.GetLength(0);

        public static void CreateBoard()
        {
            Board = BoardCreator.CreateBoard(standart);
        }
    }
}
