using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PegSolitaire.Architecture;

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

        private const string gameIsOver = @"
  000  
  ###  
0######
0######
#######
  ###  
  ###  ";

        private const string gameIsWin = @"
  ###  
  ###  
#######
#00####
#######
  ###  
  ###  ";

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

        public static IBoardObject[,] Board;
        public static Position WinPoint;

        public static int NumberOfCells => Board.GetLength(0);

        public static void CreateBoard()
        {
            Board = BoardCreator.CreateBoard(standart);
        }

        public static bool IsOver()
        {
            for (int i = 0; i < Game.NumberOfCells; i++)
            {
                for (int j = 0; j < Game.NumberOfCells; j++)
                {
                    if (Game.Board[i, j] is Peg && ((Peg)Game.Board[i, j]).GetVariantsOfMove().Count != 0)
                        return false;
                }
            }

            return true;
        }

        public static bool IsWin()
        {
            List<Peg> Pegs = new List<Peg>();

            for (int i = 0; i < Game.NumberOfCells; i++)
            {
                for (int j = 0; j < Game.NumberOfCells; j++)
                {
                    if (Game.Board[i, j] is Peg)
                        Pegs.Add(new Peg(i, j));
                }
            }

            return (Pegs.Count == 1 && Pegs[0].Position.Equals(WinPoint));
        }
    }
}
