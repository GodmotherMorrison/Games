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
            VariantsOfMove = new List<position>();
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

        private List<position> VariantsOfMove { get; set; }
        private position selectedPeg { get; set; }

        public void DrawBoard()
        {
            RestoreDisplay();

            for (int i = 0; i < Game.NumberOfCells; i++)
            {
                for (int j = 0; j < Game.NumberOfCells; j++)
                {
                    if (Game.Board[i, j] is Peg)
                        DrawBoardObject("peg", i, j);

                    else if (Game.Board[i, j] is Hole)
                        DrawBoardObject("hole", i, j);

                }
            }
        }

        private void RestoreDisplay() => this.Display = new Bitmap(this.GetSize(), this.GetSize());


        private void DrawBoardObject(string boardObject, int i, int j)
        {
            var cell = new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(), GetSizeOfCell(), GetSizeOfCell());

            using (var g = Graphics.FromImage(this.Display))
            {
                switch (boardObject)
                {
                    case "peg":
                        g.DrawImage(Images.peg, cell);
                        break;
                    case "hole":
                        g.DrawImage(Images.hole, cell);
                        break;
                    case "selectedPeg":
                        g.DrawImage(Images.selectedPeg, cell);
                        break;
                    case "selectedHole":
                        g.DrawImage(Images.selectedHole, cell);
                        break;
                }
            }
        }

        public void UpdateBoard(Point location, Point sizePB)
        {
            if (!TryGetLocationOnBoard(ref location, sizePB))
                return;

            //position on the gameborad
            var position = ConvertToPosition(location);

            foreach (position variant in VariantsOfMove)
                if (variant.Equals(position))
                {
                    Game.Board[selectedPeg.i, selectedPeg.j] = new Hole()
                    { position = new position(selectedPeg.i, selectedPeg.j) };

                    Game.Board[variant.i, variant.j] = new Peg()
                    { position = new position(variant.i, variant.j) };

                    Game.Board[(selectedPeg.i + variant.i) / 2, (selectedPeg.j + variant.j) / 2] = new Hole()
                    { position = new position((selectedPeg.i + variant.i) / 2, (selectedPeg.j + variant.j) / 2) };

                    DrawBoard();
                    VariantsOfMove.Clear();
                    return;
                }

            //restore
            DrawBoard();

            if (IsPeg(position))
                GetVariantsOfMove(position);
        }

        private position ConvertToPosition(Point location)
        {
            location.X = location.X / (SizeOfDisplay / Game.NumberOfCells);
            location.Y = location.Y / (SizeOfDisplay / Game.NumberOfCells);

            return new position(location.Y, location.X);
        }

        private void GetVariantsOfMove(position position)
        {

            VariantsOfMove.Clear();
            var neighbors = FindNeighbors(position);

            selectedPeg = new position(position.i, position.j);

            foreach (var neighbour in neighbors)
            {
                int i = 2 * neighbour.i - position.i;
                int j = 2 * neighbour.j - position.j;

                try
                {
                    if (Game.Board[i, j] is Hole)
                    {
                        DrawBoardObject("selectedHole", i, j);
                        DrawBoardObject("selectedPeg", position.i, position.j);

                        VariantsOfMove.Add(new position(i, j));
                    }

                }
                catch (IndexOutOfRangeException) { }
            }
        }

        private void AddNeighbors(position pos, ref List<position> neighbors)
        {
            if (IsPeg(pos))
                neighbors.Add(new position(pos.i, pos.j));
        }

        private bool OutOfMap(position pos) => pos.i < 0 || pos.i > Game.NumberOfCells - 1 ||
                                                 pos.j < 0 || pos.j > Game.NumberOfCells - 1;

        private bool IsPeg(position pos) => !OutOfMap(pos) && Game.Board[pos.i, pos.j] is Peg;

        private List<position> FindNeighbors(position pos)
        {
            var neighbors = new List<position>();

            selectedPeg = new position(pos.i, pos.j);

            AddNeighbors(new position(pos.i - 1, pos.j), ref neighbors);
            AddNeighbors(new position(pos.i + 1, pos.j), ref neighbors);
            AddNeighbors(new position(pos.i, pos.j - 1), ref neighbors);
            AddNeighbors(new position(pos.i, pos.j + 1), ref neighbors);

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
