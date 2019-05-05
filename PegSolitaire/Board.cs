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

        cell[,] board { get; set; }


        public Board(int size)
        {
            this.sizeOfDisplay = size;
            this.Display = new Bitmap(this.Size, this.Size);
        }



        public void Create()
        {
            board = new cell[numberOfCells, numberOfCells];



            for (int i = 2; i < 5; i++)
                for (int j = 0; j < 7; j++)
                    board[i, j] = new cell { value = true };

            for (int i = 0; i < 7; i++)
                for (int j = 2; j < 5; j++)
                    board[i, j] = new cell { value = true };

            board[3, 3] = new cell { value = false };


            Draw();

        }

        private void Draw()
        {
            using (var g = Graphics.FromImage(this.Display))
            {
                for (int i = 0; i < numberOfCells; i++)
                    for (int j = 0; j < numberOfCells; j++)
                    {
                        try
                        {
                            if (board[i, j].value)
                                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(i * sizeOfCell, j * sizeOfCell,
                                    sizeOfCell, sizeOfCell));
                            else
                                g.DrawEllipse(Pens.Red, new Rectangle(i * sizeOfCell, j * sizeOfCell,
                                    sizeOfCell, sizeOfCell));
                        }

                        catch (NullReferenceException) { }
                    }
            }
        }

        public void Update(Point location, Point sizePB)
        {
            Console.WriteLine("SizeOFDisplay = " + sizeOfDisplay);

            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;


            int i = location.Y;
            int j = location.X;

            //position on the board - [i, j]
            Point position = new Point(i, j);

            Console.WriteLine(position.X.ToString() + " " + position.Y.ToString());


            if (true)
            {
                //restore
                Draw();

                if (board[i, j] != null && board[i, j].value)
                {
                    //выбираем возможные варианты хода, подсвеичвая их зеленым
                    // саму шашку изменяем на другой цвет

                    GetVariantsOfMove(position);
                }

            }
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
                    if (board[i, j] != null && !board[i, j].value)
                    {
                        g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(i * sizeOfCell, j * sizeOfCell,
                            sizeOfCell, sizeOfCell));
                        g.FillEllipse(new SolidBrush(Color.DarkRed), new Rectangle(position.Y * sizeOfCell, position.X * sizeOfCell,
                            sizeOfCell, sizeOfCell));
                    }

                }
                catch (IndexOutOfRangeException) { }
            }

            //foreach (var neighbour in Neighbors)
            // if(2*neighbour - tempLocation)
            //+
            //var g = Graphics.FromImage(this.Display);

            //try
            //{
            //    if (board[x, y - 1].value && !board[x, y - 2].value)
            //    {
            //        g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(x * sizeOfCell, (y - 2) * sizeOfCell,
            //    sizeOfCell, sizeOfCell));
            //        g.FillEllipse(new SolidBrush(Color.GreenYellow), new Rectangle(x * sizeOfCell, y * sizeOfCell,
            //    sizeOfCell, sizeOfCell));
            //    }


            //}
            //catch (IndexOutOfRangeException) { }


        }

        private List<Point> FindNeighbors(Point position)
        {
            var neighbors = new List<Point>();

            int i = position.X;
            int j = position.Y;

            try
            {
                if (board[i - 1, j] != null && board[i - 1, j].value)
                neighbors.Add(new Point(i - 1, j));
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (board[i, j + 1] != null && board[i, j + 1].value)
                    neighbors.Add(new Point(i, j + 1));
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (board[i + 1, j] != null && board[i + 1, j].value)
                    neighbors.Add(new Point(i + 1, j));
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (board[i, j - 1] != null && board[i, j - 1].value)
                    neighbors.Add(new Point(i, j - 1));
            }
            catch (IndexOutOfRangeException) { }

            return neighbors;
        }

        private bool TryGetLocationOnBoard(ref Point location, Point sizePB)
        {

            double x = location.X - (sizePB.X - sizePB.Y) / 2;
            double y = location.Y;

            Console.WriteLine(x.ToString() + " " + y.ToString());

            if (x <= 0 || x >= sizeOfDisplay)
                return false;

            //x = x / sizeImagePB * Size;
            //y = y / sizeImagePB * Size;

            x = x / (sizeOfDisplay / numberOfCells);
            y = y / (sizeOfDisplay / numberOfCells);


            location = new Point((int)x, (int)y);

            return true;
        }
    }
}
