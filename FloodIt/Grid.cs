using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace FloodIt
{
    class Grid
    {
        public Bitmap Display { get; set; }
        public int Size { get; set; }
        private int sizeOfCell = 20; ///20 ??? why is twenty

        public Color[] ColorSet ///fix pallete
        {
            get
            {
                return new Color[] {Color.Blue, Color.Green, Color.DarkBlue,
                Color.Orange, Color.Pink, Color.Yellow };
            }
        }

        public Grid(int size)
        {
            this.Display = new Bitmap(size, size);
            this.Size = size;
        }

        public void Generate()
        {
            Random rnd = new Random();
            using (var g = Graphics.FromImage(this.Display))
            {
                for (int i = 0; i < this.Size; i += sizeOfCell)
                    for (int j = 0; j < this.Size; j += sizeOfCell)
                        g.FillRectangle(new SolidBrush(this.ColorSet[rnd.Next(this.ColorSet.Length)]), new Rectangle(i, j, sizeOfCell, sizeOfCell));
            }
        }

        public void Flood(Color selectedColor)
        {
            Color tempColor = this.Display.GetPixel(1, 1);
            Color newColor = selectedColor;

            if (tempColor != newColor)
                FloodGrid(tempColor, newColor, 0, 0);
        }

        private void FloodGrid(Color tempColor, Color newColor, int pointX, int pointY)
        {
            using (var g = Graphics.FromImage(this.Display))
            {
                g.FillRectangle(new SolidBrush(newColor), new Rectangle(pointX, pointY, sizeOfCell, sizeOfCell));
            }
            

            if (pointY - sizeOfCell >= 0 && this.Display.GetPixel(pointX, pointY - sizeOfCell) == tempColor)
                FloodGrid(tempColor, newColor, pointX, pointY - sizeOfCell);

            if (pointX + sizeOfCell < this.Display.Width && this.Display.GetPixel(pointX + sizeOfCell, pointY) == tempColor)
                FloodGrid(tempColor, newColor, pointX + sizeOfCell, pointY);

            if (pointY + sizeOfCell < this.Display.Height && this.Display.GetPixel(pointX, pointY + sizeOfCell) == tempColor)
                FloodGrid(tempColor, newColor, pointX, pointY + sizeOfCell);

            if (pointX - sizeOfCell >= 0 && this.Display.GetPixel(pointX - sizeOfCell, pointY) == tempColor)
                FloodGrid(tempColor, newColor, pointX - sizeOfCell, pointY);
        }
    }
}
