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


/* Update v.0.2
 * TO DO
 * fix spaces being recognised as a character
 * file exception handling
 * 
 * DONE
 * "You already guessed" appearing if you click New Game in the middle of the game
 * Made editable boxes not editable
 * Fixed CountriesSwe data
 * Fixed bug where "Enter" and "Space" counted as valid guesses
 * Added icons so game doesnt look so unknown and scary
 * */

/*** IDEAS ****/
/* Use an array to store the names of the buttons - like button1.Text = names[1] - easier to switch languages
 * also makes the switch case MUCH easier and not hardcoded
 * 
 *  add lives and guesed values to hangman.cs
 *  add method to remove played words so they dont appear till the next game
 *  open file dialog to specific the words source file so theyre not hardcoded and users can download new ones
 *  throw exception if cant open save file
 *  time trial mode, easy medium hard modes
 *  change fonts
 *  7 lives
 *  english and swedish modes
 *  level scheme - level 1 - 10, 4 letters, 11-20 5 letters, etc
 *  arranage words by topic? 
 *  consider using a bindingsource with the combobox
 *  fix the wordlist[10] hardcoding
 *  put radiobuttons in a group box
 *  words with more than 1 word (el salvador for example)... not sure what happens about that " ". I think it becomes a _. fix it!  
*/
namespace Hangman
{
    public partial class Main : Form
    {
        private Hangman h;
        private int difficultyStatus; // 0,1,2 - easy, medium, hard - so we can programmer user preference
        private int lives;
        private string wordlist; // keeps track of the wordlists being used until ready to be passed to h.Load()
        private string[] lines;
                
        public Main()
        {
            InitializeComponent();

            // Initialisations           
            wordlist = "randomEng";
                       
            // Display Text box
            richTextBoxDisplay.Enabled = false;
            richTextBoxDisplay.SelectAll();
            richTextBoxDisplay.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxDisplay.Font = new Font("Comic Sans MS", 25.0F, FontStyle.Regular);
            richTextBoxDisplay.ForeColor = Color.Blue;
            richTextBoxDisplay.BackColor = Color.Yellow;

            // Typing text box         
            richTextBoxEntry.Enabled = false;
            richTextBoxEntry.SelectAll();
            richTextBoxEntry.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxEntry.Font = new Font("Comic Sans MS", 25.0F, FontStyle.Regular);
            richTextBoxEntry.ForeColor = Color.Red;

            // Lives text box
            richTextBoxLives.Enabled = false;
            richTextBoxLives.SelectAll();
            richTextBoxLives.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxLives.Font = new Font("Comic Sans MS", 55.0F, FontStyle.Regular);
            richTextBoxLives.ForeColor = Color.Green;

            // Guessed Values
            textBoxAlreadyGuessed.Enabled = false;
            richTextBoxGuessed.Enabled = false;
            richTextBoxGuessed.SelectAll();
            richTextBoxGuessed.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxGuessed.Font = new Font("Comic Sans MS", 35.0F, FontStyle.Regular);
            richTextBoxGuessed.ForeColor = Color.Violet;

            // Difficulty settings
            radioButtonEasy.Checked = false;
            radioButtonMedium.Checked = true;
            radioButtonHard.Checked = false;

            // Buttons
            buttonNew.Font = new Font("Comic Sans MS", 12.0F, FontStyle.Bold);
            buttonAbout.Font = new Font("Comic Sans MS", 12.0F, FontStyle.Bold);
            buttonExit.Font = new Font("Comic Sans MS", 12.0F, FontStyle.Bold);

            // Radiobuttons
            radioButtonEasy.Font = new Font("Comic Sans MS", 9.0F, FontStyle.Regular);
            radioButtonMedium.Font = new Font("Comic Sans MS", 9.0F, FontStyle.Regular);
            radioButtonHard.Font = new Font("Comic Sans MS", 9.0F, FontStyle.Regular);

            // Combobox
            //comboBoxWordlist.Visible = false; // hide for now
            //comboBoxWordlist.SelectedIndex = 0;
            //comboBoxWordlist.DropDownStyle = ComboBoxStyle.DropDownList; // makes combobox a select-only list
            //comboBoxWordlist.AutoCompleteSource = AutoCompleteSource.ListItems;
            //comboBoxWordlist.AutoCompleteMode = AutoCompleteMode.Suggest;

            // Wordlists
            radioButtonCountries.Checked = false;
            radioButtonRandom.Checked = true;
            radioButtonCountriesSwe.Checked = false;
            radioButtonRandomSwe.Checked = false;

            radioButtonCountries.Font = new Font("Comic Sans MS", 8.0F, FontStyle.Regular);
            radioButtonRandom.Font = new Font("Comic Sans MS", 8.0F, FontStyle.Regular);
            radioButtonCountriesSwe.Font = new Font("Comic Sans MS", 8.0F, FontStyle.Regular);
            radioButtonRandomSwe.Font = new Font("Comic Sans MS", 8.0F, FontStyle.Regular);

            // Groupbox text
            groupBoxDifficulty.Font = new Font("Comic Sans MS", 9.0F, FontStyle.Bold);
            groupBoxWordlists.Font = new Font("Comic Sans MS", 9.0F, FontStyle.Bold);

            // Hide diagnostic buttons
            buttonWord.Visible = false; 
        }

