using System;
using System.Drawing;
using System.Windows.Forms;
using PegSolitaire.Architecture.Game;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ShowPanel(panelMenu);
            Game.Game.SetSizeOfDisplay(pictureBoxGameBoard.Height);
            Game.Game.CreateBoard(BoardCreator.Standard);
            pictureBoxGameBoard.Image = Game.Game.GetDrawnBoard();
        }

        private static void HideControl(Control c, bool state)
        {
            c.Enabled = state;
            c.Visible = state;
        }

        public void ShowPanel(Control control)
        {
            HideControl(panelMenu, false);
            HideControl(panelGame, false);
            HideControl(panelBoards, false);

            HideControl(control, true);
        }

        private void GameWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Escape) return;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e) => ((PictureBox)sender).Image = _menuButtons[((PictureBox)sender).Name][1];

        private void PictureBox_MouseLeave(object sender, EventArgs e) => ((PictureBox)sender).Image = _menuButtons[((PictureBox)sender).Name][0];
    }
}
