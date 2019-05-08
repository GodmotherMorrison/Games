using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PegSolitaire
{

    class GameLogic
    {
        public GameLogic(int size)
        {
            this.SizeOfDisplay = size;
            this.Display = new Bitmap(this.GetSize(), this.GetSize());
            VariantsOfMove = new List<Point>();
        }

        public int GetSize()
        {
            return (Screen.PrimaryScreen.Bounds.Height < Screen.PrimaryScreen.Bounds.Width)
                    ? Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.Bounds.Width;
        }

        private int GetSizeOfCell()
        {
            return GetSize() / Game.NumberOfCells;
        }

        public int SizeOfDisplay { get; set; }

        public Bitmap Display { get; set; }

        private List<Point> VariantsOfMove { get; set; }
        private Point selectedPeg { get; set; }


        public void DrawBoard()
        {
            using (var graphics = Graphics.FromImage(this.Display))
            {
                for (int i = 0; i < Game.NumberOfCells; i++)
                {
                    for (int j = 0; j < Game.NumberOfCells; j++)
                    {
                        switch (Game.Board[i, j])
                        {
                            case Game.CellState.peg:
                                DrawPeg(graphics, Color.Red, i, j);
                                break;
                            case Game.CellState.hole:
                                DrawHole(graphics, i, j);
                                break;
                        }
                    }
                }
            }
        }

        private void DrawHole(Graphics g, int i, int j)
        {
            var cell = new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(), GetSizeOfCell(), GetSizeOfCell());

            g.FillEllipse(new SolidBrush(Color.White), cell);
            g.DrawEllipse(Pens.Red, cell);
        }

        private void DrawPeg(Graphics g, Color color, int i, int j)
        {
            var cell = new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(), GetSizeOfCell(), GetSizeOfCell());
            g.FillEllipse(new SolidBrush(color), cell);
        }

        public void UpdateBoard(Point location, Point sizePB)
        {
            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;

            var index = ConverterToIndex(location);

            foreach (Point varinat in VariantsOfMove)
                if (varinat.X == index.X && varinat.Y == index.Y)
                { 
                    Game.Board[selectedPeg.X, selectedPeg.Y] = Game.CellState.hole;
                    Game.Board[varinat.X, varinat.Y] = Game.CellState.peg;
                    Game.Board[(selectedPeg.X + varinat.X) / 2, (selectedPeg.Y + varinat.Y) / 2] = Game.CellState.hole;

                    DrawBoard();
                    VariantsOfMove.Clear();
                    return;
                }

            //restore
            DrawBoard();

            if (IsPeg(index))
                GetVariantsOfMove(index);
        }

        private Point ConverterToIndex(Point location)
        {
            location.X = location.X / (SizeOfDisplay / Game.NumberOfCells);
            location.Y = location.Y / (SizeOfDisplay / Game.NumberOfCells);

            return new Point(location.Y, location.X);
        }

        private void GetVariantsOfMove(Point position)
        {
            var g = Graphics.FromImage(this.Display);

            VariantsOfMove.Clear();
            var neighbors = FindNeighbors(position);

            selectedPeg = new Point(position.X, position.Y);

            foreach (var neighbour in neighbors)
            {
                int i = 2 * neighbour.X - position.X;
                int j = 2 * neighbour.Y - position.Y;

                try
                {
                    if (Game.Board[i, j] == Game.CellState.hole)
                    {
                        DrawPeg(g, Color.Orange, i, j);
                        DrawPeg(g, Color.DarkRed, position.X, position.Y);

                        VariantsOfMove.Add(new Point(i, j));
                    }

                }
                catch (IndexOutOfRangeException) { }
            }
        }

        private void AddNeighbors(Point position, ref List<Point> neighbors)
        {
            if (IsPeg(position))
                neighbors.Add(new Point(position.X, position.Y));
        }

        private bool OutOfMap(Point position) => position.X < 0 || position.X > Game.NumberOfCells - 1 ||
                                                 position.Y < 0 || position.Y > Game.NumberOfCells - 1;

        private bool IsPeg(Point position) => !OutOfMap(position) && Game.Board[position.X, position.Y] == Game.CellState.peg;

        private List<Point> FindNeighbors(Point position)
        {
            List<Point> neighbors = new List<Point>();

            selectedPeg = new Point(position.X, position.Y);

            AddNeighbors(new Point(position.X - 1, position.Y), ref neighbors);
            AddNeighbors(new Point(position.X + 1, position.Y), ref neighbors);
            AddNeighbors(new Point(position.X, position.Y - 1), ref neighbors);
            AddNeighbors(new Point(position.X, position.Y + 1), ref neighbors);

            return neighbors;
        }

        private bool TryGetLocationOnBoard(ref Point location, Point sizePB)
        {
            int x = location.X - (sizePB.X - sizePB.Y) / 2;
            int y = location.Y;

            if (x <= 0 || x >= SizeOfDisplay)
                return false;

            location = new Point(x, y);

            return true;
        }
    }
}
