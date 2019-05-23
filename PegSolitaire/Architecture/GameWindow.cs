using System;
using System.Drawing;
using System.Windows.Forms;
using PegSolitaire.Architecture.Game;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        public GameWindow() => InitializeComponent();

        private void Form1_Shown(object sender, EventArgs e)
        {
            ShowMenu();
            Game.Game.SetSizeOfDisplay(pictureBox1.Height);
            Game.Game.CreateBoard(BoardCreator.Standard);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Game.Game.UpdateBoard(e.Location, (Point)pictureBox1.Size);
            pictureBox1.Image = Game.Game.Display;

            if (!Game.Game.IsOver()) return;

            if (Game.Game.IsWin())
                MessageBox.Show(@"(ﾉ´ヮ`)ﾉ･ﾟ", @"You won!");
            else
                MessageBox.Show(@"(╯°□°）╯︵ ┻━┻", @"Game over!");

            ShowMenu();
        }

        private void PictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Game.Game.SizeOfDisplay = (pictureBox1.Width > pictureBox1.Height) ? pictureBox1.Height : pictureBox1.Width;
        }

        private bool _isShowMenu;

        private static void HideControl(Control c, bool state)
        {
            c.Enabled = state;
            c.Visible = state;
        }

        public void ShowMenu()
        {
            HideControl(pictureBox1, false);
            HideControl(panelMenu, true);

            _isShowMenu = !_isShowMenu;
        }

        public void HideMenu()
        {
            HideControl(pictureBox1, true);
            HideControl(panelMenu, false);

            _isShowMenu = !_isShowMenu;
        }

        private void GameWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Escape) return;
            if (_isShowMenu)
                HideMenu();
            else
                ShowMenu();
        }

        private void PictureBoxPlay_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBoxNewGame_Click(object sender, EventArgs e)
        {
            Game.Game.CreateBoard(BoardCreator.Standard);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
            HideMenu();
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Maroon;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Transparent;
        }
    }
}
