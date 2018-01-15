using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start playing Hangman!");

            // random words
            string[] allWords = { "computer", "jungle", "horse", "building", "america", "snake", "cannon", "wallpaper", "screen", "motorcycle" };

            Random rnd = new Random();

            // choose random word to guess
            string wordToGuess = allWords[rnd.Next(0, allWords.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();
            
            
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            // make listst from all the right and wrong guesses
            List<char> correctGuesses = new List<char>();
            List<char> inCorrectGuesses = new List<char>();

            // declare lives total
            int lives = 5;
            bool won = false;
            int lettersShown = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.Write("Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You already tried this letter {0}, try something else!", guess);
                }

                else if (inCorrectGuesses.Contains(guess)) 
                {
                    Console.WriteLine("You already tried this letter {0}, try something else!", guess);
                }

                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if(wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersShown++;
                        }
                    }
                    
                }

                if (lettersShown == wordToGuess.Length)
                {
                    won = true;
                }

                else
                {
                    inCorrectGuesses.Add(guess);
                    Console.WriteLine("Wrong guess, {0} is not in this word!", guess);
                    lives--;
                }

                Console.WriteLine(displayToPlayer.ToString());

            }

            if (won)
            {
                Console.WriteLine("You won! The Word is {0}!", wordToGuess);
            }
            else
            {
                   Console.WriteLine("No more lives left, the word was {0}. Game over!", wordToGuess);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
