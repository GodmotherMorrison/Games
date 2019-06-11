﻿using System;
using System.Threading;
using PegSolitaire.Architecture.Controls;

namespace PegSolitaire.Architecture.Logic.Backtracking
{
    public static class Backtracking
    {
        public static PictureBoxWithInterpolationMode PictureBoxGameBoard;
        public static int CellCount;
        private static bool[,] _mask;

        public static bool[,] ToCellStates(IBoardObject[,] board)
        {
            var cellBoard = new bool[board.GetLength(0), board.GetLength(0)];
            _mask = new bool[board.GetLength(0), board.GetLength(0)];
            for (var x = 0; x < board.GetLength(0); x++)
                for (var y = 0; y < board.GetLength(0); y++)
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
            for (var x = 0; x < CellCount; x++)
                for (var y = 0; y < CellCount; y++)
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

            for (var x = 0; x < CellCount; x++)
                for (var y = 0; y < CellCount; y++)
                {
                    if (board[y, x] != true) continue;

                    var position = new Position(y, x);
                    Move move;

                    if (board.CheckMovePossible(position, Direction.Up))
                    {
                        move = new Move(position, Direction.Up);
                        board.DoMove(move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        board.UndoMove(move);
                    }
                    else if (board.CheckMovePossible(position, Direction.Down))
                    {
                        move = new Move(position, Direction.Down);
                        board.DoMove(move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        board.UndoMove(move);
                    }
                    else if (board.CheckMovePossible(position, Direction.Left))
                    {
                        move = new Move(position, Direction.Left);
                        board.DoMove(move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        board.UndoMove(move);
                    }
                    else if (board.CheckMovePossible(position, Direction.Right))
                    {
                        move = new Move(position, Direction.Right);
                        board.DoMove(move);
                        moveHistory[depth] = move;
                        if (SolveBoard(board, winPoint, moveHistory, depth + 1)) return true;
                        board.UndoMove(move);
                    }
                }

            return false;
        }

        public static void UndoMove(this bool[,] board, Move move)
        {
            Position(move.Src, out var middle, out var dst, move.Direction);

            board[dst.I, dst.J] = false;
            board[middle.I, middle.J] = true;
            board[move.Src.I, move.Src.J] = true;
        }

        public static void DoMove(this bool[,] board, Move move)
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

        private static bool CheckMovePossible(this bool[,] board, Position position, Direction direction)
        {
            Position(position, out var middle, out var dst, direction);

            return InsideField(dst) && InsideField(middle) && board.GetValue(middle) && !board.GetValue(dst);
        }

        private static bool InsideField(Position pos)
        {
            if (pos.I < 0 || pos.I >= CellCount || pos.J < 0 || pos.J >= CellCount) return false;
            return !_mask[pos.I, pos.J];
        }

        private static bool GetValue(this bool[,] board, Position pos)
        {
            return board[pos.I,pos.J];
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
    }
}
