using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oaip8laba
{
    internal class Polygon : Figure
    {
        
        public Point[] pointFs;
        public Polygon(Point[] pointFs) 
            
        {
            this.pointFs = pointFs;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, this.pointFs);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {
           /* int max;
            int min;
         for(int i = 0; i < pointFs.Length; i++)
            {
                
            }*/

        if (!((this.x + x< 0 && this.y + y< 0)
        || (this.y + y< 0)
        || (this.x + x > Init.pictureBox.Width && this.y + y< 0)
        || (this.x + this.w + x > Init.pictureBox.Width)
        || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height)
        || (this.y + this.h + y > Init.pictureBox.Height)
        || (this.x + x< 0 && this.y + y>
        Init.pictureBox.Height) || (this.x + x< 0)))
        {
                this.x += x;
                this.y += y;
                this.DeleteF(this, false);
                this.Draw();
                }
        }

      
    }
}
