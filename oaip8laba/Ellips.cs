using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oaip8laba
{
    internal class Ellips : Figure
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public Ellips(int x, int y, int w, int h) { this.x = x; this.y = y; this.w = w; this.h = h; }
        public Ellips() { this.x = 0; this.y = 0; this.w = 0; this.h = 0; }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(Init.pen, this.x, this.y, this.w, this.h);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {

            if (!((this.x + x < 0 && this.y + y < 0)
            || (this.y + y < 0)
            || (this.x + x > Init.pictureBox.Width && this.y + y <
            0) || (this.x + this.w + x > Init.pictureBox.Width)
            || (this.x + x > Init.pictureBox.Width && this.y + y >
            Init.pictureBox.Height)
            || (this.y + this.h + y > Init.pictureBox.Height)

            || (this.x + x < 0 && this.y + y >
            Init.pictureBox.Height) || (this.x + x < 0)))
            {
                this.x += x;
                this.y += y;
                this.DeleteF(this, false);
                this.Draw();
            }
        }
    }
}
