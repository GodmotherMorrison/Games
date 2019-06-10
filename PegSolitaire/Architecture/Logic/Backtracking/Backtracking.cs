using System;
using System.Threading;
using PegSolitaire.Architecture.Controls;

namespace PegSolitaire.Architecture.Logic.Backtracking
{
    public static class Backtracking
    {
        public static PictureBoxWithInterpolationMode PictureBoxGameBoard;

        private static void RefreshBoard(Game game)
        {
            PictureBoxGameBoard.Image = game.Display;
            PictureBoxGameBoard.Refresh();
            Thread.Sleep(200);
        }

        public static bool SolveBoard(Game game, Move[] moveHistory, int depth)
        {
            if (game.amountOfPegs() == 1)
                return game.Board[game.WinPoint.I,game.WinPoint.J] is Peg;

            for (var x = 0; x < game.NumberOfCells; x++)
            {
                for (var y = 0; y < game.NumberOfCells; y++)
                {
                    if (!(game.Board[y, x] is Peg)) continue;
                    var oldBoard = (IBoardObject[,])game.Board.Clone();

                    var position = new Position(y, x);
                    Move move;

                    if (CheckMovePossible(game.Board, position, Direction.Up))
                    {
                        move = new Move(position, Direction.Up);
                        DoMove(game, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(game, moveHistory, depth + 1)) return true;
                        game.Board = (IBoardObject[,])oldBoard.Clone();
                    }
                    if (CheckMovePossible(game.Board, position, Direction.Down))
                    {
                        move = new Move(position, Direction.Down);
                        DoMove(game, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(game,moveHistory, depth + 1)) return true;
                        game.Board = (IBoardObject[,])oldBoard.Clone();
                    }
                    if (CheckMovePossible(game.Board, position, Direction.Left))
                    {
                        move = new Move(position, Direction.Left);
                        DoMove(game, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(game, moveHistory, depth + 1)) return true;
                        game.Board = (IBoardObject[,])oldBoard.Clone();
                    }
                    if (CheckMovePossible(game.Board, position, Direction.Right))
                    {
                        move = new Move(position, Direction.Right);
                        DoMove(game, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(game, moveHistory, depth + 1)) return true;
                        game.Board = (IBoardObject[,])oldBoard.Clone();
                    }
                }
            }

            return false;
        }


        public static void DoMove(Game game, Move move)
        {
            var position = move.Src;
            Position middle;
            Position dst;

            var direction = move.Direction;

            switch (direction)
            {
                case Direction.Up:
                    middle = position.Delta(0, -1);
                    dst = position.Delta(0, -2);
                    break;
                case Direction.Down:
                    middle = position.Delta(0, 1);
                    dst = position.Delta(0, 2);
                    break;
                case Direction.Left:
                    middle = position.Delta(-1, 0);
                    dst = position.Delta(-2, 0);
                    break;
                case Direction.Right:
                    middle = position.Delta(1, 0);
                    dst = position.Delta(2, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            game.Board[dst.I, dst.J] = new Peg();
            game.Board[middle.I, middle.J] = new Hole();
            game.Board[position.I, position.J] = new Hole();
        }

        public static void DoMove(Game game, Move move, int time)
        {
            var position = move.Src;
            Position middle;
            Position dst;

            var direction = move.Direction;

            switch (direction)
            {
                case Direction.Up:
                    middle = position.Delta(0, -1);
                    dst = position.Delta(0, -2);
                    break;
                case Direction.Down:
                    middle = position.Delta(0, 1);
                    dst = position.Delta(0, 2);
                    break;
                case Direction.Left:
                    middle = position.Delta(-1, 0);
                    dst = position.Delta(-2, 0);
                    break;
                case Direction.Right:
                    middle = position.Delta(1, 0);
                    dst = position.Delta(2, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            //Thread.Sleep(time);

            game.CreateBoardObj(Images.peg, new Peg(), dst);
            game.CreateBoardObj(Images.hole, new Hole(), middle);
            game.CreateBoardObj(Images.hole, new Hole(), position);
            RefreshBoard(game);
        }

        private static bool CheckMovePossible(IBoardObject[,] board, Position position, Direction direction)
        {
            Position middle;
            Position dst;

            switch (direction)
            {
                case Direction.Up:
                    middle = position.Delta(0, -1);
                    dst = position.Delta(0, -2);
                    break;
                case Direction.Down:
                    middle = position.Delta(0, 1);
                    dst = position.Delta(0, 2);
                    break;
                case Direction.Left:
                    middle = position.Delta(-1, 0);
                    dst = position.Delta(-2, 0);
                    break;
                case Direction.Right:
                    middle = position.Delta(1, 0);
                    dst = position.Delta(2, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return PegOnMap(board, position) && PegOnMap(board, middle) && HoleOnMap(board, dst);
        }

        private static bool PegOnMap(IBoardObject[,] board, Position pos)
        {
            if (pos.I < 0 || pos.I > board.GetLength(0) - 1 ||
                pos.J < 0 || pos.J > board.GetLength(0) - 1) return false;
            return (board[pos.I, pos.J] is Peg);
        }

        private static bool HoleOnMap(IBoardObject[,] board, Position pos)
        {
            if (pos.I < 0 || pos.I > board.GetLength(0) - 1 ||
                pos.J < 0 || pos.J > board.GetLength(0) - 1) return false;
            return (board[pos.I, pos.J] is Hole);
        }
    }
}
