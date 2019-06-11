using System;
using System.Threading;
using PegSolitaire.Architecture.Controls;

namespace PegSolitaire.Architecture.Logic.Backtracking
{
    public static class Backtracking
    {
        public static PictureBoxWithInterpolationMode PictureBoxGameBoard;

        private static bool[,] _mask;

        public enum CellState
        {
            Null, Peg, Hole
        }

        public static bool[,] ToCellStates(IBoardObject[,] board)
        {
            var cellBoard = new bool[board.GetLength(0), board.GetLength(1)];
            _mask = new bool[board.GetLength(0), board.GetLength(1)];
            for (var x = 0; x < board.GetLength(0); x++)
                for (var y = 0; y < board.GetLength(1); y++)
                    switch (board[x, y])
                {
                    case Peg _:
                        cellBoard[x, y] = true;
                        break;
                    case Hole _:
                        cellBoard[x, y] = false;
                        break;
                    case null:
                        _mask[x, y] = true;
                        break;
                }

            return cellBoard;
        }

        private static int GetAmountOfPegs(this bool[,] board)
        {
            var count = 0;
            for (var x = 0; x < board.GetLength(0); x++)
                for (var y = 0; y < board.GetLength(1); y++)
                    if (board[x, y]) count++;
            return count;
        }

        private static void RefreshBoard(Game game)
        {
            PictureBoxGameBoard.Image = game.Display;
            PictureBoxGameBoard.Refresh();
            Thread.Sleep(200);
        }

        public static bool SolveBoard(bool[,] board, Position winPoint, Move[] moveHistory, int depth)
        {
            if (board.GetAmountOfPegs() == 1)
                return board[winPoint.I, winPoint.J];

            for (var x = 0; x < board.GetLength(0); x++)
                for (var y = 0; y < board.GetLength(1); y++)
                {
                    if (board[y, x] != true) continue;

                    var position = new Position(y, x);
                    Move move;

                    if (CheckMovePossible(board, position, Direction.Up))
                    {
                        move = new Move(position, Direction.Up);
                        DoMove(board, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        UndoMove(board, move);
                    }

                    if (CheckMovePossible(board, position, Direction.Down))
                    {
                        move = new Move(position, Direction.Down);
                        DoMove(board, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        UndoMove(board, move);
                    }

                    if (CheckMovePossible(board, position, Direction.Left))
                    {
                        move = new Move(position, Direction.Left);
                        DoMove(board, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        UndoMove(board, move);
                    }

                    if (CheckMovePossible(board, position, Direction.Right))
                    {
                        move = new Move(position, Direction.Right);
                        DoMove(board, move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        UndoMove(board, move);
                    }
                }

            return false;
        }

        public static void UndoMove(bool[,] board, Move move)
        {
            Position(move.Src, out var middle, out var dst, move.Direction);

            board[dst.I, dst.J] = false;
            board[middle.I, middle.J] = true;
            board[move.Src.I, move.Src.J] = true;
        }

        public static void DoMove(bool[,] board, Move move)
        {
            Position(move.Src, out var middle, out var dst, move.Direction);

            board[dst.I, dst.J] = true;
            board[middle.I, middle.J] = false;
            board[move.Src.I, move.Src.J] = false;
        }

        public static void DoMove(Game game, Move move, int time)
        {
            Position(move.Src, out var middle, out var dst, move.Direction);

            game.CreateBoardObj(Images.peg, new Peg(), dst);
            game.CreateBoardObj(Images.hole, new Hole(), middle);
            game.CreateBoardObj(Images.hole, new Hole(), move.Src);
            RefreshBoard(game);
        }

        private static bool CheckMovePossible(bool[,] board, Position position, Direction direction)
        {
            Position(position, out var middle, out var dst, direction);

            return PegOnMap(board, position) && PegOnMap(board, middle) && HoleOnMap(board, dst);
        }


        private static void Position(Position position, out Position middle, out Position dst, Direction direction)
        {
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
        }

        private static bool PegOnMap(bool[,] board, Position pos)
        {
            if (pos.I < 0 || pos.I >= board.GetLength(0) ||
                pos.J < 0 || pos.J >= board.GetLength(1)) return false;
            return (board[pos.I, pos.J] && !_mask[pos.I, pos.J]);
        }

        private static bool HoleOnMap(bool[,] board, Position pos)
        {
            if (pos.I < 0 || pos.I >= board.GetLength(0) ||
                pos.J < 0 || pos.J >= board.GetLength(1)) return false;
            return (board[pos.I, pos.J] == false && !_mask[pos.I, pos.J]);
        }
    }
}
