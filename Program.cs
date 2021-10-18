using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            String wordToGuess;
            String language;
            char guessedLetter;
            int roundTime = 10;

            Game g1;

            do
            {
                Console.Clear();
                Console.Write("Write the word the other players need to guess: ");
                wordToGuess = Console.ReadLine();

                Console.Write("Write the language of the word (ger or eng): ");
                language = Console.ReadLine();

                g1 = new Game(wordToGuess, language, roundTime);
            }
            while (g1.CheckWord() == false || (!g1.Language.Equals("ger") && !g1.Language.Equals("eng")));

            g1.End = false;
            g1.RenderBoard();

            while(!g1.End)
            {
                guessedLetter = Console.ReadKey().KeyChar;

                if(g1.CheckLetter(guessedLetter))
                {
                    if(g1.WordToGuess.Contains(Convert.ToString(guessedLetter)))
                    {
                        g1.NumberOfCorrectLetters += g1.WordToGuess.Count(x => x == guessedLetter);

                        if (g1.NumberOfCorrectLetters == g1.WordToGuess.Length)
                        {
                            g1.Tooltip(4);
                            g1.End = true;
                        }
                    }
                    else
                    {
                        g1.Tooltip(3);
                        g1.NumberOfWrongGuess++;

                        if (g1.NumberOfWrongGuess == 8)
                            g1.End = true;
                    }
                }
                else
                {
                    g1.Tooltip(2);
                }

                g1.RenderBoard();
            }

            Console.ReadKey();
        }
    }
}
