using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hangman
{
    class Game
    {
        protected String wordToGuess;
        protected String language;
        protected int sizeOfWord;
        protected int guessTime;
        protected List<char> lettersGuessed;
        protected int numberOfWrongGuesses;
        protected int numberOfCorrectLetters;

        public Game(String wordToGuess, String language, int guessTime)
        {
            this.wordToGuess = wordToGuess;
            this.language = language;
            this.guessTime = guessTime;

            numberOfWrongGuesses = 0;
            numberOfCorrectLetters = 0;
            lettersGuessed = new List<char>();
            
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

            if(!String.IsNullOrEmpty(wordToGuess))
            {
                if (!wordToGuess.Any(char.IsDigit))
                {
                    Regex rgx = new Regex("^A-Za-z");

                    if(!rgx.IsMatch(wordToGuess))
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
            String tempStr = Convert.ToString(letter);

            if (!String.IsNullOrEmpty(tempStr))
            {
                if(!tempStr.Any(char.IsDigit))
                {
                    Regex rgx = new Regex("^A-Za-z");

                    if(!rgx.IsMatch(tempStr))
                    {
                        lettersGuessed.Add(letter);
                        retValue = true;
                    }
                }
            }

            return retValue;
        }

        public String DrawState()
        {
            String lines = String.Empty;

            for(int i = 0; i < sizeOfWord; i++)
            {
                lines += "-" + " ";
            }

            return lines;
        }

        public void RenderBoard()
        {
            Console.Clear();
            Console.WriteLine("Guess a letter of the following " + Language + " word.");
            Console.WriteLine();
            DrawHangman();
            Console.WriteLine();
            Console.WriteLine(DrawState());
            Console.WriteLine();
            
            foreach(char c in lettersGuessed)
            {
                Console.Write(c);
            }

            Console.WriteLine();
            Console.Write("Guess a letter: ");
        }

        public void DrawHangman()
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);

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

        public String Tooltip(int tipNr)
        {
            String retString = String.Empty;

            switch(tipNr)
            {
                case 1: 
                    retString = "Type a letter, upper and lower case can be neglected.";
                    break;
                case 2: 
                    retString = "Wrong input, try again.";
                    break;
                case 3: 
                    retString = "You have " + (8 - numberOfWrongGuesses) + "guesses left.";
                    break;
                case 4:
                    retString = "You guessed every letter of the word " + wordToGuess + ".";
                    break;
                default:
                    break;
            }

            return retString;
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