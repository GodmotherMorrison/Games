using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PegSolitaire
{
    class Board
    {
        public Board(int size)
        {
            this.SizeOfDisplay = size;
            this.Display = new Bitmap(this.GetSize(), this.GetSize());
        }

        private enum CellState { notExit, hole, peg }

        private int NumberOfCells => 7;

        public int GetSize()
        {
            return (Screen.PrimaryScreen.Bounds.Height < Screen.PrimaryScreen.Bounds.Width)
                    ? Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.Bounds.Width;
        }

        private int GetSizeOfCell()
        {
            return GetSize() / NumberOfCells;
        }

        public int SizeOfDisplay { get; set; }

        public Bitmap Display { get; set; }

        CellState[,] GameBoard { get; set; }

        private Point SelectedPegs { get; set; }

        public void Create()
        {
            GameBoard = new CellState[NumberOfCells, NumberOfCells];

            for (int i = 2; i < 5; i++)
                for (int j = 0; j < 7; j++)
                    GameBoard[i, j] = CellState.peg;

            for (int i = 0; i < 7; i++)
                for (int j = 2; j < 5; j++)
                    GameBoard[i, j] = CellState.peg;

            GameBoard[3, 3] = CellState.hole;
        }

        public void Draw()
        {
            using (var graphics = Graphics.FromImage(this.Display))
            {
                for (int i = 0; i < NumberOfCells; i++)
                {
                    for (int j = 0; j < NumberOfCells; j++)
                    {
                        switch (GameBoard[i, j])
                        {
                            case CellState.peg:
                                DrawPeg(graphics, i, j);
                                break;
                            case CellState.hole:
                                DrawHole(graphics, i, j);
                                break;
                        }
                    }
                }
            }
        }

        private void DrawHole(Graphics graphics, int i, int j)
        {
            graphics.FillEllipse(new SolidBrush(Color.White), new Rectangle(i * GetSizeOfCell(), j * GetSizeOfCell(),
                GetSizeOfCell(), GetSizeOfCell()));
            graphics.DrawEllipse(Pens.Red, new Rectangle(i * GetSizeOfCell(), j * GetSizeOfCell(),
                GetSizeOfCell(), GetSizeOfCell()));
        }

        private void DrawPeg(Graphics graphics, int i, int j)
        {
            graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle(i * GetSizeOfCell(), j * GetSizeOfCell(),
                GetSizeOfCell(), GetSizeOfCell()));
        }

        public void Update(Point location, Point sizePB)
        {
            //Console.WriteLine("SizeOFDisplay = " + sizeOfDisplay);

            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;

            Point position = ConverterToIndex(location);

            Console.WriteLine(position.X.ToString() + " " + position.Y.ToString());

            if (Display.GetPixel(position.X, position.Y) != Color.Orange)
            {
                //restore
                Draw();

                if (IsPeg(position))
                    GetVariantsOfMove(position);
            }
        }

        private Point ConverterToIndex(Point location)
        {
            location.X = location.X / (SizeOfDisplay / NumberOfCells);
            location.Y = location.Y / (SizeOfDisplay / NumberOfCells);

            return new Point(location.Y, location.X);
        }

        private void GetVariantsOfMove(Point position)
        {
            //Point tempLocation

            var g = Graphics.FromImage(this.Display);

            var neighbors = FindNeighbors(position);

            foreach (var neighbour in neighbors)
            {
                Console.WriteLine("neighbour:" + neighbour.X.ToString() + " " + neighbour.Y);

                int i = 2 * neighbour.X - position.X;
                int j = 2 * neighbour.Y - position.Y;

                try
                {
                    if (GameBoard[i, j] == CellState.hole)
                    {
                        g.FillEllipse(new SolidBrush(Color.Orange), new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(),
                            GetSizeOfCell(), GetSizeOfCell()));
                        g.FillEllipse(new SolidBrush(Color.DarkRed), new Rectangle(position.Y * GetSizeOfCell(), position.X * GetSizeOfCell(),
                            GetSizeOfCell(), GetSizeOfCell()));
                        SelectedPegs = new Point(i, j);
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

        private bool OutOfMap(Point position) => position.X < 0 || position.X > NumberOfCells - 1 ||
                                                 position.Y < 0 || position.Y > NumberOfCells - 1;

        private bool IsPeg(Point position) => !OutOfMap(position) && GameBoard[position.X, position.Y] == CellState.peg;

        private List<Point> FindNeighbors(Point position)
        {
            List<Point> neighbors = new List<Point>();

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

            Console.WriteLine(x.ToString() + " " + y.ToString());

            if (x <= 0 || x >= SizeOfDisplay)
                return false;

            //x = x / sizeImagePB * Size;
            //y = y / sizeImagePB * Size;


            location = new Point(x, y);

            return true;
        }
    }
}
