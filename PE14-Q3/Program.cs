using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE14_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new objects
            FirstClass firstClass = new FirstClass();
            SecondClass secondClass = new SecondClass();

            //method calls
            MyMethod(firstClass);
            MyMethod(secondClass);
        }

        //separate method references the object methods
        public static void MyMethod(object myObject)
        {
            IMyInterface myInterfaceObject = (IMyInterface)myObject;
            myInterfaceObject.ObjMethod();
        }
    }

    //interface to be inherited from
    public interface IMyInterface
    {
        void ObjMethod();
    }

    public class FirstClass : IMyInterface
    {
        public void ObjMethod()
        {
            Console.WriteLine("This is from the first class!");
        }
    }

    public class SecondClass : IMyInterface
    {
        public void ObjMethod()
        {
            Console.WriteLine("This is from the second class!");
        }
    }
}
