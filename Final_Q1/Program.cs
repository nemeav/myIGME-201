using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Q1
{
    //DIY Stack class
    public class MyStack
    {   
        //field
        private List<int> stackList;

        //constructor
        public MyStack()
        {
            stackList = new List<int>();
        }

        //mtds
        public void Push(int n)
        {
            stackList.Add(n);
            Console.WriteLine("Pushed: " + n);
        }

        public int Pop()
        {
            int lastIndex = stackList.Count - 1;
            int lastItem = stackList[lastIndex];
            stackList.RemoveAt(lastIndex);
            return lastItem;
        }

        public int Peek()
        {
            return stackList[stackList.Count - 1];
        }
    }

    class Program
    {
        static void Main()
        {
            MyStack myStack = new MyStack();

            //push to stack for testing
            myStack.Push(5);
            myStack.Push(10);
            myStack.Push(15);

            //peek
            Console.WriteLine("Top element: " + myStack.Peek());

            //pop
            int popped = myStack.Pop();
            Console.WriteLine("Popped: " + popped);
        }
    }
}
