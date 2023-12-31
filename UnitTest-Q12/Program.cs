﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Q12
{
    /* Author: Neme Velazquez
     * Purpose: Create a program that gives person a raise based on name
     * Restrictions: none
     */
    internal class Program
    {
        /* Purpose: Ask user for name, call function to see if they get a raise, and print results to console
         * Restrictions: none
         * Returns: Results message with current/new salary value
         */
        static void Main(string[] args)
        {
            //variables for storing user's name and default salary
            string sName;
            double dSalary = 30000;

            //user prompt for name - determines raise
            Console.WriteLine("Hello! What's your name? ");
            sName = Console.ReadLine();
            sName = sName.ToLower();

            //console messages/debugging for if person got raise or not
            if (GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine($"Congratulations, you got a raise! Your new salary is {dSalary}!");
            }
            else
            {
                Console.WriteLine($"Sorry, no raise this time. Your salary is {dSalary}.");
            }
        }

        //function returns true or false based on user's input name
        //parameters: name = user's name, salary = current salary and if earns raise
        static bool GiveRaise(string name, ref double salary)
        {
            switch (name)
            {
                //use all my nicknames b/c I use different versions when debugging
                case "nemesis":
                case "neme":
                case "nem":
                    salary += 19999.99;
                    return true;
                //if anyone's else name entered, no raise
                default:
                    return false;
            }
        }
    }
}