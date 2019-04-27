using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloodIt
{
    class Form1 : Form
    {
        private PictureBox pictureBox1;
        private Grid grid;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new PictureBox();
            this.grid = new Grid(280);
            // 
            // pictureBox1
            // 
            this.MinimumSize = new Size(600, 600);

            this.pictureBox1.Size = new Size(grid.Size, grid.Size);
            this.pictureBox1.Location = new Point(DisplayRectangle.Width/2 - pictureBox1.Width /2,
                DisplayRectangle.Height / 2 - pictureBox1.Height / 2);
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.Anchor = AnchorStyles.None;
            
            ///Events///
            this.pictureBox1.Click += new EventHandler(this.PressMouse);
            this.pictureBox1.Paint += new PaintEventHandler(DisplayGrid);
            
            // 
            // Form1
            // 
            this.MinimumSize = new Size(400, 400);
            this.BackColor = Color.White;
            this.Controls.Add(pictureBox1);
            this.Text = "Flood It";
            
            ///Events///
            this.Shown += new EventHandler(CreateGrid);

        }

        //
        // Handlers
        //
        private void CreateGrid(object sender, EventArgs e)
        {
            grid.Generate();
        }
        private void DisplayGrid(object sender, PaintEventArgs e)
        {
            ((PictureBox)sender).Image = grid.Display;
        }

        private void PressMouse(object sender, EventArgs e)
        {
            //get color selected cell
            Point point = MousePosition;
            Color color = Win32.GetPixelColor(point.X, point.Y);

            grid.Flood(color);
        }
    }
}

