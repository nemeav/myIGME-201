using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>

    /*Author/Modifier: Neme Velazquez
     * Purpose: Edit a mandelbrot program so it "zooms" into an image based on user input
     * Caveats: Entering a non-numeric value will break the program as I ran out of time to code in a try-catch
     */
    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        /*Method purpose: prompt user to enter start and end values for the segment, then calculate the proper increments
         * Caveat: As explained above, there is no try-cath to stop non-numeric answers
         * Parameters/Returns: n/a?
         */
        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            //creating variables to store user's various start and end values
            //initialized them to 0.00 b/c I wasn't sure if doubles need to be formatted as well... doubles
            double dStartImagCoord = 0.00;
            double dEndImagCoord = 0.00;
            double dStartRealCoord = 0.00;
            double dEndRealCoord = 0.00;
            // variables to store the increment calculations
            double dImagCoordIncrement = 0.00;
            double dRealCoordIncrement = 0.00;


            //prompting user for input to imagCoord
            Console.WriteLine("Enter a starting value for the y-axis: ");
            dStartImagCoord = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter a (smaller) ending value for the y-axis: ");
            dEndImagCoord = Convert.ToDouble(Console.ReadLine());
            //error handling: user cannot enter a bigger ending value than the starting
            while (dEndImagCoord > dStartImagCoord)
            {
                Console.WriteLine("Please enter a smaller ending value: ");
                dEndImagCoord = Convert.ToDouble(Console.ReadLine());
            }


            //prompting user for start and end of realCoord
            Console.WriteLine("Enter a starting value for the x-axis");
            dStartRealCoord = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter a (larger) ending value for the x-axis: ");
            dEndRealCoord = Convert.ToDouble(Console.ReadLine());
            //error handling: user cannot enter a smaller ending value than the starting
            while (dEndRealCoord < dStartRealCoord)
            {
                Console.WriteLine("Please enter a larger ending value: ");
                dEndImagCoord = Convert.ToDouble(Console.ReadLine());
            }


            //calculates the axis increments
            //imagCoord first
            dImagCoordIncrement = (dStartImagCoord - dEndImagCoord) / 48;
            //RealCoord calculations
            dRealCoordIncrement = (dStartRealCoord - dEndRealCoord) / 80;

            
            //original mandelbrot code
            //used the absolute value for the increments because the calculations were coming out negative
            for (imagCoord = dStartImagCoord; imagCoord >= dEndImagCoord; imagCoord -= Math.Abs(dImagCoordIncrement))
            {
                for (realCoord = dStartRealCoord; realCoord <= dEndRealCoord; realCoord += Math.Abs(dRealCoordIncrement))
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
