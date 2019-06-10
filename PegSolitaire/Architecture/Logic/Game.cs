using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PegSolitaire.Architecture.Logic
{
    [Serializable]
    public class Game
    {
        public IBoardObject[,] Board;
        public Position WinPoint;
        public int SizeOfDisplay;
        public Image Display;
        public string LastBoardSelection;
        public List<Hole> _variantsOfMove;
        private Peg _selectedPeg;

        public Game()
        {
            SetSizeOfDisplay();
            CreateBoard(BoardCreator.Standard);
        }

        public int NumberOfCells => Board.GetLength(0);

        public void CreateBoard(string board)
        {
            LastBoardSelection = board;

            var g = Graphics.FromImage(Display);
            g.Clear(Color.Transparent);
            g.Dispose();

            Board = BoardCreator.CreateBoard(board, ref WinPoint);
            _variantsOfMove = new List<Hole>();
        }

        public void ClearBoard()
        {
            _selectedPeg = null;
            _variantsOfMove = new List<Hole>();

            var g = Graphics.FromImage(Display);
            g.Clear(Color.Transparent);
            g.Dispose();
        }

        public void SetSizeOfDisplay()
        {
            Display = new Bitmap(GetSize(), GetSize());
        }

        public int GetSize() => Screen.PrimaryScreen.Bounds.Height < Screen.PrimaryScreen.Bounds.Width ?
                                       Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.Bounds.Width;

        private int GetSizeOfCell() => GetSize() / NumberOfCells;

        public bool IsOver()
        {
            for (var i = 0; i < NumberOfCells; i++)
                for (var j = 0; j < NumberOfCells; j++)
                    if (Board[i, j] is Peg && ((Peg)Board[i, j]).GetVariantsOfMove(this).Count != 0)
                        return false;
            return true;
        }

        public bool IsWin()
        {
            var pegs = new List<Peg>();
            for (var i = 0; i < NumberOfCells; i++)
                for (var j = 0; j < NumberOfCells; j++)
                    if (Board[i, j] is Peg)
                        pegs.Add(new Peg(i, j));
            return (pegs.Count == 1 && pegs[0].Position.Equals(WinPoint));
        }

        public Image GetDrawnBoard()
        {
            for (var i = 0; i < NumberOfCells; i++)
                for (var j = 0; j < NumberOfCells; j++)
                    switch (Board[i, j])
                    {
                        case Peg _:
                            DrawBoardObject(Images.peg, i, j);
                            break;
                        case Hole _:
                            DrawBoardObject(Images.hole, i, j);
                            break;
                    }
            return Display;
        }

        private void DrawBoardObject(Image img, int i, int j)
        {
            using (var g = Graphics.FromImage(Display))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                var cell = new Rectangle(j * GetSizeOfCell(), i * GetSizeOfCell(), GetSizeOfCell(), GetSizeOfCell());
                g.DrawImage(img, cell);
            }
        }

        private void CreateBoardObj(Image img, IBoardObject obj, Position pos)
        {
            obj.Position = new Position(pos.I, pos.J);
            Board[pos.I, pos.J] = obj;
            DrawBoardObject(img, pos.I, pos.J);
        }

        public void UpdateBoard(Point location, Point displaySize)
        {
            if (!TryGetLocationOnBoard(ref location, displaySize))
                return;
            var position = ConvertToPosition(location);
            if (position.I >= NumberOfCells || position.J >= NumberOfCells) return;

            SelectNewPeg(position);
            CheckVariantsOfMove(position);
        }

        public Peg UpdateBoard(Position position, Point displaySize)
        {
            SelectNewPeg(position);
            CheckVariantsOfMove(position);

            var nextPeg = new Peg(_variantsOfMove[0].Position);

            SelectNewPeg(position);
            CheckVariantsOfMove(position);

            return nextPeg;
        }

        private void CheckVariantsOfMove(Position pos)
        {
            foreach (var variant in from variant in _variantsOfMove where variant.Position.Equals(pos) select variant)
            {
                CreateBoardObj(Images.peg,  new Peg(),  variant.Position);
                CreateBoardObj(Images.hole, new Hole(), _selectedPeg.Position);
                CreateBoardObj(Images.hole, new Hole(), new Position((_selectedPeg.Position.I + variant.Position.I) / 2,
                                                                     (_selectedPeg.Position.J + variant.Position.J) / 2));

                _selectedPeg = null;
                _variantsOfMove.Clear();
                return;
            }
        }

        private void ClearSelection()
        {
            if (_selectedPeg != null)
                DrawBoardObject(Images.peg, _selectedPeg.Position.I, _selectedPeg.Position.J);

            foreach (var variant in _variantsOfMove)
                DrawBoardObject(Images.hole, variant.Position.I, variant.Position.J);
        }

        private void DrawSelectedPegAndMove()
        {
            DrawBoardObject(Images.selectedPeg, _selectedPeg.Position.I, _selectedPeg.Position.J);

            foreach (var variant in _variantsOfMove)
                DrawBoardObject(Images.selectedHole, variant.Position.I, variant.Position.J);
        }

        private void SelectNewPeg(Position pos)
        {
            ClearSelection();

            if (!(Board[pos.I, pos.J] is Peg))
                return;  

            _selectedPeg = (Peg)Board[pos.I, pos.J];
            _variantsOfMove = _selectedPeg.GetVariantsOfMove(this);

            DrawSelectedPegAndMove();
        }

        private Position ConvertToPosition(Point location)
        {
            location.X /= (SizeOfDisplay / NumberOfCells);
            location.Y /= (SizeOfDisplay / NumberOfCells);

            return new Position(location.Y, location.X);
        }

        private bool TryGetLocationOnBoard(ref Point location, Point displaySize)
        {
            int x, y;
            if (displaySize.X > displaySize.Y)
            {
                x = location.X - (displaySize.X - displaySize.Y) / 2;
                y = location.Y;
            }
            else
            {
                x = location.X;
                y = location.Y - (displaySize.Y - displaySize.X) / 2;
            }

            if (x <= 0 || x >= SizeOfDisplay || y <= 0 || y >= SizeOfDisplay)
                return false;

            location = new Point(x, y);

            return true;
        }
    }
}
