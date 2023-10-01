using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber = "";
            int nX;
            //int nY
            //compile-time: needs semicolon at end of statement
            int nY;
            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.);
            //compile-time: string to be printed needs quotes around it
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Console.ReadLine();
                //logic: sNumber is never initialized to the console input and therefore has nothing to test against while looping
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));
            
            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } //while (int.TryParse(sNumber, out nX));
            //logic: nY is never initialized when asking for a y value, instead using nX again and not using the 2nd input
            //logic: loop runs while number is valid; need to repeat when input *doesn't* parse correctly (add ! for not)
            //logic: will actually check if input is positive instead of throwing out an incorrect value of 0
            while (!int.TryParse(sNumber, out nY) && nY <= 0);

            // compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            //logic: need to add dollar sign at beginning in order to use tokens
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
        }

        //int Power(int nBase, int nExponent)
        //compile-time: function needs to be an instance in order to use above in another method
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0;
                //logic: returnVal should be 1 since anything raised to the 0th power is 1
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //logic: comments specify nExponent - 1 but + 1 was used, caused overflow?
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal;
            //compile-time: line was not a declaration or something actionable; program can't do anything with it
            return returnVal;
        }
    }
}