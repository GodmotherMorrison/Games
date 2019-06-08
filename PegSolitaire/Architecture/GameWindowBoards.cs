using System;
using System.Windows.Forms;
using PegSolitaire.Architecture.Game;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        private void SelectBoard(string board)
        {
            Game.Game.ClearBoard();
            Game.Game.CreateBoard(board);
            pictureBoxGameBoard.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }

        private void PictureBoxStandard_Click(object s, EventArgs e) => SelectBoard(BoardCreator.Standard);

        private void PictureBoxEuropean_Click(object s, EventArgs e) => SelectBoard(BoardCreator.European);

        private void PictureBoxAsymmetrical_Click(object s, EventArgs e) => SelectBoard(BoardCreator.Asymmetrical);

        private void PictureBoxWiegleb_Click(object s, EventArgs e) => SelectBoard(BoardCreator.Wiegleb);

        private void PictureBoxDiamond_Click(object s, EventArgs e) => SelectBoard(BoardCreator.Diamond);

        private void ButtonExit_Click(object s, EventArgs e) => ShowPanel(panelMenu);
    }
}
