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
 *  add lives and guesed values to hangman.cs
 *  add method to remove played words so they dont appear till the next game
 * 
*/
namespace Hangman
{
    public partial class Main : Form
    {
        private Hangman h;
        private string[] lines;
                
        public Main()
        {
            InitializeComponent();
        }

        private void Hangman_Load(object sender, EventArgs e)
        {
            // Initialisations
            h = new Hangman();
            lines = h.Load();
            textBoxLives.Enabled = false;
            textBoxLives.Text = Convert.ToString(h.Lives);
            richTextBoxEntry.Enabled = false;
            textBoxGuessed.Enabled = false;

            // Display Text box
            richTextBoxDisplay.SelectAll();
            richTextBoxDisplay.SelectionAlignment = HorizontalAlignment.Center;            
            richTextBoxDisplay.Font = new Font("Comic Sans MS", 25.0F,FontStyle.Regular);
            richTextBoxDisplay.ForeColor = Color.Blue;
                        

            // Typing text box
            richTextBoxEntry.SelectAll();
            richTextBoxEntry.SelectionAlignment = HorizontalAlignment.Center;            
            richTextBoxEntry.Font = new Font("Comic Sans MS", 25.0F, FontStyle.Regular);
            richTextBoxEntry.ForeColor = Color.Red;
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
        // Starts the game
        private void button7_Click(object sender, EventArgs e)
        {
            string st = "";
            int num = 0;
            st = h.ReturnRnd(); // returns a random word from the list
            h.CurrentWord = st; // Updates the class with the current word
            textBox1.Text = st;

            foreach (char c in st)
            {
                ++num;
            }
 
            //richTextBoxDisplay.Text = h.Draw(num, 10);
            h.Word = h.Draw(num, 10); // The word the user sees starts off as all _'s
            richTextBoxDisplay.Text = h.Word;
            richTextBoxEntry.Enabled = true;
        }
              
        private void Hangman_Paint(object sender, PaintEventArgs e)
        {     
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
        }

        // Draws the dashed lines based on the entered number
        private void textBoxTest_TextChanged(object sender, EventArgs e)
        {
            Hangman h = new Hangman();

            richTextBoxDisplay.Text=h.Draw(textBoxTest.Text, 10);           
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBoxEntry_TextChanged(object sender, EventArgs e)
        {
            // Make all entered text upper - looks neater
            String s = "";
            s=richTextBoxEntry.Text;
            richTextBoxEntry.Text = s.ToUpper();

            // Only accept one letter in the textbox
            if (s.Length > 1)
            {
                s = Convert.ToString(s[0]);
                richTextBoxEntry.Text = s.ToUpper();
            }            
        }

        private void richTextBoxEntry_KeyPress(object sender, KeyPressEventArgs e)
        {            
        }

        private void richTextBoxEntry_KeyDown(object sender, KeyEventArgs e)
        {
            // One user hits enter, accept the letter and clear the textbox
            if (e.KeyCode == Keys.Enter)
            {
                h.GuessedValues += richTextBoxEntry.Text; // add entered text to guessed values
                h.GuessedValues += ","; // nicer formatting
                textBoxGuessed.Text = h.GuessedValues; // display it

                // 
                // Add code to test if the key is correct, was entered before, deduct lives
                //
                // If character is guessed correctly (returns true)
                if (h.Test(richTextBoxEntry.Text))
                    h.Uncover(); // Uncover 

                // If the game is over, stop
                else if(h.GameOver == true)
                {
                    // Reveal all the letters 
                    // Make boxes enabled/disabled
                    // Ask do they want to play again?
                }

                // Carry on otherwise
                textBoxLives.Text = Convert.ToString(h.Lives);
                richTextBoxDisplay.Text = h.Word;
                richTextBoxEntry.Text = ""; // clear entry box
            }
        }
    }
}
