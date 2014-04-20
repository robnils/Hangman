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


/*** IDEAS ****/
/* Use an array to store the names of the buttons - like button1.Text = names[1] - easier to switch languages
 * also makes the switch case MUCH easier and not hardcoded
 * 
 * 
*/
namespace Hangman
{
    public partial class Hangman : Form
    {
        // Drawing data for the dashed lines 
        //private int initx = 50;
        //private int inity = 150;
        //private int length = 120;
                
        public Hangman()
        {
            InitializeComponent();
        }

        private void Hangman_Load(object sender, EventArgs e)
        {
            richTextBoxDisplay.SelectAll();
            richTextBoxDisplay.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxDisplay.Text = "_AA_AB";
            richTextBoxDisplay.Font = new Font(new FontFamily("Comic Sans MS"), 25.0F);
            


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

        // New Button
        private void button7_Click(object sender, EventArgs e)
        {

        }

      
        private void Hangman_Paint(object sender, PaintEventArgs e)
        {
            /*
            Graphics g = e.Graphics;

            using (Pen p = new Pen(Color.Black, 2))
            {
                g.DrawLine(p, initx, inity, length, inity);

            } */         
        }

      
        private void textBoxEntry_TextChanged(object sender, EventArgs e)
        {
            switch(richTextBoxEntry.Text)
            {
                case "a":
                    richTextBoxEntry.Text = "cool";
                    break;
                default:
                    //textBoxEntry.Text = "";
                    break;
            }

            //textBoxEntry.Text = "";
        }
    }
}
