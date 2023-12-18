using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateFunction
{
    internal class Program
    {
        //declare delegate that matches Math.Round()
        public delegate double MyRounder(double d, int n);
        static Func<double, int, double> myGenericRounder; //genenric one (used for second half of list)

        static void Main(string[] args)
        {
            // create variable of delegate function type 
            MyRounder myRounder;

            // 1 - assign Math.Round to delegate
            myRounder = Math.Round;

            // 2 - use constructor
            myRounder = new MyRounder(Math.Round);

            // 3 - arrow/lambda func
            myRounder = (double d, int n) =>
            {
                double returnVal = Math.Round(d, n);
                return returnVal;
            };

            // 4 - shorter lambda
            myRounder = (double d, int n) =>
            {
                double returnVal = Math.Round(d, n);
                return returnVal;
            };

            // 5 - even shorter lambda
            myRounder = (d, n) => Math.Round(d, n);

            // 6 - lambda with generic
            myGenericRounder = (double d, int n) =>
            {
                double returnVal = Math.Round(d, n);
                return returnVal;
            };

            // 7 - shorter lambda with generic
            myGenericRounder = (d, n) =>
            {
                double returnVal = Math.Round(d, n);
                return returnVal;
            };

            // 8 - shortest lambda with generic
            myGenericRounder = (d, n) => Math.Round(d, n);

            // 9 - direct assignment (generic)
            myGenericRounder = Math.Round;

            // 10 - constructor (generic)
            myGenericRounder = new Func<double, int, double>(Math.Round);

            // 11 - anon code block (generic)
            myGenericRounder = delegate (double d, int n)
            {
                double returnVal = Math.Round(d, n);
                return returnVal;
            };

            // 12 - anon code block
            myRounder = delegate (double d, int n)
            {
                double returnVal = Math.Round(d, n);
                return returnVal;
            };

            //testing purposes - matching
            double number = 6.2370;
            int decimals = 2;
            double rounded = myRounder(number, decimals);
            Console.WriteLine("Rounded number: " + rounded);

            //testing purposes - generic
            double number2 = 4.5836;
            int decimals2 = 2;
            rounded = myGenericRounder(number2, decimals2);
            Console.WriteLine("Rounded number: " + rounded);
        }
    }
}
