using System;
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
                return
                    (Screen.PrimaryScreen.Bounds.Height < Screen.PrimaryScreen.Bounds.Width) ?
                    Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.Bounds.Width;
            }
        }
        public int numberOfCells { get { return 7; } }
        public int sizeOfCell { get { return Size / numberOfCells; } }

        public Bitmap Display { get; set; }

        public cell[,] board { get; set; }


        public Board()
        {
            this.Display = new Bitmap(Size, Size);
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
    }
}
