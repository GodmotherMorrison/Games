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
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.MinimumSize = new Size(600, 600);
            this.pictureBox1.Size = new Size(grid.Size, grid.Size);
            this.pictureBox1.Location = new Point(DisplayRectangle.Width/2 - pictureBox1.Width /2,
                DisplayRectangle.Height / 2 - pictureBox1.Height / 2);
            this.pictureBox1.Anchor = AnchorStyles.None;
            
            ///Events///
            this.pictureBox1.Click += new EventHandler(this.FuckHandler);
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

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
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


        private void FuckHandler(object sender, EventArgs e)
        {
            //Получить цвет нажатого блока на доске
            Point point = MousePosition;
            Color color = Win32.GetPixelColor(point.X, point.Y);

            //for debug
            Console.WriteLine(color.Name);

            var g = Graphics.FromImage(grid.Display);
            g.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, 160, 20));

        }
    }
}

