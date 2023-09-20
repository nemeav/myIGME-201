using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Q8
{
    /* Author: Neme Velazquez
     * Purpose: Create a program that accepts a string and negates yes and no
     * Restrictions: see below
     */
    static internal class Program
    {
        /* Purpose: Ask the user to enter a string
         * Restrictions: program does not differentiate between words containing no and no so it will convert everything
         * Returns: String with or no flipped to the other word
         */
        static void Main(string[] args)
        {   
            //variables to store user string
            string userString = "";
            
            //prompt user for string and store/read it
            Console.WriteLine("Hello! Enter a statement with yes or no: ");
            userString = Console.ReadLine();
            userString = userString.ToLower();

            //replace "yes" with placeholder
            userString = userString.Replace("yes", "temp");

            //convert "no" to "yes"
            userString = userString.Replace("no", "yes");

            //replace placeholder with correct string
            userString = userString.Replace("temp", "no");

            //print new string
            Console.WriteLine(userString);
        }
    }
}
