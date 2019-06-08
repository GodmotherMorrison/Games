using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PegSolitaire.Architecture.Game;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
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
