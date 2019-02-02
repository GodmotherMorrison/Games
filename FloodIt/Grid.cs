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

        public Color[] ColorSet
        {
            get
            {
                return new Color[] {Color.Blue, Color.DeepSkyBlue, Color.DarkBlue,
                Color.Aquamarine, Color.LightBlue, Color.Indigo };
            }
        }

        public Grid(int size)
        {
            this.Display = new Bitmap(size, size);
            this.Size = size;
        }

        public void Generate()
        {
            var g = Graphics.FromImage(this.Display);

            Random rnd = new Random();

            for (int i = 0; i < this.Size; i += 20)
                for (int j = 0; j < this.Size; j += 20)
                    g.FillRectangle(new SolidBrush(this.ColorSet[rnd.Next(this.ColorSet.Length)]), new Rectangle(i, j, 20, 20));
        }
        public void Flood()
        {

        }
    }
}
