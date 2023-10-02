using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UnitTest_Q4
{
    /* Author: Neme Velazquez
     * Purpose: Recreate a program that offers you three timed questions from various pop culture references/jokes
     * Restrictions: see below?
     */
    internal class Program
    {
        /* Purpose: Prompt the user for a question choice and give them 5 seconds to answer it before time out, let them play again
         * Restrictions: none
         * Returns: series of questions and feedback on user's answers
         */
        //series of static variables to manage/create timer
        //learned from hw, don't put them in main if need elsewhere
        static bool bTimeOut = false;
        static Timer timeOutTimer;

        //stores answer for each question
        //moved up top bc I need it in the time out func
        static string sAnswer;

        static void Main(string[] args)
        {
            //store user's first input to question
            string sChoice;
            int nChoice;
            string sQuestion;
            string sInput;

            //test if user inputs valid choice
            bool bValid = false;

            // play again?
            string sAgain = "";

        //label to start replay loop
        start:
            //prompt user to pick a question
            do
            {
                Console.Write("Choose your question (1-3): ");
                sChoice = Console.ReadLine();
                //error handling incase user does not enter a number
                //...probably could've done this easier now that i think about it but this is what i remember
                try
                {
                    nChoice = Convert.ToInt32(sChoice);
                    bValid = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    bValid = false;
                }
            } while (!bValid);

            //since it worked above, now we can actually convert... i think... started working once i moved this outside
            nChoice = Convert.ToInt32(sChoice);

            //establish/ask and save answers for each question
            Console.WriteLine("You have 5 seconds to answer the following question: ");
            if (nChoice == 1)
            {
                sQuestion = "What is your favorite color? ";
                sAnswer = "black";
            }
            else if (nChoice == 2)
            {
                sQuestion = "What is the answer to life, the universe and everything? ";
                sAnswer = "42";
            }
            else
            {
                sQuestion = "What is the airspeed velocity of an unladen swallow? ";
                sAnswer = "What do you mean? African or European swallow?";
            }

            //set up for timer before question
            timeOutTimer = new Timer(5000);

            timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

            bTimeOut = false;

            timeOutTimer.Start();

            //ask question and store answer
            Console.WriteLine(sQuestion);
            sInput = Console.ReadLine();

            timeOutTimer.Stop();

            // mark answer as wrong when time runs out
            if (bTimeOut)
            {
                sInput = "";
            }

            if (sInput == sAnswer)
            {
                //print congrats. if user is correct
                Console.WriteLine("Well done!");
            }
            else
            {
                //offer negative feedback and correction
                Console.Write("Wrong!   ");
                Console.WriteLine($"The answer is: {sAnswer}");
            }

            //prompt user to play again
            Console.Write("Play again? ");
            sAgain = Console.ReadLine();
            sAgain = sAgain.ToLower();
            if (sAgain == "y") //restarts game
            {
                Console.WriteLine();
                goto start;
            }
            else //quits game... in theory
            {
                Environment.Exit(0);
            }

        }


        /* Purpose: Manages what happens when timer runs out
         * Restrictions: none
         * Returns: text to console and new bTimeOut value
         */
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            //text to let user know they've run out of time
            Console.WriteLine("Your time is up!");
            Console.WriteLine($"The answer is: {sAnswer}");
            Console.WriteLine("Please press Enter.");
            //interrupts current question
            bTimeOut = true;
            //stop timer
            timeOutTimer.Stop();
        }
    }
}
