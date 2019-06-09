using System;
using System.Windows.Forms;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        private void PictureBoxPlay_Click(object s, EventArgs e) => ShowPanel(panelGame);

        private void PictureBoxNewGame_Click(object s, EventArgs e)
        {
            pictureBoxGameBoard.Image = null;
            _game.CreateBoard(_game.LastBoardSelection);
            pictureBoxGameBoard.Image = _game.GetDrawnBoard();
            ShowPanel(panelGame);
        }
        private void PictureBoxSelectField_Click(object s, EventArgs e) => ShowPanel(panelBoards);

        private void PictureBoxExit_Click(object s, EventArgs e) => Close();
    }
}
