using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace PegSolitaire
{

    class GameLogic
    {
        public int SizeOfDisplay { get; set; }
        public Image Display { get; set; }


        private List<Hole> VariantsOfMove { get; set; }
        private Peg selectedPeg { get; set; }


        public GameLogic(int size)
        {
            this.SizeOfDisplay = size;
            this.Display = new Bitmap(this.GetSize(), this.GetSize());
            VariantsOfMove = new List<Hole>();
        }


        public int GetSize()
        {
            return (Screen.PrimaryScreen.Bounds.Height < Screen.PrimaryScreen.Bounds.Width)
                    ? Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.Bounds.Width;
        }

        private int GetSizeOfCell() => GetSize() / Game.NumberOfCells;

        public void DrawBoard()
        {
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

        private void DrawBoardObject(Image img, int i, int j)
        {
            using (var g = Graphics.FromImage(this.Display))
            {
                var cell = new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(), GetSizeOfCell(), GetSizeOfCell());
                g.DrawImage(img, cell);
            }
        }

        public void UpdateBoard(Point location, Point sizePB)
        {
            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;

            //position on the gameborad
            var position = ConvertToPosition(location);


            DrawBoard();
            foreach (var variant in from variant in VariantsOfMove
                                    where variant.position.Equals(position)
                                    select variant)
            {
                Game.Board[selectedPeg.position.i, selectedPeg.position.j] = new Hole(selectedPeg.position);
                Game.Board[variant.position.i, variant.position.j] = new Peg(variant.position);
                Game.Board[(selectedPeg.position.i + variant.position.i) / 2, (selectedPeg.position.j + variant.position.j) / 2]
                    = new Hole((selectedPeg.position.i + variant.position.i) / 2, (selectedPeg.position.j + variant.position.j) / 2);

                DrawBoard();
                VariantsOfMove.Clear();
                return;
            }

            if (Game.Board[position.i, position.j] is Peg)
            {
                selectedPeg = (Peg)Game.Board[position.i, position.j];
                DrawBoardObject(Images.selectedPeg, position.i, position.j);

                VariantsOfMove = selectedPeg.GetVariantsOfMove();
                foreach (var variant in VariantsOfMove)
                    DrawBoardObject(Images.selectedHole, variant.position.i, variant.position.j);
            }
        }

        private position ConvertToPosition(Point location)
        {
            location.X = location.X / (SizeOfDisplay / Game.NumberOfCells);
            location.Y = location.Y / (SizeOfDisplay / Game.NumberOfCells);

            return new position(location.Y, location.X);
        }

        private bool TryGetLocationOnBoard(ref Point location, Point sizePB)
        {
            int x, y;
            if (sizePB.X > sizePB.Y)
            {
                x = location.X - (sizePB.X - sizePB.Y) / 2;
                y = location.Y;
            }

            else
            {
                x = location.X;
                y = location.Y - (sizePB.Y - sizePB.X) / 2;
            }

            if (x <= 0 || x >= SizeOfDisplay || y <= 0 || y >= SizeOfDisplay)
                return false;

            location = new Point(x, y);

            return true;
        }
    }
}
