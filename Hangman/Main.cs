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
 *  open file dialog to specific the words source file so theyre not hardcoded and users can download new ones
 *  throw exception if cant open save file
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
            textBoxLives.Enabled = false;
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
      
            // Hide diagnostic buttons
            textBox1.Visible = false;
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
            // Create a new instance for each game 
            // Easiest way - uses constructed to initialise everything
            h = new Hangman(); 
            lines = h.Load(); // Loads the list of words
            textBoxLives.Text = Convert.ToString(h.Lives);
            textBoxGuessed.Text = h.GuessedValues;

            string st = "";
            int num = 0;
            st = h.ReturnRnd(); // returns a random word from the list
            h.CurrentWord = st; // Updates the class with the current word
            textBox1.Text = st; // Diagnostic purposes

            foreach (char c in st)
            {
                ++num;
            }

            richTextBoxDisplay.Text = h.Draw(num, 10); // The word the user sees starts off as all _'s
           // richTextBoxDisplay.Text = h.Word;
            h.Initialise(st);
            richTextBoxEntry.Enabled = true;

            // Gives focus of form onto the textbox
            this.ActiveControl = richTextBoxEntry;
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
                textBoxAlreadyGuessed.Text = ""; // Reset the notification
                h.GuessedValues += richTextBoxEntry.Text; // add entered text to guessed values
                h.GuessedValues += ","; // nicer formatting
                textBoxGuessed.Text = h.GuessedValues; // display it

                // 
                // Add code to test if the key is correct, was entered before, deduct lives
                //
                // If character is guessed correctly (returns true)
                h.Test(richTextBoxEntry.Text);                    

                // If the game is over, stop
                if(h.GameOver == true)
                {
                    if (h.GameWin == false)
                    {
                        // Graphical glitch quick fix
                        textBoxLives.Text = "0";

                        // Reveal all the letters 
                        richTextBoxDisplay.Text = h.AddSpaces(h.CurrentWord);

                        // Make boxes enabled/disabled
                        richTextBoxEntry.Enabled = false;

                        // Ask do they want to play again?
                        DialogResult dialog = MessageBox.Show("Too bad, you lose! Play again?",
                            "Game over!", MessageBoxButtons.YesNo);

                        // Click New button
                        if (dialog == DialogResult.Yes)
                            button7_Click(sender, e);

                        else
                            buttonExit_Click(sender, e);

                    }

                    else
                    {
                        // Reveal all the letters 
                        richTextBoxDisplay.Text = h.AddSpaces(h.CurrentWord);
                        this.Refresh();


                        // Make boxes enabled/disabled
                        richTextBoxEntry.Enabled = false;

                        // Ask do they want to play again?
                        DialogResult dialog = MessageBox.Show("Congratulations, you win! Play again?",
                            "Game over!", MessageBoxButtons.YesNo);

                        // Click New button
                        if (dialog == DialogResult.Yes)
                            button7_Click(sender, e);

                        else
                            buttonExit_Click(sender, e);
                    }
                }

                // If the user already guessed the letter, let them know
                if (h.AlreadyGuess)
                    textBoxAlreadyGuessed.Text = "You already guessed " + richTextBoxEntry.Text
                        + "!";

                // Carry on otherwise
                textBoxLives.Text = Convert.ToString(h.Lives);
                richTextBoxDisplay.Text = h.AddSpaces(h.Guessword);
                richTextBoxEntry.Text = ""; // clear entry box
            }
        }
    }
}
