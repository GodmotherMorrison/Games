using System;
using System.Drawing;
using System.Windows.Forms;

namespace PegSolitaire
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void Form1_Shown(object sender, EventArgs e)
        {
            Game.CreateBoard();

            this.game = new GameLogic(pictureBox1.Height);
            game.DrawBoard();
            pictureBox1.Image = (Image)game.Display;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            game.UpdateBoard(e.Location, (Point)pictureBox1.Size);
            pictureBox1.Image = (Image)game.Display;
        } 

        private void pictureBox1_SizeChanged(object sender, EventArgs e) => game.SizeOfDisplay = pictureBox1.Height;
    }
}
