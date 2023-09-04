/* Program: Squash The Bugs
 * Author/Editor: Nemesis "Neme" Velazquez
 * Purpose: Analyze code to eliminate/fix bugs in program
 * Known problems/Caveats: None... hopefully
*/

using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //SYNTAX: semi-colon missing at the end of statement
            //int i = 0
            int i = 0;
            //moved up from line 38, see line for notes
            string allNumbers = null;

            // loop through the numbers 1 through 10
            //LOGICAL: loop does not include/loop all the way through 10
            //for (i = 1; i < 10; ++i)
            for (i = 1; i <= 10; ++i)
            {
                // declare string to hold all numbers
                //COMPILE-TIME? (out of scope): allNumbers only defined in loop, cannot be accessed in line 53, after loop 
                //string allNumbers = null;

                // output explanation of calculation
                //SYNTAX: operation is not properly grouped w/ variable, trying to apply numeric operation to string
                //Console.Write(i + "/" + i - 1 + " = ");
                Console.Write(i + "/" + (i - 1) + " = ");

                // output the calculation based on the numbers
                //RUNTIME: program tries to divide by 0 in first iteration of loop
                //Console.WriteLine(i / (i - 1));
                try
                {
                    Console.WriteLine(i / (i - 1));
                }
                catch
                {
                    Console.WriteLine();
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                //LOGICAL: second incrementer is not needed in for loop
                //i = i + 1;
            }

            // output all numbers which have been processed
            //SYNTAX: comma (or + ?) needed to separate different things (ie string and variable) in same line
            //Console.WriteLine("These numbers have been processed: " allNumbers);
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
