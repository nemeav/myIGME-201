using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_PE9___Q3
{
    delegate string NewReadLine(); 
    /* Author: Neme Velazquez
     * Purpose: Use a delegate program to copy readline
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            NewReadLine processReadConsole;

            processReadConsole = Console.ReadLine;

            string sInput = processReadConsole();
        }  
    }
}
