using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PegSolitaire
{
    class cell
    {
        public bool value { get; set; }
    }


    class Board
    {
        enum cellState { notExit, hole, peg }

        public int Size
        {
            get
            {
                return (Screen.PrimaryScreen.Bounds.Height < Screen.PrimaryScreen.Bounds.Width)
                    ? Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.Bounds.Width;
            }
        }

        int numberOfCells { get { return 7; } }
        int sizeOfCell { get { return Size / numberOfCells; } }

        public int sizeOfDisplay { get; set; }


        public Bitmap Display { get; set; }

        cellState[,] board { get; set; }


        private Point selectedPegs { get; set; }

        public Board(int size)
        {
            this.sizeOfDisplay = size;
            this.Display = new Bitmap(this.Size, this.Size);
        }



        public void Create()
        {
            board = new cellState[numberOfCells, numberOfCells];



            for (int i = 2; i < 5; i++)
                for (int j = 0; j < 7; j++)
                    board[i, j] = cellState.peg;

            for (int i = 0; i < 7; i++)
                for (int j = 2; j < 5; j++)
                    board[i, j] = cellState.peg;

            board[3, 3] = cellState.hole;


            Draw();

        }

        private void Draw()
        {
            using (var g = Graphics.FromImage(this.Display))
            {
                for (int i = 0; i < numberOfCells; i++)
                    for (int j = 0; j < numberOfCells; j++)
                    {
                        if (board[i, j] == cellState.peg)
                            g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(i * sizeOfCell, j * sizeOfCell,
                                sizeOfCell, sizeOfCell));
                        else if (board[i, j] == cellState.hole)
                        {
                            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(i * sizeOfCell, j * sizeOfCell,
                                sizeOfCell, sizeOfCell));
                            g.DrawEllipse(Pens.Red, new Rectangle(i * sizeOfCell, j * sizeOfCell,
                                sizeOfCell, sizeOfCell));

                        }

                    }
            }
        }

        public void Update(Point location, Point sizePB)
        {
            //Console.WriteLine("SizeOFDisplay = " + sizeOfDisplay);

            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;

            Point position = ConverterToIndex(location);

            int i = position.X;
            int j = position.Y;

            Console.WriteLine(position.X.ToString() + " " + position.Y.ToString());

            if (Display.GetPixel(position.X, position.Y) != Color.Orange)
            {
                //restore
                Draw();

                if (board[i, j] == cellState.peg)
                {
                    GetVariantsOfMove(position);
                }

            }
        }

        private Point ConverterToIndex(Point location)
        {
            location.X = location.X / (sizeOfDisplay / numberOfCells);
            location.Y = location.Y / (sizeOfDisplay / numberOfCells);

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
                    if (board[i, j] == cellState.hole)
                    {
                        g.FillEllipse(new SolidBrush(Color.Orange), new Rectangle(j * sizeOfCell, i * sizeOfCell,
                            sizeOfCell, sizeOfCell));
                        g.FillEllipse(new SolidBrush(Color.DarkRed), new Rectangle(position.Y * sizeOfCell, position.X * sizeOfCell,
                            sizeOfCell, sizeOfCell));
                        selectedPegs = new Point(i, j);
                    }

                }
                catch (IndexOutOfRangeException) { }
            }
        }

        private List<Point> FindNeighbors(Point position)
        {
            var neighbors = new List<Point>();

            int i = position.X;
            int j = position.Y;

            try
            {
                if (board[i - 1, j] == cellState.peg)
                    neighbors.Add(new Point(i - 1, j));
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (board[i, j + 1] == cellState.peg)
                    neighbors.Add(new Point(i, j + 1));
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (board[i + 1, j] == cellState.peg)
                    neighbors.Add(new Point(i + 1, j));
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (board[i, j - 1] == cellState.peg)
                    neighbors.Add(new Point(i, j - 1));
            }
            catch (IndexOutOfRangeException) { }

            return neighbors;
        }

        private bool TryGetLocationOnBoard(ref Point location, Point sizePB)
        {

            int x = location.X - (sizePB.X - sizePB.Y) / 2;
            int y = location.Y;

            Console.WriteLine(x.ToString() + " " + y.ToString());

            if (x <= 0 || x >= sizeOfDisplay)
                return false;

            //x = x / sizeImagePB * Size;
            //y = y / sizeImagePB * Size;


            location = new Point(x, y);

            return true;
        }
    }
}
