using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Q12
{
    /* Author: Neme Velazquez
     * Purpose: Create a program that gives person a raise based on name (now with structs)
     * Restrictions: none
     */
    internal class Program
    {
        //stores person's/user information and default salary info
        public struct Employee
        {
            public string sName;
            public double dSalary;
        }

        /* Purpose: Ask user for name, call function to see if they get a raise, and print results to console
         * Restrictions: none
         * Returns: Results message with current/new salary value
         */
        static void Main(string[] args)
        {
            //new employee instance and initializing salary variable
            Employee employee = new Employee();
            employee.dSalary = 30000;

            //user prompt for name - determines raise
            Console.WriteLine("Hello! What's your name? ");
            employee.sName = Console.ReadLine();
            employee.sName = employee.sName.ToLower();

            //console messages/debugging for if person got raise or not
            if (GiveRaise(ref employee))
            {
                Console.WriteLine($"Congratulations, you got a raise! Your new salary is {employee.dSalary}!");
            }
            else
            {
                Console.WriteLine($"Sorry, no raise this time. Your salary is {employee.dSalary}.");
            }
        }

        //function returns true or false based on user's input name
        //parameter: only the struct with both values
        static bool GiveRaise(ref Employee employee) //use ref so function manipulates original and not copy 
        {
            switch (employee.sName)
            {
                //use all my nicknames b/c I use different versions when debugging
                case "nemesis":
                case "neme":
                case "nem":
                    employee.dSalary += 19999.99;
                    return true;
                //if anyone's else name entered, no raise
                default:
                    return false;
            }
        }
    }
}