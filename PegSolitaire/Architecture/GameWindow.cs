using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PegSolitaire.Architecture.Logic;
using PegSolitaire.Architecture.Logic.Backtracking;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow
    {
        private readonly Game _game;

        public GameWindow()
        {
            _game = SerializationManager.Deserialize();

            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;

            ShowPanel(panelMenu);
            pictureBoxGameBoard.Image = _game.GetDrawnBoard();
        }

        private readonly Dictionary<string, Bitmap[]> _menuButtons =
            new Dictionary<string, Bitmap[]>
            {
                {"pictureBoxPlay", new [] {Images.Play, Images.Play1} },
                {"pictureBoxNewGame", new [] {Images.NewGame, Images.NewGame1 } },
                {"pictureBoxSelectField", new [] {Images.SelectField, Images.SelectField1} },
                {"pictureBoxExit", new [] {Images.Exit, Images.Exit1} },
                {"buttonExit", new [] {Images.Menu, Images.Menu1} },
                {"pictureBoxStandart", new [] {Images.StandartBoard, Images.StandartBoard1} },
                {"pictureBoxEuropean", new [] {Images.EuropeanBoard, Images.EuropeanBoard1} },
                {"pictureBoxWiegleb", new [] {Images.WieglebBoard, Images.WieglebBoard1} },
                {"pictureBoxAsymmetrical", new [] {Images.AsymmetricalBoard, Images.AsymmetricalBoard1 } },
                {"pictureBoxDiamond", new [] {Images.DiamondBoard, Images.DiamondBoard1} }
            };

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
            if (e.KeyChar == (char)48)
            {
                var oldBoard = (IBoardObject[,])_game.Board.Clone();
                var moveHistory = new Move[31];
                Backtracking.PictureBoxGameBoard = pictureBoxGameBoard;
                Backtracking.SolveBoard(_game, moveHistory, 0);

                _game.Board = (IBoardObject[,])oldBoard.Clone();
                foreach (var move in moveHistory)
                {
                    if (_game.IsWin()) return;
                    Backtracking.DoMove(_game, move, 100);
                }
            }

            if (e.KeyChar != (char) Keys.Escape) return;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e) => ((PictureBox)sender).Image = _menuButtons[((PictureBox)sender).Name][1];

        private void PictureBox_MouseLeave(object sender, EventArgs e) => ((PictureBox)sender).Image = _menuButtons[((PictureBox)sender).Name][0];

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializationManager.Serialize(_game);
        }
    }
}
