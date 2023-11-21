using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace TriviaApp
{
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }
    /*
     * {
    "response_code": 0,
    "results": [
        {
            "type": "multiple",
            "difficulty": "medium",
            "category": "General Knowledge",
            "question": "In a standard set of playing cards, which is the only king without a moustache?",
            "correct_answer": "Hearts",
            "incorrect_answers": [
                "Spades",
                "Diamonds",
                "Clubs"
            ]
        }
    ]
}
     */


    internal class Program
    {
        static void Main(string[] args)
        {
            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=1&type=multiple";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            //DIY SECTION
            //decode for html symbols/codes
            string correctAns = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
            string question = HttpUtility.HtmlDecode(trivia.results[0].question);

            //create random number to make as index for correct answer, insert at that point
            Random rand = new Random();
            int randIndex = rand.Next(0, trivia.results[0].incorrect_answers.Count + 1); //accounts for full length: 0-end of array
            trivia.results[0].incorrect_answers.Insert(randIndex, correctAns);

            //ask question
            Console.WriteLine(question);
            Console.WriteLine(); //for readability
            //prints answer list
            foreach (string answer in trivia.results[0].incorrect_answers)
            {
                Console.WriteLine(answer);
            }

            //ask for response from user
            Console.Write("Please enter your answer: ");
            string userAnswer = Console.ReadLine();

            //if input matches correctAns, post good job to console
            //otherwise, say it's not correct
            if (userAnswer.ToLower() == correctAns.ToLower()) //lowercase both b/c I doubt people will use proper capitalization
            {
                Console.WriteLine("Good job! You got it!!");
            }
            else
            {
                Console.WriteLine($"Sorry, the correct answer is {correctAns}");
            }
        }
    }
}
