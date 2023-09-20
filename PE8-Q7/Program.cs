using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Q7
{
    /* Author: Neme Velazquez
     * Purpose: Create a program that accepts a string and returns it in reverse order
     * Restrictions: None
     */
    static internal class Program
    {
        /* Purpose: Ask user to enter a string, convert it into characters, and print it in reverse order
         * Restrictions: None
         * Returns: reversed string of original
         */
        static void Main(string[] args)
        {
            //variable - stores user input
            string inputString = "";
            
            //prompt user for input and store
            Console.Write("Hello! Enter some words, some characters, some keyboard smash if you will: ");
            inputString = Console.ReadLine();

            //convert string to array of characters and creates empty array to be added to (reverse string)
            char[] userString = inputString.ToCharArray();
            char[] outputString = new char[userString.Length];

            
            //add characters of original string in reverse order of which it was added into new empty string
            for (int i = 0; i < userString.Length; i++)
            {
                outputString[i] = userString[userString.Length - (i + 1)];
            }

            //print so user can see reversed string
            Console.WriteLine(); //added for readibility/separation between tasks
            Console.WriteLine("Ta-da!");
            Console.WriteLine(outputString);
        }
    }
}
