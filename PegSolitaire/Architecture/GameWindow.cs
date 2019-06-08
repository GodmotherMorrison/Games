using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = _menuButtons[((PictureBox)sender).Name][1];
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = _menuButtons[((PictureBox)sender).Name][0];
        }

        //Menu

        private void PictureBoxPlay_Click(object sender, EventArgs e)
        {
            ShowPanel(panelGame);
        }

        private void PictureBoxNewGame_Click(object sender, EventArgs e)
        {
            pictureBoxGameBoard.Image = null;
            Game.Game.CreateBoard(Game.Game.StringBoard);
            pictureBoxGameBoard.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }
        private void PictureBoxSelectField_Click(object sender, EventArgs e)
        {
            ShowPanel(panelBoards);
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Game

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

        //SelectBoard

        private readonly Dictionary<string, Bitmap[]> _menuButtons =
            new Dictionary<string, Bitmap[]>
            {
                {"pictureBoxPlay", new[] {Images.Play, Images.Play1} },
                {"pictureBoxNewGame", new[] {Images.NewGame, Images.NewGame1 } },
                {"pictureBoxSelectField", new [] {Images.SelectField, Images.SelectField1} },
                {"pictureBoxExit", new [] {Images.Exit, Images.Exit1} },
                {"pictureBoxStandart", new [] {Images.StandartBoard, Images.StandartBoard1} },
                {"pictureBoxEuropean", new [] {Images.EuropeanBoard, Images.EuropeanBoard1} },
                {"pictureBoxWiegleb", new [] {Images.WieglebBoard, Images.WieglebBoard1} },
                {"pictureBoxAsymmetrical", new [] {Images.AsymmetricalBoard, Images.AsymmetricalBoard1 } },
                {"pictureBoxDiamond", new [] {Images.DiamondBoard, Images.DiamondBoard1} },
                {"buttonExit", new [] {Images.Menu, Images.Menu1} },
            };

        private void SelectBoard(string board)
        {
            Game.Game.ClearBoard();
            Game.Game.CreateBoard(board);
            pictureBoxGameBoard.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void PictureBoxStandard_Click(object sender, EventArgs e)
        {
            SelectBoard(BoardCreator.Standard);
        }

        private void PictureBoxEuropean_Click(object sender, EventArgs e)
        {
            SelectBoard(BoardCreator.European);
        }

        private void PictureBoxAsymmetrical_Click(object sender, EventArgs e)
        {
            SelectBoard(BoardCreator.Asymmetrical);
        }

        private void PictureBoxWiegleb_Click(object sender, EventArgs e)
        {
            SelectBoard(BoardCreator.Wiegleb);
        }

        private void PictureBoxDiamond_Click(object sender, EventArgs e)
        {
            SelectBoard(BoardCreator.Diamond);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            ShowPanel(panelMenu);
        }
    }
}
