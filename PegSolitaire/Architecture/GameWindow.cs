using System;
using System.Collections.Generic;
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

            Game.Game.StringBoard = BoardCreator.Standard;

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
        }

        private Dictionary<string, Bitmap[]> MenuButtons =
new Dictionary<string, Bitmap[]>
{
    {"pictureBoxPlay", new Bitmap[] {Images.Play, Images.Play1} },
    {"pictureBoxNewGame", new Bitmap[] {Images.NewGame, Images.NewGame1 } },
    {"pictureBoxSelectField", new Bitmap[] {Images.SelectField, Images.SelectField1} },
    {"pictureBoxExit", new Bitmap[] {Images.Exit, Images.Exit1} },
    {"pictureBoxStandart", new Bitmap[] {Images.StandartBoard, Images.StandartBoard1} },
    {"pictureBoxEuropean", new Bitmap[] {Images.EuropeanBoard, Images.EuropeanBoard1} },
    {"pictureBoxWiegleb", new Bitmap[] {Images.WieglebBoard, Images.WieglebBoard1} },
    {"pictureBoxAsymmetrical", new Bitmap[] {Images.AsymmetricalBoard, Images.AsymmetricalBoard1 } },
    {"pictureBoxDiamond", new Bitmap[] {Images.DiamondBoard, Images.DiamondBoard1} },
    {"buttonExit", new Bitmap[] {Images.Menu, Images.Menu1} },
};

        private void Form1_Shown(object sender, EventArgs e)
        {
            ShowPanel(panelMenu);
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

            ShowPanel(panelMenu);
        }

        private void PictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Game.Game.SizeOfDisplay = (pictureBox1.Width > pictureBox1.Height) ? pictureBox1.Height : pictureBox1.Width;
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
            if (e.KeyChar != (char) Keys.Escape) return;
            ShowPanel(panelMenu);
        }

        private void PictureBoxPlay_Click(object sender, EventArgs e)
        {
            ShowPanel(panelGame);
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBoxNewGame_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Game.Game.CreateBoard(Game.Game.StringBoard);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = MenuButtons[((PictureBox)sender).Name][1];
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = MenuButtons[((PictureBox)sender).Name][0];
        }

        private void PictureBoxSelectField_Click(object sender, EventArgs e)
        {
            ShowPanel(panelBoards);
        }

        private void PictureBoxStandart_Click(object sender, EventArgs e)
        {
            Game.Game.StringBoard = BoardCreator.Standard;
            Game.Game.CreateBoard(BoardCreator.Standard);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void PictureBoxEuropean_Click(object sender, EventArgs e)
        {
            Game.Game.StringBoard = BoardCreator.European;
            Game.Game.CreateBoard(BoardCreator.European);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void PictureBoxAsymmetrical_Click(object sender, EventArgs e)
        {
            Game.Game.StringBoard = BoardCreator.Asymmetrical;
            Game.Game.CreateBoard(BoardCreator.Asymmetrical);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void PictureBoxWiegleb_Click(object sender, EventArgs e)
        {
            Game.Game.StringBoard = BoardCreator.Wiegleb;
            Game.Game.CreateBoard(BoardCreator.Wiegleb);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void PictureBoxDiamond_Click(object sender, EventArgs e)
        {
            Game.Game.StringBoard = BoardCreator.Diamond;
            Game.Game.CreateBoard(BoardCreator.Diamond);
            pictureBox1.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            ShowPanel(panelMenu);
        }
    }
}
