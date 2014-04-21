using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Hangman
{
    class Hangman
    {
        private Random r;
        private string[] lines;
        private int position; // the position of the character in the word
        private bool alreadyGuess; // a flag to test if the letter has been already guessed
        char guessChar; // Guessed character from user

        // This is the word as the user sees it, containing some letters, some _'s
        private string word;
        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        // Game over tag
        private bool gameOver = false;
        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        // Current word in play
        private string currentWord; 
        public string CurrentWord
        {
            get { return currentWord; }
            set 
            { 
                currentWord = value; 
            }
        }       

        // Keeps track of the values the user guessed
        private string guessedValues;
        public string GuessedValues
        {
            get { return guessedValues; }
            set { guessedValues = value; }
        }

        // The number of lives the user has
        private int lives;
        public int Lives
        {
            get { return lives; }
            set 
            {
                // Reasonable bounds on the # of lives
                if ((value >= 0) && (value <= 10))
                    lives = value;
            }
        }

        // Contructor
        public Hangman()
        {
            r = new Random();
            guessedValues = "";
            lives = 5;
            position = 0;

            guessChar = '1'; // Temporary failsafe - should crash if there's a bug somewhere
        }

        //Load file with the words - words.txt
        public string[] Load()
        {
            string s = Directory.GetCurrentDirectory();
            s += "\\Words.txt";

            lines = System.IO.File.ReadAllLines(s);

            return lines;
        }

        // Returns a random word from the list of words
        public string ReturnRnd()
        {
            return (lines[r.Next(0, lines.Length)]).ToUpper();
        }

        // Test the entered character
        // True if they got it correct, false otherwise
        public bool Test(string guessed)
        {
            guessChar = Convert.ToChar(guessed);
            position = 0;

            // Test to make sure user  doesn't enter same value twice
            foreach(char c in guessedValues)
            {
                if (c == guessChar)
                {
                    alreadyGuess = true;
                    return false;
                }
            }
            
            // Add code to test if the key is correct, was entered before, deduct lives
            foreach (char c in currentWord)
            {
                // For each character in the word, is the guessed character equal to any one of them?
                if (c == guessChar)
                {
                    // reveal character
                    return true;
                }
                ++position;
            }

            if (lives != 0) // if lives aren't out, deduct a lift
            {
                --lives;
                return false;
            }
            else
            {
                gameOver = true;
                return false; //end the game
            }
                           
        }

        // Uncover the letter
        public void Uncover()
        {
            // movie
            // _o___
            //
            /* currentWord - full
             * word - user seen
             * position
             * */
            for(int i = 0; i < word.Length;++i)
            {
                if(i == position)
                {
                    //word[i] = guessChar;
                }
            }
        }

        // Draws num values of _ into display, up to a max
        public string Draw(string num, int max)
        {
            int i = 0;
            int j = 0;
            string text = "";            

            // The Convert.ToIn32() method will break if you enter "" - this test prevents that
            if (num != "")
            {
                i = Convert.ToInt32(num);
                // If less than max number, draw up to that number
                if (i <= max)
                {
                    while (j < i)
                    {
                        text += "_";
                        text += " ";

                        ++j;
                    }

                    // So we don't display 0 numbers of _
                    if (i > 0)
                        //display = text;
                        return text;
                    else
                        //display = "_"; // Just write one _ if all else fails
                        return "_";
                }
                 
                // Otherwise draw max number
                else
                {
                    text = "";
                    while (j < max)
                    {
                        text += "_";
                        text += " ";

                        ++j;
                    }
                    return text;
                }
            }
            else
                return "_";
        }

        // Draws num values of _ into display, up to a max
        // Overloaded method to use num as an int instead of string
        public string Draw(int num, int max)
        {
            int j = 0;
            string text = "";
                        
            // If less than max number, draw up to that number
            if (num <= max)
            {
                while (j < num)
                {
                    text += "_";
                    text += " ";

                    ++j;
                }

                // So we don't display 0 numbers of _
                if (num > 0)
                    //display = text;
                    return text;
                else
                    //display = "_"; // Just write one _ if all else fails
                    return "_";
            }

            // Otherwise draw max number
            else
            {
                text = "";
                while (j < max)
                {
                    text += "_";
                    text += " ";

                    ++j;
                }
                return text;
            }
          
        }

    }
}
