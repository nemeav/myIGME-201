using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

    }

    public class MyClass
    {
        private string myString;
        public string MyString
        {
            set { myString = "hello"; }
        }

        public virtual string GetString()
        {
            return myString;
        }
    }

    public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            string newString = base.GetString();
            newString += " (output from the derived class)";
            return newString;
        }
    }
}
