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
            this.board1 = new Board();
            board1.Create();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = (Image)board1.Display;
        }
    }
}
