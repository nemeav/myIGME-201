using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MATRIX - shows weights
            int[,] adjacencyMatrix = new int[,]
            {
                //red, blue, gray, pink, yellow green
                {-1,  1,  5, -1, -1, -1, -1}, //red
                {-1, -1, -1,  8,  1, -1, -1}, //blue
                {-1, -1, -1, -1, -1,  0, -1}, //gray
                {-1, -1, -1, -1, -1, -1,  1}, //orange
                {-1, -1, -1, -1, -1,  1, -1}, //pink
                {-1, -1, -1, -1, -1, -1,  6}, //yellow
                {-1, -1, -1, -1, -1, -1, -1}  //green
            };

            //display matrix
            Console.WriteLine("Adjacency Matrix:");
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            //LIST
            //adjacency list rep
            Tuple<string, int>[][] adjacencyList = new Tuple<string, int>[][]
            {
                new Tuple<string, int>[] {Tuple.Create("Blue", 1), Tuple.Create("Gray", 5)},      //red
                new Tuple<string, int>[] {Tuple.Create("Yellow", 8), Tuple.Create("Sky Blue", 1)}, //blue
                new Tuple<string, int>[] {Tuple.Create("Sky Blue", 0), Tuple.Create("Orange", 1)},  //gray
                new Tuple<string, int>[] {Tuple.Create("Pink", 1)},                                 //orange
                new Tuple<string, int>[] {Tuple.Create("Yellow", 1)},                               //pink
                new Tuple<string, int>[] {Tuple.Create("Green", 6)},                                 //yellow
                new Tuple<string, int>[] {},                                                        //green
            };

            // Display adjacency list
            Console.WriteLine("\nAdjacency List:");
            string[] nodeNames = { "Red", "Blue", "Gray", "Orange", "Pink", "Yellow", "Green" };
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                Console.Write(nodeNames[i] + " -> ");
                foreach (Tuple<string, int> neighbor in adjacencyList[i])
                {
                    Console.Write("(" + neighbor.Item1 + ", " + neighbor.Item2 + ") ");
                }
                Console.WriteLine(); // for readability between relationships
            }

        }
    }
}
