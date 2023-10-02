using System;

namespace NumberSort
{
    /* Editor: Neme Velazquez
    * Purpose: Edit program to accept sentences and sort the words in alpha./reverse alpha. order
    * restrictions: none
    */
    class Program
    {
        // the definition of the delegate function data type
        delegate string sortingFunction(string[] a);

        /* Purpose: Edit code to evaluate strings in alphabetical order instead of numbers
         * Restrictions: none
         * Returns: string of words from sentence in either alpha. or reverse alpha. order
         */
        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays
            string[] aUnsorted;
            string[] aSorted;

            // declare the delegate variable which will point to the function to be called
            sortingFunction alphaSort;

            // a label to allow us to easily loop back to the start if there are input issues
            Console.WriteLine("Enter a sentence: ");

            // read the space-separated string of numbers
            string sNumbers = Console.ReadLine();

            // split the string into the an array of strings which are the individual numbers
            string[] sNumber = sNumbers.Split(' ');

            // initialize the size of the unsorted array to 0
            int nUnsortedLength = 0;

            // iterate through the array of number strings
            foreach (string sThisNumber in sNumber)
            {
                // if the length of this string is 0 (ie. they typed 2 spaces in a row)
                if (sThisNumber.Length == 0)
                {
                    // skip it
                    continue;
                }

                //remove try-catch since readline defaults to string
                ++nUnsortedLength;
            }

            // now we know how many unsorted numbers there are
            // allocate the size of the unsorted array
            aUnsorted = new string[nUnsortedLength];

            // reset nUnsortedLength back to 0 to use as the index to store the numbers in the unsorted array
            nUnsortedLength = 0;
            foreach (string sThisNumber in sNumber)
            {
                // still skip the blank strings
                if (sThisNumber.Length == 0)
                {
                    continue;
                }

                // store the word into the array
                aUnsorted[nUnsortedLength] = sThisNumber;

                // increment the array index
                nUnsortedLength++;
            }

            // allocate the size of the sorted array
            aSorted = new string[nUnsortedLength];

            // prompt for <a>scending or <d>escending
            Console.Write("Alphabetical or Reversed? ");
            string sDirection = Console.ReadLine();

            if (sDirection.ToLower().StartsWith("a"))
            {
                alphaSort = new sortingFunction(FindAlphabet);
            }
            else
            {
                alphaSort = new sortingFunction(FindReverseAlphabet);
            }

            // start the sorted length at 0 to use as sorted index element
            int nSortedLength = 0;

            // while there are unsorted words to sort
            while (aUnsorted.Length > 0)
            {
                // store the closest or farthest unsorted word as the next sorted word
                aSorted[nSortedLength] = alphaSort(aUnsorted);

                // remove the current sorted word
                RemoveUnsortedValue(aSorted[nSortedLength], ref aUnsorted);

                // increment the number of words in the sorted array
                ++nSortedLength;
            }

            // write the sorted array of numbers
            Console.WriteLine("The sorted list is: ");
            foreach (string thisNum in aSorted)
            {
                Console.Write($"{thisNum} ");
            }

            Console.WriteLine();
        }

        // find the closest word to front of alphabet in array of strings
        static string FindAlphabet(string[] array)
        {
            // define return word
            string returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (string thisNum in array)
            {
                int nextString = thisNum.CompareTo(returnVal);
                // if the current word is lower than the saved soonest letter/word
                if (nextString < 0)
                {
                    // save this as the closest word
                    returnVal = thisNum;
                }
            }

            // return the closest word
            return (returnVal);
        }

        static string FindReverseAlphabet(string[] array)
        {
            // define return word
            string returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (string thisNum in array)
            {
                int nextString = thisNum.CompareTo(returnVal);
                // if the current word is greater than the saved farthest letter present
                if (nextString > 0)
                {
                    // save this as the last word
                    returnVal = thisNum;
                }
            }

            // return the last word
            return (returnVal);
        }


        // remove the first instance of a value from an array
        static void RemoveUnsortedValue(string removeValue, ref string[] array)
        {
            // allocate a new array to hold 1 less value than the source array
            string[] newArray = new string[array.Length - 1];

            // we need a separate counter to index into the new array, 
            // since we are skipping a value in the source array
            int dest = 0;

            // the same value may occur multiple times in the array, so skip subsequent occurrences
            bool bAlreadyRemoved = false;

            // iterate through the source array
            foreach (string srcNumber in array)
            {
                // if this is the number to be removed and we didn't remove it yet
                if (srcNumber == removeValue && !bAlreadyRemoved)
                {
                    // set the flag that it was removed
                    bAlreadyRemoved = true;

                    // and skip it (ie. do not add it to the new array)
                    continue;
                }

                // insert the source number into the new array
                newArray[dest] = srcNumber;

                // increment the new array index to insert the next number
                ++dest;
            }

            // set the ref array equal to the new array, which has the target number removed
            // this changes the variable in the calling function (aUnsorted in this case)
            array = newArray;
        }
    }
}
