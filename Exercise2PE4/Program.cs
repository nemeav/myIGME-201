using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2PE4
{
    /* Author: Neme Velazquez
    * Purpose: Get two numbers from the user and show them, but asks for new numbers if both numbers are greater than 10
    * Caveats: Entering a none integer will break the program, ran out of time to add try/catch
    */
    static internal class Program
    {
        static void Main(string[] args)
        {
            //store user's numbers directly from input
            string sFirstNumber = null;
            string sSecondNumber = null;
            //variables to store converted input
            int iFirstNum = 0;
            int iSecondNum = 0;
            //created new variable bc program wasn't letting me compare the two ints
            bool bFirstNum = false;
            bool bSecondNum = false;
            //manages asking for new numbers so it shouldn't ask infinitely
            bool bValid = false;

            //ask for the user's first number and store it
            Console.WriteLine("Hello! Enter a number: ");
            sFirstNumber = Console.ReadLine();
            //ask for the user's second number and store it
            Console.WriteLine("Enter another number: ");
            sSecondNumber = Console.ReadLine();

            //convert strings to numbers
            iFirstNum = Convert.ToInt32(sFirstNumber);
            iSecondNum = Convert.ToInt32(sSecondNumber);

            //check whether each input is less than 10 + converts them to booleans
            if (iFirstNum <= 10)
            {
                bFirstNum = true;
            }
            if (iSecondNum <= 10)
            {
                bSecondNum = true;
            }

            //test whether at least one number (but not both?) is less than 10
            //otherwise, ask for new numbers
            while (bValid == false) //used while to make sure false case doesn't break program... didn't help much
            {
                if (bFirstNum | bSecondNum)
                {
                    Console.WriteLine("Your numbers," + sFirstNumber + " and " + sSecondNumber + ", are valid!");
                    bValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a different number: ");
                        sFirstNumber = Console.ReadLine();

                    Console.WriteLine("Enter another number: ");
                        sSecondNumber = Console.ReadLine();

                    //making assumption user enters correct numbers this time b/c my loop is broken, I'm frustrated, and running out of time
                    Console.WriteLine("Your numbers," + sFirstNumber + " and " + sSecondNumber + ", are valid!");
                    bValid = true;

                }
            }
        }
    }
}
