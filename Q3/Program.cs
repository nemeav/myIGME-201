using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<(double, double,double), double> values = new SortedList<(double, double,double), double> ();
            //w increments
            for (double i = -2; i <= 0; i += 0.2)
            {
                double w = Math.Round(i, 1);
                //x increments
                for (double j = 0; j <= 4; j += 0.1)
                {
                    double x = Math.Round(j, 1);
                    //y increments
                    for (double k = -1; k <= 1; k += 0.1)
                    {
                        double y = Math.Round(k, 1);
                        double z = Math.Round(4 * Math.Pow(y, 3) + 2 * Math.Pow(x, 2) - 8 * w + 7, 3);
                        values.Add((w, x, y), z);
                    }
                }

            }
            foreach(KeyValuePair<(double, double, double), double> keyValuePair in values)
            {
                Console.WriteLine (keyValuePair.Key + " => " + keyValuePair.Value);
            }
        }
    }
}
