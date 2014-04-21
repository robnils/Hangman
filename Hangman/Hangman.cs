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
        private Random r = new Random();
        private string[] lines;

        public Hangman()
        {

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
        public string Draw(string num, int max, string display)
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

    }
}
