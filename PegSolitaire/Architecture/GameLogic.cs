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

        public Image Display { get; set; }

        private List<Point> VariantsOfMove { get; set; }
        private Point selectedPeg { get; set; }

        public void DrawBoard()
        {
            RestoreDisplay();

            for (int i = 0; i < Game.NumberOfCells; i++)
            {
                for (int j = 0; j < Game.NumberOfCells; j++)
                {
                    if (Game.Board[i, j] is Peg)
                        DrawBoardObject(Images.peg, i, j);

                    else if (Game.Board[i, j] is Hole)
                        DrawBoardObject(Images.hole, i, j);

                }
            }
        }

        private void RestoreDisplay() => this.Display = new Bitmap(this.GetSize(), this.GetSize());


        private void DrawBoardObject(Image img, int i, int j)
        {
            var g = Graphics.FromImage(this.Display);
            var cell = new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(), GetSizeOfCell(), GetSizeOfCell());
            g.DrawImage(img, cell);
        }

        public void UpdateBoard(Point location, Point sizePB)
        {
            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;

            //position on the gameborad
            var position = ConvertToPosition(location);

            foreach (Point variant in VariantsOfMove)
                if (variant.Equals(position))
                {
                    Game.Board[selectedPeg.X, selectedPeg.Y] = new Hole()
                    { position = new Point(selectedPeg.X, selectedPeg.Y) };

                    Game.Board[variant.X, variant.Y] = new Peg()
                    { position = new Point(variant.X, variant.Y) };

                    Game.Board[(selectedPeg.X + variant.X) / 2, (selectedPeg.Y + variant.Y) / 2] = new Hole()
                    { position = new Point((selectedPeg.X + variant.X) / 2, (selectedPeg.Y + variant.Y) / 2) };

                    DrawBoard();
                    VariantsOfMove.Clear();
                    return;
                }

            //restore
            DrawBoard();

            if (IsPeg(position))
                GetVariantsOfMove(position);
        }

        private Point ConvertToPosition(Point location)
        {
            location.X = location.X / (SizeOfDisplay / Game.NumberOfCells);
            location.Y = location.Y / (SizeOfDisplay / Game.NumberOfCells);

            return new Point(location.Y, location.X);
        }

        private void GetVariantsOfMove(Point position)
        {

            VariantsOfMove.Clear();
            var neighbors = FindNeighbors(position);

            selectedPeg = new Point(position.X, position.Y);

            foreach (var neighbour in neighbors)
            {
                int i = 2 * neighbour.X - position.X;
                int j = 2 * neighbour.Y - position.Y;

                try
                {
                    if (Game.Board[i, j] is Hole)
                    {
                        DrawBoardObject(Images.selectedHole, i, j);
                        DrawBoardObject(Images.selectedPeg, position.X, position.Y);

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

        private bool IsPeg(Point position) => !OutOfMap(position) && Game.Board[position.X, position.Y] is Peg;

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
