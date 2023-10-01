using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Q3
{
    /* Author: Neme Velazquez
     * Purpose: create a delegate that is essentially Math.Round(double, int)
     * Restrictions: ...none?
     */

    //Step 1: define delegate based on info in question
    delegate double RoundMath(double n1, int n2);

    internal class Program
    {
        /* Purpose: create, init., and call new delegate method to round a number to the specified decimal places
         * Restrictions: none
         * Returns: rounded number
         */
        static void Main(string[] args)
        {
            //Step 2: declare method variable
            RoundMath roundNumber;

            //3: point to method (in this case, existing Math.Round())
            roundNumber = new RoundMath(Math.Round);

            //4: call method
            double dNewNum = roundNumber(3.647, 2); //hard-coded numbers for testing/demonstration
            Console.WriteLine(dNewNum); //print value to make sure it runs properly
        }
    }
}

