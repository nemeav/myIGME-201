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

    //DIY Queue Class
    public class MyQueue
    {
        //fields
        private List<int> queueList;

        //construct
        public MyQueue()
        {
            queueList = new List<int>();
        }

        //mtds
        public void Enqueue(int n)
        {
            queueList.Add(n);
            Console.WriteLine("Enqueued: " + n);
        }

        public int Dequeue()
        {
            int item = queueList[0];
            queueList.RemoveAt(0);
            return item;
        }

        public int Peek()
        {
            return queueList[0];
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

            Console.WriteLine(); //for readability

            MyQueue myQueue = new MyQueue();

            //Queue testing - 3 mtds
            myQueue.Enqueue(5);
            myQueue.Enqueue(10);
            myQueue.Enqueue(15);

            Console.WriteLine("Front element: " + myQueue.Peek());

            int dequeued = myQueue.Dequeue();
            Console.WriteLine("Dequeued: " + dequeued);
        }
    }
}