        private void Hangman_Load(object sender, EventArgs e)
        {
            if (wordlist == "randomEng")
            {
                radioButtonRandom.Checked = true;
            }

            else if (wordlist == "countriesEng")
            {
                radioButtonCountries.Checked = true;
            }

            else if (wordlist == "randomSwe")
            {
                radioButtonRandomSwe.Checked = true;
            }

            else if (wordlist == "countriesSwe")
            {
                radioButtonCountriesSwe.Checked = true;
            }
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
            // Easiest way - uses constructor to initialise everything
            h = new Hangman(); 
            lines = h.Load(wordlist); //Loads the List of words
            h.Lives = lives; // Gives lives according to difficulty    
            richTextBoxLives.Text = Convert.ToString(h.Lives);
            richTextBoxGuessed.Text = h.GuessedValues;
            textBoxAlreadyGuessed.Text = "";
            richTextBoxEntry.Text = "";

            // Don't let user change diffculty or wordlists during game
            radioButtonEasy.Enabled = false;
            radioButtonMedium.Enabled = false;
            radioButtonHard.Enabled = false;
            radioButtonCountries.Enabled = false;
            radioButtonRandom.Enabled = false;
            radioButtonCountriesSwe.Enabled = false;
            radioButtonRandomSwe.Enabled = false;

            string st = "";
            int num = 0;
            st = h.ReturnRnd(); // returns a random word from the list
            h.CurrentWord = st; // Updates the class with the current word

            foreach (char c in st)
            {
                ++num;
            }

            richTextBoxDisplay.Text = h.Draw(num, 10); // The word the user sees starts off as all _'s
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
                // Test to make sure input is a letter
                // Done for 1) good data reasons, and 2) so enter, space, numbers, etc don't count as guesses
                // For some reason, "" counts... The code below fixes it
                if (richTextBoxEntry.Text.All(Char.IsLetter) && (richTextBoxEntry.Text != ""))
                {
                    textBoxAlreadyGuessed.Text = ""; // Reset the notification
                    h.GuessedValues += richTextBoxEntry.Text; // add entered text to guessed values
                    h.GuessedValues += " "; // nicer formatting
                    richTextBoxGuessed.Text = h.GuessedValues;

                    // 
                    // Add code to test if the key is correct, was entered before, deduct lives
                    //
                    // If character is guessed correctly (returns true)
                    h.Test(richTextBoxEntry.Text);

                    // If the game is over, stop
                    if (h.GameOver == true)
                    {

                        // Graphical glitch quick fix
                        richTextBoxLives.Text = "0";
                        h.Lives = 0; // for some reason this doesn't work properly in the class

                        // Reveal all the letters 
                        richTextBoxDisplay.Text = h.AddSpaces(h.CurrentWord);

                        // Make boxes enabled/disabled
                        richTextBoxEntry.Enabled = false;

                        if (h.GameWin == false)
                            MessageBox.Show("Too bad, you lose!",
                                "Game over!", MessageBoxButtons.OK);

                        else
                            MessageBox.Show("Congratulations, you win!",
                                "Game over!", MessageBoxButtons.OK);
                        Clear();
                        Hangman_Load(sender, e);
                    }

                    if (h.Lives != 0)
                    {
                        // If the user already guessed the letter, let them know
                        if (h.AlreadyGuess)
                            textBoxAlreadyGuessed.Text = "You already guessed " + richTextBoxEntry.Text
                                + "!";

                        // Carry on otherwise
                        richTextBoxLives.Text = Convert.ToString(h.Lives);
                        richTextBoxDisplay.Text = h.AddSpaces(h.Guessword);
                        richTextBoxEntry.Text = ""; // clear entry box
                    }
                }
            }
            else
                richTextBoxEntry.Text = "";
        }

        private void radioButtonEasy_CheckedChanged(object sender, EventArgs e)
        {
            lives = 9;
            difficultyStatus = 0;
        }

        private void radioButtonMedium_CheckedChanged(object sender, EventArgs e)
        {
            lives = 6;
            difficultyStatus = 1;
        }

        private void radioButtonHard_CheckedChanged(object sender, EventArgs e)
        {
            lives = 4;
            difficultyStatus = 2;
        }

        // Clears and resets everything
        private void Clear()
        {
            richTextBoxLives.Text = " ";
            richTextBoxDisplay.Text = " ";
            richTextBoxEntry.Text = " ";
            richTextBoxGuessed.Text = " ";

            // Rename "New Game" button
            buttonNew.Text = "Play again?";

            // Difficulty & Wordlist settings
            radioButtonEasy.Enabled = true;
            radioButtonMedium.Enabled = true;
            radioButtonHard.Enabled = true;
            radioButtonRandom.Enabled = true;
            radioButtonCountries.Enabled = true;
            radioButtonRandomSwe.Enabled = true;
            radioButtonCountriesSwe.Enabled = true;

            switch(difficultyStatus)
            {
                case 0:
                    // Difficulty settings
                    radioButtonEasy.Checked = true;
                    radioButtonMedium.Checked = false;
                    radioButtonHard.Checked = false;
                    break;
                case 1:
                    // Difficulty settings
                    radioButtonEasy.Checked = false;
                    radioButtonMedium.Checked = true;
                    radioButtonHard.Checked = false;
                    break;
                case 2:
                    // Difficulty settings
                    radioButtonEasy.Checked = false;
                    radioButtonMedium.Checked = false;
                    radioButtonHard.Checked = true;
                    break;
            }            
        }

        private void comboBoxWordlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButtonCountries_CheckedChanged(object sender, EventArgs e)
        {
            wordlist = "countriesEng";
        }

        private void radioButtonRandom_CheckedChanged(object sender, EventArgs e)
        {
            wordlist = "randomEng";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            wordlist = "randomSwe";
        }

        private void radioButtonCountriesSwe_CheckedChanged(object sender, EventArgs e)
        {
            wordlist = "countriesSwe";
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Robert Nils Hilliard 2014.\nCompletely free and without warranty."
                , "About the creator",MessageBoxButtons.OK);
        }
    }
}
