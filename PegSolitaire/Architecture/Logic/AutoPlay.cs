using PegSolitaire.Architecture.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitaire.Architecture.Logic
{
    public static class AutoPlay
    {
        public static void DoGame(Game game, GameWindow gameWindow)
        {
            // first move
            var starthole = (Hole)game.Board[game.WinPoint.I, game.WinPoint.J];
            var listMoves = starthole.GetVariantsOfMove(game);

            gameWindow.pictureBoxGameBoard.Image = game.GetDrawnBoard();

            MovePEg(game, listMoves[0].Position, starthole.Position);
            Draw(game, gameWindow);
            MovePEg(game, listMoves[1].Position, starthole.Position);
            Draw(game, gameWindow);
            MovePEg(game, listMoves[2].Position, starthole.Position);
            Draw(game, gameWindow);

        }

        public static void MovePEg(Game game, Position Pegpos, Position Holepos)
        {
                game.CreateBoardObj(Images.peg, new Peg(), Holepos);
                game.CreateBoardObj(Images.hole, new Hole(), Pegpos);
                game.CreateBoardObj(Images.hole, new Hole(), new Position((Pegpos.I + Holepos.I) / 2, (Pegpos.J + Holepos.J) / 2));
        }

        public static void Draw(Game game, GameWindow gameWindow)
        {
            //System.Threading.Thread.Sleep(500);
            gameWindow.pictureBoxGameBoard.Image = game.GetDrawnBoard();
        }
    }
}
