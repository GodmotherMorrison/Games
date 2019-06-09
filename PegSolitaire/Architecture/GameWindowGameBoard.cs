using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow
    {
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            _game.UpdateBoard(e.Location, (Point)pictureBoxGameBoard.Size);
            pictureBoxGameBoard.Image = _game.Display;

            if (_game.IsOver())
                PrintMessage(_game.IsWin() ? Images.YouWon : Images.GameOver);
        }

        private void PrintMessage(Image image)
        {
            using (var g = Graphics.FromImage(_game.Display))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                var cell = new Rectangle(0, _game.Display.Height / 3, _game.Display.Width,
                    _game.Display.Height / 3);
                g.DrawImage(image, cell);
            }
        }

        private void PictureBox1_SizeChanged(object sender, EventArgs e) => 
            _game.SizeOfDisplay = (pictureBoxGameBoard.Width > pictureBoxGameBoard.Height) ? 
                pictureBoxGameBoard.Height : pictureBoxGameBoard.Width;
    }
}
