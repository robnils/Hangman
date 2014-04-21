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

        public Hangman()
        {
            r = new Random();
            guessedValues = "";
            lives = 5; 
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
            return lines[r.Next(0, lines.Length)];
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
