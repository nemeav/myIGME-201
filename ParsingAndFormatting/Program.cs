using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingAndFormatting
{
    /* Author: Neme Velazquez
     * Purpose: Create a game where the user must guess the number within a certain amount of turns
     * Restrictions: 
     */
    static internal class Program
    {
        /* Purpose: Generate a random number, prompt the user for valid guesses, and respond appropriately
         * Restrictions:
         * Returns: Feedback on guesses?
         */
        static void Main(string[] args)
        {
            //method variables
            Random rand = new Random();
            int? iGuess = null; //set to null to prevent issues with the random number being 0 and they match in the 1st round

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);

            Console.WriteLine(randomNumber); //used for debugging/program testing to ensure right responses provided

            //give the user 8 tries to guess the number, provide feedback, and error handle
            for (int i = 0; i < 8; i++)
            {
                //ends game early once user enters correct number, otherwise: provides direction for guesses
                //put at top of main so it checks the guesses before attempting to start next turn
                if (iGuess == randomNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("Correct! You won in " + i + " turns!");
                    break;
                }
                else if (iGuess < randomNumber)
                {
                    Console.WriteLine("Too low!");
                }
                else if (iGuess > randomNumber)
                {
                    Console.WriteLine("Too high!");
                }

                //main body of game
                Console.Write("Turn #" + (i + 1) + ": Enter your guess: ");

                //more error handling - user must enter a number
                try
                {
                    iGuess = Convert.ToInt32(Console.ReadLine()); //reading and converting in same step reduce chance of error
                }
                catch
                {
                    Console.WriteLine(); //added to improve readability
                    Console.Write("Please enter a valid number for #" + (i + 1) + ": ");
                    iGuess = Convert.ToInt32(Console.ReadLine());
                }


                //error handling - user must enter num within range
                while (iGuess < 0 || iGuess > 100)
                {
                    Console.WriteLine(); //added to improve readability
                    Console.Write("Please enter a number from 0-100 for #" + (i + 1) + ": ");
                    iGuess = Convert.ToInt32(Console.ReadLine());
                }
            }


            //too many tries response
            if (iGuess != randomNumber)
            {
                Console.WriteLine();
                Console.WriteLine("Oh no! You ran out of turns.");
                Console.WriteLine("The number was " + randomNumber + ".");
            }
        }
    }
}
