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
        private int correctGuesses; // when this number equals length of currentWord, they win
        char guessChar; // Guessed character from user

        private bool alreadyGuess; // a flag to test if the letter has been already guessed
        public bool AlreadyGuess
        {
            get { return alreadyGuess; }
            set { alreadyGuess = value; }
        }

        // This is the word as the user sees it, containing some letters, some _'s
        private string guessword;
        public string Guessword
        {
            get { return guessword; }
            set { guessword = value; }
        }

        // Game over tag
        private bool gameOver;
        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        // Game win flag
        private bool gameWin;
        public bool GameWin
        {
            get { return gameWin; }
            set { gameWin = value; }
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
            alreadyGuess = false;
            correctGuesses = 0;
            gameOver = false;
            gameWin = false;

            guessChar = '1'; // Temporary failsafe - should crash if there's a bug somewhere
        }

        public void Initialise(string cw)
        {
            currentWord = cw;
            guessword = "";

            // Initialise the guessword
            for (int i = 0; i < currentWord.Length; ++i)
                guessword += "_";
        }

        // Function to add spaces to the words for drawing, probably going to be the guessword
        public string AddSpaces(string text)
        {
            string tmp = "";

            for (int i = 0; i < text.Length; ++i)
            {
                tmp += guessword[i];
                tmp += " ";
            }

            return tmp;
        }

        //Load file with the words - words.txt
        public string[] Load()
        {
            string s = Directory.GetCurrentDirectory();
            s += "\\Words_Eng.txt";

            lines = System.IO.File.ReadAllLines(s);

            return lines;
        }

        // Load with regard to a specific language
        public string[] Load(string language)
        {
            string s = Directory.GetCurrentDirectory();

            switch (language.ToLower())
            {
                case "english":
                    s += "\\Words_Eng.txt";
                    break;
                case "swedish":
                    s += "\\Words_Swe.txt";
                    break;
                default:
                    break;
            }

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

            // Test to make sure user  doesn't enter same value twice            
            int i = 0; // Need two occurences of a letter to be counted as guessed already
            alreadyGuess = false; // Assume false first
            foreach(char c in guessedValues)
            {
                if (c == guessChar)
                {
                    ++i;
                    if(i == 2)
                    {
                        alreadyGuess = true;
                        return false;
                    }
                }                       
            }
            
            // Add code to test if the key is correct, was entered before, deduct lives            
            char[] guess = new char[guessword.Length];
            for (int j = 0; j < guessword.Length; ++j)
            {
                guess[j] = guessword[j];
            }

            int k = 0;
            bool test = false;
            foreach (char c in currentWord)
            {
                // For each character in the word, is the guessed character equal to any one of them?
                if (c == guessChar)
                {
                    // Reveal character
                    guess[k] = c;
                    test = true; // just used to trigger the next if

                    ++correctGuesses; // increase number of correct guesses
                    if(correctGuesses == currentWord.Length) // breaks loop if they reach max
                    {
                        gameOver = true;
                        gameWin = true;
                        return true;
                    }
                }
                ++k;
            }

            // If the user triggered a correct letter, then don't deduct lives,
            // just turn the array back into the string so it can be used later
            if (test == true)
            {                
                guessword = "";
                for (int j = 0; j < guess.Length; ++j)
                {
                    guessword += guess[j];
                }

                return true;
            }
                

            else if (lives > 1) // if lives aren't out, deduct a lift
            {
                --lives;
                return false;
            }
            else
            {
                gameOver = true;
                gameWin = false;
                return false; //end the game
            }
                           
        }

        // Uncover the letter
        // Take in the word
        public void Uncover()
        {
            
        }
        /*
        public void Uncover()
        {
            // movie
            // _o___
            //
            /* currentWord - full
             * word - user seen
             * position
             
            string tmp = "";
            for(int i = 0; i < word.Length;++i)
            {
                // Now reveal the one they chose a specific turn
                if (i == position)
                {
                    //word[i] = guessChar;
                    tmp += guessChar;
                    tmp += " ";
                }   

                // If the word is uncovered, keep it that way
                else if ((word[i] == '_') || (word[i] == ' '))
                {
                    if(word[i] == '_')
                    {
                        tmp += "_";
                        tmp += " ";
                    }
                }

                // Otherwise, reveal it by comparing it to the known word
                // This is for characters previously revealed
                else
                {
                    tmp += currentWord[i];
                    tmp += " ";
                }                             
            }
            word = tmp;
        }*/

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
