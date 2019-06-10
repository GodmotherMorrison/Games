using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PegSolitaire.Architecture.Controls;

namespace PegSolitaire.Architecture.Logic.Backtracking
{
    public static class Backtracking
    {
        public static PictureBoxWithInterpolationMode pictureBoxGameBoard;
        private const int time = 0;

        private static void RefreshBoard(Game _game)
        {
            pictureBoxGameBoard.Image = _game.Display;
            pictureBoxGameBoard.Refresh();
            System.Threading.Thread.Sleep(200);
        }

        public static bool SolveBoard(Game game,IBoardObject[,] board, Move[] moveHistory, int depth)
        {
            if (game.IsOver())
                return game.IsWin();

            for (var x = 0; x < game.NumberOfCells; x++)
            {
                for (var y = 0; y < game.NumberOfCells; y++)
                {
                    if (!(board[x, y] is Peg)) continue;
                    var oldBoard = board;
                    var position = new Position(x, y);
                    Move move;

                    if (CheckMovePossible(board, position, Direction.UP))
                    {
                        move = new Move(position, Direction.UP);
                        doMove(game, move, time);
                        moveHistory[depth] = move;
                        if (SolveBoard(game, board, moveHistory, depth + 1)) return true;
                        board = oldBoard;
                    }
                    if (CheckMovePossible(board, position, Direction.DOWN))
                    {
                        move = new Move(position, Direction.DOWN);
                        doMove(game, move, time);
                        moveHistory[depth] = move;
                        if (SolveBoard(game, board, moveHistory, depth + 1)) return true;
                        board = oldBoard;
                    }
                    if (CheckMovePossible(board, position, Direction.LEFT))
                    {
                        move = new Move(position, Direction.LEFT);
                        doMove(game, move, time);
                        moveHistory[depth] = move;
                        if (SolveBoard(game, board, moveHistory, depth + 1)) return true;
                        board = oldBoard;
                    }
                    if (CheckMovePossible(board, position, Direction.RIGHT))
                    {
                        move = new Move(position, Direction.RIGHT);
                        doMove(game, move, time);
                        moveHistory[depth] = move;
                        if (SolveBoard(game, board, moveHistory, depth + 1)) return true;
                        board = oldBoard;
                    }
                }
            }

            return false;
        }


        public static void doMove(Game game, Move move, int time)
        {
            Position position = move.src;
            Position middle;
            Position dst;

            Direction direction = move.direction;

            switch (direction)
            {
                case Direction.LEFT:
                    middle = position.delta(0, -1);
                    dst = position.delta(0, -2);
                    break;
                case Direction.RIGHT:
                    middle = position.delta(0, 1);
                    dst = position.delta(0, 2);
                    break;
                case Direction.UP:
                    middle = position.delta(-1, 0);
                    dst = position.delta(-2, 0);
                    break;
                case Direction.DOWN:
                    middle = position.delta(1, 0);
                    dst = position.delta(2, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            Thread.Sleep(time);

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
                case Direction.LEFT:
                    middle = position.delta(0, -1);
                    dst = position.delta(0, -2);
                    break;
                case Direction.RIGHT:
                    middle = position.delta(0, 1);
                    dst = position.delta(0, 2);
                    break;
                case Direction.UP:
                    middle = position.delta(-1, 0);
                    dst = position.delta(-2, 0);
                    break;
                case Direction.DOWN:
                    middle = position.delta(1, 0);
                    dst = position.delta(2, 0);
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

        private static bool IsPeg(IBoardObject[,] board, Position dst)
        {
            return board[dst.I, dst.J] is Peg;
        }
    }
}
