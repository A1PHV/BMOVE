using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMMIOVE
{
    class Ions : Particles
    {
        Font f = new Font("Courier New", 12, FontStyle.Bold | FontStyle.Italic);
        int number;
        string S;
        Random r;
        public Ions(int x, int y, double vX, double vY, int R)
        {
            this.x = x;
            this.y = y;
            this.vX = vX;
            this.vY = vY;
            this.R = R;
            r = new Random();
            number = r.Next(1, 3);
        }

        public override void Show(Graphics g)
        {
            g.FillEllipse(Brushes.Blue, x - R, y - R, 2 * R, 2 * R);
            switch (number)
            { 
                case 1:
                    S = "+";
                    break;
                case 2:
                    S = "-";
                    break;
            }
            g.DrawString(S, f, Brushes.Red, x, y);
        }

        public override void Move()
        {
            x += (int)vX;
        }

        public override void CollusionBall(Ball b)
        {
            throw new NotImplementedException();
        }

        public void CollusionIons(Ions i)
        {
            float dist = (float)Math.Sqrt(Math.Pow(x - i.x, 2) + Math.Pow(y - i.y, 2));

            if (dist < (R + i.R))
            {
                double angle = Math.Atan2(y - i.y, x - i.x);
                double x1 = vX * Math.Cos(-angle) - vY * Math.Sin(-angle);
                double y1 = vX * Math.Sin(-angle) + vY * Math.Cos(-angle);
                double x2 = i.vX * Math.Cos(-angle) - i.vY * Math.Sin(-angle);
                double y2 = i.vX * Math.Sin(-angle) + i.vY * Math.Cos(-angle);
                vX = x2 * Math.Cos(angle) - y1 * Math.Sin(angle);
                vY = x2 * Math.Sin(angle) + y1 * Math.Cos(angle);
                i.vX = x1 * Math.Cos(angle) - y2 * Math.Sin(angle);
                i.vY = x1 * Math.Sin(angle) + y2 * Math.Cos(angle);
            }
        }
    }
}
