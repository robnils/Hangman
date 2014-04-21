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
    public partial class Main : Form
    {
        // Drawing data for the dashed lines 
        //private int initx = 50;
        //private int inity = 150;
        //private int length = 120;
                
        public Main()
        {
            InitializeComponent();
        }

        private void Hangman_Load(object sender, EventArgs e)
        {
            // Display Text box
            richTextBoxDisplay.SelectAll();
            richTextBoxDisplay.SelectionAlignment = HorizontalAlignment.Center;            
            richTextBoxDisplay.Font = new Font("Comic Sans MS", 25.0F,FontStyle.Regular);
            richTextBoxDisplay.ForeColor = Color.Blue;
            richTextBoxDisplay.Text = "_AA_AB";
                        

            // Typing text box
            richTextBoxEntry.SelectAll();
            richTextBoxEntry.SelectionAlignment = HorizontalAlignment.Center;            
            richTextBoxEntry.Font = new Font("Comic Sans MS", 25.0F, FontStyle.Regular);
            richTextBoxEntry.ForeColor = Color.Red;
            richTextBoxEntry.Text = "X";           

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

        // Draws the dashed lines based on the entered number
        private void textBoxTest_TextChanged(object sender, EventArgs e)
        {
            Hangman h = new Hangman();

            richTextBoxDisplay.Text=h.Draw(textBoxTest.Text, 10, richTextBoxDisplay.Text);
            /*             
            int i = 0;
            int j = 0;
            string text = "";

            // The Convert.ToIn32() method will break if you enter "" - this test prevents that
            if (textBoxTest.Text != "")
            {
                i = Convert.ToInt32(textBoxTest.Text);

                while (j < i)
                {
                    text += "_";
                    text += " ";

                    ++j;
                }

                // So we don't display 0 numbers of _
                if (i > 0)
                    richTextBoxDisplay.Text = text;
            }*/
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
