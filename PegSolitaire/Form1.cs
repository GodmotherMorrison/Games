using System;
using System.Drawing;
using System.Windows.Forms;

namespace PegSolitaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.board1 = new Board(pictureBox1.Height);
            board1.Create();
            board1.Draw();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = (Image)board1.Display;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            board1.Update(e.Location, (Point)pictureBox1.Size);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            board1.SizeOfDisplay = pictureBox1.Height;
        }
    }
}
