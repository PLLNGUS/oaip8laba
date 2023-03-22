using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oaip8laba
{
    internal class Ship : Figure
    {
        PointF[] PointF;
        PointF[] PointF1;
        public Ship(int x, int y, int w, int h)
        { this.x = x; this.y = y; this.w = w; this.h = h; }
        public override void Draw()
        {
            this.PointF = new PointF[4];
            this.PointF1 = new PointF[3];
            this.PointF[0] = new PointF(this.x,this.y);
            this.PointF[1] = new PointF(this.x+this.w, this.y);
            this.PointF[2] = new PointF(this.x+this.w-this.h/5, this.y+this.h/4);
            this.PointF[3] = new PointF(this.x + this.h/5, this.y + this.h/4);
            this.PointF1[0] = new PointF(this.x + this.w / 2, this.y - (this.h / 3) * 2);
            this.PointF1[1] = new PointF(this.x + this.w / 2, this.y - (this.h / 3) * 2 + this.h/6);
            this.PointF1[2] = new PointF(this.x + this.w / 2 - this.w/10, this.y - (this.h / 3) * 2   );
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, this.PointF);
            g.DrawPolygon(Init.pen, this.PointF1);
            g.DrawLine(Init.pen, new Point(this.x+this.w/2, this.y), new Point(this.x+this.w/2, this.y-(this.h/3)*2) );
            
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

