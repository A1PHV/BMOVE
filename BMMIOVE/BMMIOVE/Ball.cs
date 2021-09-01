using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BMMIOVE
{
    class Ball : Particles
    {
        public int x, y;
        public double vX, vY;
        public int R;

        Color bl;
        SolidBrush BlueBrush;

        Random r;

        public Ball(int x, int y, double vX, double vY, int R)
        {
            this.x = x;
            this.y = y;
            this.vX = vX;
            this.vY = vY;
            this.R = R;
            r = new Random();
            bl = Color.FromArgb(r.Next(0, 255), 255, 255, 255);
            BlueBrush = new SolidBrush(bl);
        }

        public override void Show(Graphics g)
        {
            g.FillEllipse(BlueBrush, x - R, y - R, 2 * R, 2 * R);
        }

        public override void CollusionBall(Ball b)
        {
            float dist = (float)Math.Sqrt(Math.Pow(x - b.x, 2) + Math.Pow(y - b.y, 2));

            //double angle = Math.Atan2(y - b.y, x - b.x);
            //double x1 = vX * Math.Cos(-angle) - vY * Math.Sin(-angle);
            //double y1 = vX * Math.Sin(-angle) + vY * Math.Cos(-angle);
            //double x2 = b.vX * Math.Cos(-angle) - b.vY * Math.Sin(-angle);
            //double y2 = b.vX * Math.Sin(-angle) + b.vY * Math.Cos(-angle);


            //float V = (float)Math.Sqrt(Math.Pow(vX, 2) + Math.Pow(vY, 2));
            //A = vY / V;
            //float sinA = (float)Math.Sin(A);
            //float cosA = (float)Math.Cos(A);
            //B = 90 - A;
            //float sinB = (float)Math.Sin(B);
            //float cosB = (float)Math.Cos(B);
 
            //float arksinA = (float)Math.Asin(sinA);
            //float arksinB = (float)Math.Asin(sinB);

            //float sumAB = arksinA + arksinB;

            if (dist < (R + b.R))
            {
                double angle = Math.Atan2(y - b.y, x - b.x);
                double x1 = vX * Math.Cos(-angle) - vY * Math.Sin(-angle);
                double y1 = vX * Math.Sin(-angle) + vY * Math.Cos(-angle);
                double x2 = b.vX * Math.Cos(-angle) - b.vY * Math.Sin(-angle);
                double y2 = b.vX * Math.Sin(-angle) + b.vY * Math.Cos(-angle);
                vX = x2 * Math.Cos(angle) - y1 * Math.Sin(angle);
                vY = x2 * Math.Sin(angle) + y1 * Math.Cos(angle);
                b.vX = x1 * Math.Cos(angle) - y2 * Math.Sin(angle);
                b.vY = x1 * Math.Sin(angle) + y2 * Math.Cos(angle);
            }
        }

        public override void Move()
        {
            x += (int)vX;
            y += (int)vY;

            if (x + R > 1311)
            {
                vX *= -1;
            }

            if (y + R > 622)
            {
                vY *= -1;
            }

            if (x < R)
            {
                vX *= -1;
            }

            if (y < R)
            {
                vY *= -1;
            }
        }

    }   
}   
