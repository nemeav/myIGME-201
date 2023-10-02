using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string string2 = "hello";
            string string1 = "apple";

            int order = string1.CompareTo(string2);
            Console.WriteLine(order);
        }
    }
}
