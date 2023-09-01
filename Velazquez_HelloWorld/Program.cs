using System;
//below 4 not necessary for us in beginning, still commonly used
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velazquez_HelloWorld
{
    //Lecture 1-2 - add static to classes so things don't get messed up!
    static internal class Program
    {
        static void Main(string[] args)
        {
            //instead of Hello World!, print name to console
            Console.WriteLine("Neme Velazquez");

            //Changing your program - try variables
            //creating string variable 
            string sFirstName = "Neme";
            Console.WriteLine(sFirstName);
            //success!

            //Changing your program - math calculations
            //set ints to 2 variables and try to add them
            int iFirstNum = 1;
            int iSecondNum = 2;
            int iTotal = iFirstNum + iSecondNum;

            Console.WriteLine(iTotal);
            //success - surprised that worked, wasn't expecting similarity to JS
        }
    }
}
