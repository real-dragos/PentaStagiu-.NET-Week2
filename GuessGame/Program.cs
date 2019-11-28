using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    class Program
    {
        //Main Program - Guessing Game
        static void Main(string[] args)
        {
            const int MIN_INTERVAL = 0;
            const int MAX_INTERVAL = 100;
            int winningNumber = GenerateRandomNumber(MIN_INTERVAL, MAX_INTERVAL);
            bool winner = false;
            int noOfAttempts = 0;

            Console.WriteLine("Welcome to the Guess Game! Choose a number from {0} to {1}", MIN_INTERVAL, MAX_INTERVAL);
            
            while (!winner)
            {
                Console.WriteLine("Please enter a number: ");
                int guess = ReadNumber();
                if (IsNumberInRange(guess, MIN_INTERVAL, MAX_INTERVAL))
                {
                    noOfAttempts++;
                    winner = CheckWinningCondition(guess, winningNumber);
                }
                else
                {
                    Console.WriteLine($"Your number is not between {MIN_INTERVAL} and {MAX_INTERVAL}!");
                }
                
            }

            Console.WriteLine($"You guessed the winning number ({winningNumber}) in {noOfAttempts} attempts");
            if(noOfAttempts == 1)
            {
                Console.WriteLine("WOW! You are a Wizard!");
            }
        }

        /// <summary>
        /// Read a number from the keyboard
        /// </summary>
        /// <returns>
        ///     returns a number
        /// </returns>
        static int ReadNumber()
        {
            int result;
            string input;
            bool valid;
            do
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                valid = int.TryParse(input, out result);
                if (!valid)
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (!valid);
            return result;
        }

        /// <summary>
        /// Generates a random number in the given interval
        /// </summary>
        /// <param name="min">lower bound of the interval</param>
        /// <param name="max">upper bound of the interval</param>
        /// <returns>
        ///     the generated random number
        /// </returns>
        static int GenerateRandomNumber(int min, int max)
        {
            Random rng = new Random();
            return rng.Next(min, max);
        }

        /// <summary>
        /// Check if a number is in the range of the given interval/range
        /// </summary>
        /// <param name="guess">the input number</param>
        /// <param name="min">the lower bound of the interval</param>
        /// <param name="max">the upper bound of the interval</param>
        /// <returns>
        ///     true - if the number is in the range
        ///     false - if the number is out of range
        /// </returns>
        static bool IsNumberInRange(int guess, int min, int max)
        {
            if(guess < min || guess > max)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if the number the user guessed is correct or not and print a message corresponding to each situation
        /// </summary>
        /// <param name="guess">The guess of the user</param>
        /// <param name="winningNumber">The winning number</param>
        /// <returns>
        ///    true - if the guess is equal to the winning number
        ///    false - otherwise 
        /// </returns>
        static bool CheckWinningCondition(int guess, int winningNumber)
        {
            if(guess == winningNumber)
            {
                Console.WriteLine("Your guess is correct! You won!");
                return true;
            }
            else if(guess > winningNumber)
            {
                Console.WriteLine("Your guess is too big! Try a smaller number");
            }
            else
            {
                Console.WriteLine("Your guess is too small! Try a bigger number");
            }
            return false;
        }
    }
}
