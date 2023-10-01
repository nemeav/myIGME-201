using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte byteVal;
            short shortVal = -556;
            byteVal = Convert.ToByte(shortVal);
            Console.WriteLine("byteVal = {0}", byteVal);

        }
    }
}
