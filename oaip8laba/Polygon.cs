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
            try
            {
                bool bruh = false;
                for (int i = 0; i < pointFs.Length; i++)
                {
                    bruh = false;
                    if (!((this.pointFs[i].X + x > Init.pictureBox.Width && this.pointFs[i].Y + y > Init.pictureBox.Height)
                        || (this.pointFs[i].X + x > Init.pictureBox.Width && this.pointFs[i].Y + y < 0)
                        || (this.pointFs[i].X + x < 0 && this.pointFs[i].Y + y > Init.pictureBox.Height)
                        || (this.pointFs[i].X + x < 0 && this.pointFs[i].Y + y < 0)
                        || (this.pointFs[i].X + x > Init.pictureBox.Width)
                        || (this.pointFs[i].Y + y > Init.pictureBox.Height)
                        || (this.pointFs[i].X + x < 0)
                        || (this.pointFs[i].Y + y < 0)))
                    {
                        bruh = true;
                    }
                    if (!bruh)
                    {
                        throw new Exception();
                    }
                }
                if (bruh)
                {
                    for (int j = 0; j < pointFs.Length; j++)
                    {
                        this.pointFs[j].X += x;
                        this.pointFs[j].Y += y;
                    }
                    this.DeleteF(this, false);
                    this.Draw();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

      
    }
}
