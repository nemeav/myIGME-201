using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NVelazquez_Variables_and_Expression
{
    /* Author: Neme Velazquez
     * 9.6.23
     * Purpose: Prompt the user for 4 numbers and multiply them together
     * Issues: None
     */
    internal class Program
    {
        static void Main(string[] args)
        {   
            //store user input variables for later use
            string sNumOne = null;
            string sNumTwo = null;
            string sNumThree = null;
            string sNumFour = null;

            //variable to store converted inputs
            int? iNumOne = null;
            int? iNumTwo = null;
            int? iNumThree = null;
            int? iNumFour = null;

            //store the value of all values multiplied to be printed
            int iProduct = 0;


            //prompt user for each number + read the input
            Console.Write("Hello there! Please enter your first number: ");
            sNumOne = Console.ReadLine();

            //error handling in case user does not enter numbers
            //I'm sure there's a more efficient way to do this but with my current knowledge of C#, I don't know
            //couldn't figure out do/while with this scenario so used regular while
            while (iNumOne == null)
            {
                try
                {
                    iNumOne = Convert.ToInt32(sNumOne);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer!");
                    sNumOne = Console.ReadLine();
                }
            }

            //continue with asking for input, reading it, and adding error handling
            Console.Write("Please enter your second number: ");
            sNumTwo = Console.ReadLine();
            while (iNumTwo == null)
            {
                try
                {
                    iNumTwo = Convert.ToInt32(sNumTwo);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer!");
                    sNumTwo = Console.ReadLine();
                }
            }

            Console.Write("Please enter your third number: ");
            sNumThree = Console.ReadLine();
            while (iNumThree == null)
            {
                try
                {
                    iNumThree = Convert.ToInt32(sNumThree);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer!");
                    sNumThree = Console.ReadLine();
                }
            }

            Console.Write("Please enter your last number: ");
            sNumFour = Console.ReadLine();
            while (iNumFour == null)
            {
                try
                {
                    iNumFour = Convert.ToInt32(sNumFour);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer!");
                    sNumFour = Console.ReadLine();
                }
            }

            //multiplying all the user's gathered numbers
            //adding int solves the issue from trying to operate with int? values
            iProduct = (int)(iNumOne * iNumTwo * iNumThree * iNumFour);

            //verifying user's choices (and also helped in debugging)
            Console.WriteLine("You have entered: ");
            Console.WriteLine(sNumOne);
            Console.WriteLine(sNumTwo);
            Console.WriteLine(sNumThree);
            Console.WriteLine(sNumFour);

            //print result to console
            Console.WriteLine("The product is " + iProduct);
        }
    }
}
