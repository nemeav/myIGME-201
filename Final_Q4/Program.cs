using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Q3
{
    internal class Program
    {
        //matrix rep
        //removed list bc I don't think it was needed for this part
        static int[,] adjacencyMatrix = new int[,]
        {
            // red, blue, gray, orange, pink, yellow, green
            {-1,  1,  5, -1, -1, -1, -1}, // red
            {-1, -1, -1,  8,  1, -1, -1}, // blue
            {-1, -1, -1, -1, -1,  0, -1}, // gray
            {-1, -1, -1, -1, -1, -1,  1}, // orange
            {-1, -1, -1, -1, -1,  1, -1}, // pink
            {-1, -1, -1, -1, -1, -1,  6}, // yellow
            {-1, -1, -1, -1, -1, -1, -1}  // green
        };

        //array of node names
        static string[] colors = { "Red", "Blue", "Gray", "Orange", "Pink", "Yellow", "Green" };

        //keep track of visited nodes
        static bool[] visited = new bool[colors.Length];

        //D.F.S
        static void Search(int node)
        {
            Console.WriteLine(colors[node]); //output current node
            visited[node] = true; //mark current node as visited

            //check adjacent nodes
            for (int i = 0; i < adjacencyMatrix.GetLength(1); i++)
            {
                if (adjacencyMatrix[node, i] != -1 && !visited[i])
                {
                    Search(i); //recursively visit adjacent nodes
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Depth First Search starting from Red:");

            //find index of red
            int redIndex = Array.IndexOf(colors, "Red");

            //perform depth search
            Search(redIndex);
        }
    }
}
