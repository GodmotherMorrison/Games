using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegSolitaire.Architecture
{
    public partial class GameWindow : Form
    {
        private void PictureBoxPlay_Click(object s, EventArgs e) => ShowPanel(panelGame);

        private void PictureBoxNewGame_Click(object s, EventArgs e)
        {
            pictureBoxGameBoard.Image = null;
            Game.Game.CreateBoard(Game.Game.StringBoard);
            pictureBoxGameBoard.Image = Game.Game.GetDrawnBoard();
            ShowPanel(panelGame);
        }
        private void PictureBoxSelectField_Click(object s, EventArgs e) => ShowPanel(panelBoards);

        private void PictureBoxExit_Click(object s, EventArgs e) => Close();
    }
}
