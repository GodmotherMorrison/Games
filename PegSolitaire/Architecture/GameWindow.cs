﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PegSolitaire
{
    public partial class GameWindow : Form
    {
        public GameWindow() => InitializeComponent();

        private void Form1_Shown(object sender, EventArgs e)
        {
            Game.CreateBoard();

            this.game = new GameLogic(pictureBox1.Height);
            game.DrawBoard();
            pictureBox1.Image = game.Display;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            game.UpdateBoard(e.Location, (Point)pictureBox1.Size);
            pictureBox1.Image = game.Display;

            if (game.IsGameOver())
            {
                MessageBox.Show("(╯°□°）╯︵ ┻━┻", "Game is over!");
                this.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode.Low;
            base.OnPaint(paintEventArgs);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
            => game.SizeOfDisplay =
            (pictureBox1.Width > pictureBox1.Height) ? pictureBox1.Height : pictureBox1.Width;

    }
}
