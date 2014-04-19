using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace Hangman
{
    public partial class Hangman : Form
    {
        public Hangman()
        {
            InitializeComponent();
        }

        private void Hangman_Load(object sender, EventArgs e)
        {
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g;

            g = e.Graphics;

            Pen myPen = new Pen(Color.Red);
            myPen.Width = 30;
            g.DrawLine(myPen, 30, 30, 45, 65);

            g.DrawLine(myPen, 1, 1, 45, 65);
        }
         * */

        private void Hangman_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            using (Pen p = new Pen(Color.Black, 3))
            {
                g.DrawLine(p, 100, 100, 150, 100);
            } 
        }
    }
}
