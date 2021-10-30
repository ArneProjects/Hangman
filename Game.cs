using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class Game
    {
        protected String wordToGuess;
        protected String language;
        protected int sizeOfWord;
        protected int guessTime;
        protected int numberOfWrongGuesses;
        protected int numberOfCorrectLetters;
        protected List<char> lettersGuessed;
        protected List<char> currentState;

        public Game(String wordToGuess, String language, int guessTime)
        {
            this.wordToGuess = wordToGuess;
            this.language = language;
            this.guessTime = guessTime;

            sizeOfWord = wordToGuess.Length;
            numberOfWrongGuesses = 0;
            numberOfCorrectLetters = 0;
            lettersGuessed = new List<char>();
            currentState = new List<char>();
            
        }

        public String Language 
        {
            get { return language; }
            set { language = value; }
        }

        public bool End { get; set; }

        public bool CheckWord()
        {
            bool retValue = false;

            if (!String.IsNullOrEmpty(wordToGuess))
            {
                if (!wordToGuess.Any(char.IsDigit))
                {
                    Regex rgx = new Regex("^A-Za-z");

                    if (!rgx.IsMatch(wordToGuess))
                    {
                        sizeOfWord = wordToGuess.Length;

                        retValue = true;
                    }
                }
            }

            return retValue;
        }

        public bool CheckLetter(char letter)
        {
            bool retValue = false;

            if (!String.IsNullOrEmpty(Convert.ToString(letter)))
            {
                if (Char.IsLetter(letter))
                {
                    if (!lettersGuessed.Contains(letter))
                    {
                        lettersGuessed.Add(letter);
                        retValue = true;
                    }
                    else
                    {
                        numberOfWrongGuesses++;
                    }
                }
                else if (letter == '+')
                {
                    Tooltip(1);
                }
                else if (letter == '-')
                {
                    Environment.Exit(0);
                }
                else
                {
                    Tooltip(2);
                }
            }

            return retValue;
        }

        public void DetermineState()
        {
            int posOfChar;

            if (!currentState.Any())
            {
                for (int i = 0; i < sizeOfWord; i++)
                {
                    currentState.Add('_');
                }
            }
            else
            {
                foreach (char c in lettersGuessed)
                {
                    posOfChar = 0;

                    if (wordToGuess.Contains(Convert.ToString(c)))
                    {
                        foreach (char ch in wordToGuess)
                        {
                            if (c == ch)
                            {
                                currentState[posOfChar] = ch;
                            }

                            posOfChar++;
                        }
                    }
                }                
            }
        }

        public void RenderBoard()
        {
            Console.Clear();

            switch (language)
            {
                case ("ger"):
                    Console.WriteLine("Drücke ' + ' für die Hilfe oder ' - ' um das Spiel zu beenden.");
                    Console.WriteLine();
                    Console.WriteLine();
                    DrawHangman();
                    Console.WriteLine();
                    Console.WriteLine();
                    DetermineState();

                    foreach (char c in currentState)
                    {
                        Console.Write(c);
                        Console.Write(' ');
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Bisherige Buchstaben: ");

                    foreach (char c in lettersGuessed)
                    {
                        Console.Write(c);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Errate einen Buchstaben: ");
                    break;

                case ("eng"):
                    Console.WriteLine("Press ' + ' for help or ' - ' for exiting the game.");
                    Console.WriteLine();
                    Console.WriteLine();
                    DrawHangman();
                    Console.WriteLine();
                    Console.WriteLine();
                    DetermineState();

                    foreach (char c in currentState)
                    {
                        Console.Write(c);
                        Console.Write(' ');
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Guessed letters so far: ");

                    foreach (char c in lettersGuessed)
                    {
                        Console.Write(c);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Guess a letter: ");
                    break;

                default:
                    break;
            }
        }

        public void DrawHangman()
        {
            Console.OutputEncoding = Encoding.GetEncoding(28591);

            switch (numberOfWrongGuesses)
            {
                case 0: 
                    for (int i = 0; i < 7; i++)
                        Console.WriteLine();
                    break;

                case 1:
                    Console.WriteLine("________");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;

                case 2:
                    Console.WriteLine("________");
                    Console.WriteLine("        |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;

                case 3:
                    Console.WriteLine("________");
                    Console.WriteLine("        |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;

                case 4:
                    Console.WriteLine("________");
                    Console.WriteLine("        |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("/|      |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;

                case 5:
                    Console.WriteLine("________");
                    Console.WriteLine("        |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("/|" + (char) 92 +"     |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;

                case 6:
                    Console.WriteLine("________");
                    Console.WriteLine("        |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("/|" + (char)92 + "     |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("/       |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;

                case 7:
                    Console.WriteLine("________");
                    Console.WriteLine("        |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("/|" + (char)92 + "     |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("/ " + (char)92 + "     |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;

                case 8:
                    Console.WriteLine("________");
                    Console.WriteLine(" |      |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("/|" + (char)92 + "     |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("/ " + (char)92 + "     |");
                    Console.WriteLine("        |");
                    Console.WriteLine("----------");
                    break;
            }
        }

        public void Tooltip(int tipNr)
        {
            String tempStr = String.Empty;

            switch(tipNr)
            {
                case 1:
                    if (language == "ger")
                        tempStr = "Tippe einen Buchstaben, Groß- und Kleinschreibung kann ignoriert werden.";
                    else
                        tempStr = "Type a letter, upper and lower case can be neglected.";
                    break;

                case 2:
                    if (language == "ger")
                        tempStr = "Eingabe war kein Buchstabe, versuche es erneut.";
                    else
                        tempStr = "Input wasn't a letter, try again.";
                    break;

                case 3:
                    if (language == "ger")
                        tempStr = "Falscher Buchstabe, du hast noch " + (7 - numberOfWrongGuesses) + " Versuche.";
                    else
                        tempStr = "Wrong letter, you have " + (7 - numberOfWrongGuesses) + " guesses left.";
                    break;

                case 4:
                    if (language == "ger")
                        tempStr = "Du hast jeden Buchstaben des Wortes >> " + wordToGuess + " << erraten.";
                    else
                        tempStr = "You guessed every letter of the word >> " + wordToGuess + " <<.";
                    break;

                case 5:
                    if (language == "ger")
                        tempStr = "Du hast das Wort >> " + wordToGuess + " << NICHT erraten.";
                    else
                        tempStr = "You weren't able to guess the word >> " + wordToGuess + " <<.";
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine(tempStr);
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public String WordToGuess
        {
            get { return wordToGuess; }
            set { wordToGuess = value; }
        }

        public int NumberOfWrongGuess
        {
            get { return numberOfWrongGuesses; }
            set { numberOfWrongGuesses = value; }
        }

        public int NumberOfCorrectLetters
        {
            get { return numberOfCorrectLetters; }
            set { numberOfCorrectLetters = value; }
        }
    }
}