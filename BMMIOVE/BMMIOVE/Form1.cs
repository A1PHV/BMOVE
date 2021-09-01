using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMMIOVE
{
    public partial class Form1 : Form
    {
        World world;
        Random r;
        int n;
        public Form1()
        {
            InitializeComponent();
            world = new World(pictureBox1);
            r = new Random();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = world.Action();
            n++;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            world.AddBall(e.X, e.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                world.balls.Clear();
                world.ions.Clear();
            }

            if (e.KeyCode == Keys.D2)
            {
                world.balls.Clear();
                world.balls.Clear();
                world.balls.Add(new Ball(r.Next(0, 1000), r.Next(0, 1000), 1, 1, 150));
            }

            if (e.KeyCode == Keys.D3)
            {
                world.balls.Clear();
                world.AddIons(0, r.Next(0, 600), 10, 10, 30);
            }
        }
    }
}
