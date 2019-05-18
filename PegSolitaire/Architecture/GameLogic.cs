using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PegSolitaire.Architecture
{
    internal class GameLogic
    {
        public int SizeOfDisplay { get; set; }
        public Image Display { get; set; }


        private List<Hole> VariantsOfMove { get; set; }
        private Peg SelectedPeg { get; set; }


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
            for (var i = 0; i < Game.NumberOfCells; i++)
            {
                for (var j = 0; j < Game.NumberOfCells; j++)
                {
                    switch (Game.Board[i, j])
                    {
                        case Peg _:
                            DrawBoardObject(Images.peg, i, j);
                            break;
                        case Hole _:
                            DrawBoardObject(Images.hole, i, j);
                            break;
                    }
                }
            }
        }

        private void DrawBoardObject(Image img, int i, int j)
        {
            using (var g = Graphics.FromImage(this.Display))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                var cell = new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(), GetSizeOfCell(), GetSizeOfCell());
                g.DrawImage(img, cell);
            }
        }

        public void UpdateBoard(Point location, Point sizePB)
        {
            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;

            //position on the gameboard
            var position = ConvertToPosition(location);

            DrawBoard();

            if (Game.Board[position.I, position.J] is Peg)
                SelectNewPeg(position);

            CheckVariantsOfMove(position);
        }


        private void CheckVariantsOfMove(Position pos)
        {
            foreach (var variant in from variant in VariantsOfMove
                                     where variant.Position.Equals(pos)
                                     select variant)
            {
                Game.Board[SelectedPeg.Position.I, SelectedPeg.Position.J] = new Hole(SelectedPeg.Position);
                Game.Board[variant.Position.I, variant.Position.J] = new Peg(variant.Position);
                Game.Board[(SelectedPeg.Position.I + variant.Position.I) / 2, (SelectedPeg.Position.J + variant.Position.J) / 2]
                    = new Hole((SelectedPeg.Position.I + variant.Position.I) / 2, (SelectedPeg.Position.J + variant.Position.J) / 2);

                DrawBoard();
                VariantsOfMove.Clear();
                return;
            }
        }

        private void SelectNewPeg(Position pos)
        {
            SelectedPeg = (Peg)Game.Board[pos.I, pos.J];
            DrawBoardObject(Images.selectedPeg, pos.I, pos.J);

            VariantsOfMove = SelectedPeg.GetVariantsOfMove();
            foreach (var variant in VariantsOfMove)
                DrawBoardObject(Images.selectedHole, variant.Position.I, variant.Position.J);
        }

        private Position ConvertToPosition(Point location)
        {
            location.X /= (SizeOfDisplay / Game.NumberOfCells);
            location.Y /= (SizeOfDisplay / Game.NumberOfCells);

            return new Position(location.Y, location.X);
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