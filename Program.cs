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
                Console.Write("Select a language (ger or eng): ");
                language = Console.ReadLine();

                if(language == "ger")
                    Console.Write("Schreibe das Wort, welches die anderen Spieler erraten müssen: ");
                else
                    Console.Write("Write the word the other players need to guess: ");

                wordToGuess = Console.ReadLine();

                g1 = new Game(wordToGuess, language, roundTime);

                if (g1.CheckWord() == false || (!g1.Language.Equals("ger") && !g1.Language.Equals("eng")))
                {
                    g1.Tooltip(2);
                }
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
                    }
                    else
                    {
                        g1.Tooltip(3);
                        g1.NumberOfWrongGuess++;
                    }
                }

                g1.RenderBoard();

                if (g1.NumberOfCorrectLetters == g1.WordToGuess.Length)
                {
                    g1.Tooltip(4);
                    g1.End = true;
                }
                else if (g1.NumberOfWrongGuess == 8)
                {
                    g1.Tooltip(5);
                    g1.End = true;
                }
            }

            Console.ReadKey();
        }
    }
}