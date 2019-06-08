using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Game.Game.UpdateBoard(e.Location, (Point)pictureBoxGameBoard.Size);
            pictureBoxGameBoard.Image = Game.Game.Display;

            if (!Game.Game.IsOver()) return;

            if (Game.Game.IsWin())
                using (var g = Graphics.FromImage(Game.Game.Display))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    var cell = new Rectangle(0, Game.Game.Display.Height / 3, Game.Game.Display.Width,
                        Game.Game.Display.Height / 3);
                    g.DrawImage(Images.YouWon, cell);
                }
            else
                using (var g = Graphics.FromImage(Game.Game.Display))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    var cell = new Rectangle(0, Game.Game.Display.Height / 3, Game.Game.Display.Width,
                        Game.Game.Display.Height / 3);
                    g.DrawImage(Images.GameOver, cell);
                }
        }

        private void PictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Game.Game.SizeOfDisplay = (pictureBoxGameBoard.Width > pictureBoxGameBoard.Height) ? pictureBoxGameBoard.Height : pictureBoxGameBoard.Width;
        }

    }
}
