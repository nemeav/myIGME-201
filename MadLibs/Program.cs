using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadLibs
{
    /* Author: Neme Velazquez
     * Purpose: Create a user-interactive Mad Libs program
     * Caveats: See below
     */
    static internal class Program
    {
        /* Purpose: Create strings out of the stories in the file
         * Caveats: No try-catch for story # selection; a number higher than 6 will throw an exception
         * Returns: A completed MadLibs story featuring the user's input
         */
        static void Main(string[] args)
        {
            //variable used throughout
            int numStory = 0;
            int ctr = 0;
            int nChoice = 0;

            string userName = null;
            string sChoice = null;
            string newWord = null;
            string finalStory = "";

            bool bValid = false;

            //create reader
            StreamReader input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            //read the lines of the file to see how many ML options there are
            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                numStory++;
            }

            //close file once done to safely use later
            input.Close();

            //add+read strings to array from file
            string[] madLibs = new string[numStory];

            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            line = null;
            //set up indices of array and add/fix line breaks
            while ((line = input.ReadLine()) != null)
            {
                madLibs[ctr] = line;

                madLibs[ctr] = madLibs[ctr].Replace("\\n", "\n");

                ctr++;
            }

            input.Close();

            //user prompt - name and story (line number)
            Console.WriteLine("Hello! What's your name? ");
            userName = Console.ReadLine();

            Console.WriteLine($"Nice to meet you, {userName}!");
            Console.Write($"Psst. Hey. Hey {userName}. Do you want to play Mad Libs? ");
            sChoice = Console.ReadLine();
            sChoice.ToLower();

            if (sChoice == "no")
            {   
                bValid = true;
                Console.WriteLine("Oh...");
                Console.WriteLine("Alright then...");
                Console.WriteLine($"Goodbye, {userName}.");

                Environment.Exit(0); //remember a similar command from JS, wasn't sure how else to stop program at this point w/out creating a mess
            }
            else if (sChoice == "yes")
            {
                bValid = true;
                Console.WriteLine($"Great! Enter a number, 1-{numStory}, to write a story: ");
                nChoice = Convert.ToInt32(Console.ReadLine());
                nChoice = nChoice - 1; //-1 accounts for the offset from the index
            }
            else
            {
                while (bValid == false)
                {
                    Console.Write("Please enter yes or no! ");
                    sChoice = Console.ReadLine();
                    sChoice.ToLower();

                    //basically had to recode the earlier inputs bc a normal while, try/catch, etc wasn't working
                    if (sChoice == "no")
                    {
                        bValid = true;
                        Console.WriteLine("Oh...");
                        Console.WriteLine("Alright then...");
                        Console.WriteLine($"Goodbye, {userName}.");

                        Environment.Exit(0);
                    }
                    else if (sChoice == "yes")
                    {
                        bValid = true;
                        Console.WriteLine($"Great! Enter a number, 1-{numStory}, to write a story: ");
                        nChoice = Convert.ToInt32(Console.ReadLine());
                        nChoice = nChoice - 1; //-1 accounts for the offset from the index
                    }
                }
            }

            //split each story into separate words and replacing the parts of speech prompts
            string[] words = madLibs[nChoice].Split(' ');
            foreach (string word in words)
            {
                if (word[0] == '{')
                {
                    newWord = word.Replace("{", " ").Replace("}", "").Replace("_", " "); //spaces added throughout concatenation for readibility
                    Console.Write("Input a {0}: ", newWord);
                    finalStory += Console.ReadLine();
                }
                else
                {
                    finalStory += " " + word + " ";
                }
            }
            Console.WriteLine(finalStory);
        }
    }
}
