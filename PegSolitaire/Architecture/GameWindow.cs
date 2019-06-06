using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PegSolitaire.Architecture.Game;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        public GameWindow() => InitializeComponent();

        private Dictionary<string, Bitmap[]> MenuButtons =
new Dictionary<string, Bitmap[]>
{
    {"pictureBoxPlay", new Bitmap[] {Images.Play, Images.Play1} },
    {"pictureBoxNewGame", new Bitmap[] {Images.NewGame, Images.NewGame1 } },
    {"pictureBoxSelectField", new Bitmap[] {Images.SelectField, Images.SelectField1} },
    {"pictureBoxExit", new Bitmap[] {Images.Exit, Images.Exit1} },
};

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
            HideControl(gamePanel, false);
            HideControl(panelMenu, true);

            _isShowMenu = !_isShowMenu;
        }

        public void HideMenu()
        {
            HideControl(gamePanel, true);
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
            ((PictureBox)sender).Image = MenuButtons[((PictureBox)sender).Name][1];
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = MenuButtons[((PictureBox)sender).Name][0];
        }
    }
}
