using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE9_Q9
{
    /* Author: Neme Velazquez
     * Purpose: place double quotes around each word in a string
     * Restrictions: none
     */
    static internal class Program
    {
        /* Purpose: ask user for a string then split it and return it with quotes
         * restrictions: none
         * Returns: new string with quotes
         */
        static void Main(string[] args)
        {
            //variable for storing input
            string userInput = "";
            string userOutput = "";

            //prompt user + store/read
            Console.WriteLine("Hello! Enter a string to transform: ");
            userInput = Console.ReadLine();

            //split string into array
            string[] words = userInput.Split(' ');
            foreach (string word in words)
            {
                string newWord = "\"" + word + "\" ";
                userOutput += newWord;
            }

            Console.WriteLine(userOutput);
        }
    }
}
