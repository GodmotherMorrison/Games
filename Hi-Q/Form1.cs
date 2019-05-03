using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Q
{
    class Form1 : Form
    {
        private PictureBox pictureBox1;
        private Board board;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.board = new Board();
            board.Size = 210;

            this.MinimumSize = new Size(400, 400);

            this.pictureBox1 = new PictureBox();

            this.pictureBox1.Size = new Size(board.Size, board.Size);
            this.pictureBox1.Location = new Point(DisplayRectangle.Width / 2 - pictureBox1.Width / 2,
                DisplayRectangle.Height / 2 - pictureBox1.Height / 2);
            //this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.Anchor = AnchorStyles.None;

            this.pictureBox1.Paint += new PaintEventHandler(Display);

            // 
            // Form1
            // 
            this.Controls.Add(pictureBox1);
            this.BackColor = Color.White;
            this.Text = "Hi-Q";

            this.Shown += new EventHandler(CreateBoard);
        }

        private void Display(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    try
                    {
                        if (board.board[i, j].value)
                            g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(i*board.sizeOfCell, j* board.sizeOfCell,
                                board.sizeOfCell, board.sizeOfCell));
                        else
                            g.DrawEllipse(Pens.Red, new Rectangle(i* board.sizeOfCell, j* board.sizeOfCell,
                                board.sizeOfCell, board.sizeOfCell));
                    }

                    catch (NullReferenceException) {}
                }
        }

        private void CreateBoard(object sender, EventArgs e)
        {
            board.Create();
        }
    }



}
