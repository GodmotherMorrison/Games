using System;
using System.Drawing;
using System.Windows.Forms;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        public GameWindow() => InitializeComponent();

        private void Form1_Shown(object sender, EventArgs e)
        {
            Game.CreateBoard(pictureBox1.Height);
            pictureBox1.Image = Game.GetDrawnBoard();
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Game.UpdateBoard(e.Location, (Point)pictureBox1.Size);
            pictureBox1.Image = Game.Display;

            if (!Game.IsOver()) return;

            if (Game.IsWin())
                MessageBox.Show(@"(ﾉ´ヮ`)ﾉ･ﾟ", @"You won!");
            else
                MessageBox.Show(@"(╯°□°）╯︵ ┻━┻", @"Game over!");

            Close();
        }

        private void PictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Game.SizeOfDisplay = (pictureBox1.Width > pictureBox1.Height) ? pictureBox1.Height : pictureBox1.Width;
        }
    }
}
