using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Q5
{
    /* Author: Neme Velazquez
     * Purpose: Store the values for 3 variables in an array given an equation
     * Restrictions: see below
     */
    static internal class Program
    {
        /* Purpose: enter multiple variable into an equation and be able to store the results
         * Restrictions: i can't calculate x right and i'm done
         * Returns: new values of x, y, and z after being manipulated in equation
         */
        static void Main()
        {
            //variables- store ranges and incrementer for x and y
            double minX = -1.0;
            double maxX = 1.0;
            double minY = 1.0;
            double maxY = 4.0;
            double ctr = 0.1;

            //calculate the dimensions of the 3D array
            //why doesn't double work for calculations
            int xSize = (int)((maxX - minX) / ctr) + 1;
            int ySize = (int)((maxY - minY) / ctr) + 1;

            //array to store x, y, and z values
            double[,,] values = new double[xSize, ySize, 3];

            //set x and y to minimum values
            double x = minX;
            double y = minY;

            //calculate and store the values of x, y, and z
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    double z = (3 * Math.Pow(y, 2)) + (2 * x) - 1;

                    values[i, j, 0] = x;
                    values[i, j, 1] = y;
                    values[i, j, 2] = z;

                    //print current results
                    Console.WriteLine($"x = {x}, y = {y}, z = {z}");

                    //add ctr y for the next loop
                    y += ctr;
                }
                //trying to adjust for some errors in the loops
                y = minY - 0.2;
                x += ctr;
            }
        }
    }
}
