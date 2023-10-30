using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest2_4_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);
        }

        static void UsePhone(object obj)
        {
            PhoneInterface phoneObj = (PhoneInterface)obj;
            phoneObj.MakeCall();
            phoneObj.HangUp();

            if (obj is Tardis)
            {
                Tardis tardis = (Tardis)obj;
                tardis.TimeTravel();
                //for clarity
                Console.WriteLine();
            }
            else if (obj is PhoneBooth)
            {
                PhoneBooth phoneBooth = (PhoneBooth)obj;
                phoneBooth.OpenDoor();
                //for clarity
                Console.WriteLine();
            }
        }
    }

    // parent class
    public abstract class Phone
    {
        //fields
        private string phoneNumber;
        public string address;

        //props and mtds
        public string PhoneNumber { get; set; }

        public abstract void Connect();
        public abstract void Disconnect();
    }

    // interface to be inherited from
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    // first child class - didn't fill out all methods b/c time/never used
    public class RotaryPhone : Phone, PhoneInterface
    {
        // mtds
        public void Answer() { }
        public void MakeCall()
        {
            Console.WriteLine("*spinning noises* ...hello?");
        }
        public void HangUp()
        {
            Console.WriteLine("Goodbye.");
        }
        public override void Connect() { }
        public override void Disconnect() { }
    }

    // second child class - didn't fill out all methods b/c time/never used
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer() { }
        public void MakeCall()
        {
            Console.WriteLine("Beep- beep- beep. Yeah?");
        }
        public void HangUp()
        {
            Console.WriteLine("See ya!");
        }
        public override void Connect() { }
        public override void Disconnect() { }
    }

    // third child class - inherits from first child
    public class Tardis : RotaryPhone
    {
        //fields
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        //props and mtds
        public byte WhichDrWho { get; }
        public string FemaleSideKick { get; }
        public void TimeTravel()
        {
            Console.WriteLine("*cue wibbly wobbly timey wimey stuff*");
        }

        //overloading ops
        public static bool operator ==(Tardis doc1, Tardis doc2)
        {
            return doc1.WhichDrWho == doc2.WhichDrWho;
        }

        public static bool operator !=(Tardis doc1, Tardis doc2)
        {
            return !(doc1 == doc2);
        }

        public static bool operator <(Tardis doc1, Tardis doc2)
        {
            if (doc1.WhichDrWho == 10 && doc2.WhichDrWho != 10)
            {
                return false;
            }
            else if (doc1.WhichDrWho != 10 && doc2.WhichDrWho == 10)
            {
                return true;
            }
            else
            {
                return doc1.WhichDrWho < doc2.WhichDrWho;
            }
        }

        public static bool operator >(Tardis doc1, Tardis doc2)
        {
            if (doc1.WhichDrWho == 10 && doc2.WhichDrWho != 10)
            {
                return true;
            }
            else if (doc1.WhichDrWho != 10 && doc2.WhichDrWho == 10)
            {
                return false;
            }
            else
            {
                return doc1.WhichDrWho > doc2.WhichDrWho;
            }
        }

        public static bool operator <=(Tardis doc1, Tardis doc2)
        {
            if (doc1.WhichDrWho == 10 && doc2.WhichDrWho != 10 || doc1.WhichDrWho != doc2.WhichDrWho)
            {
                return false;
            }
            else if (doc1.WhichDrWho != 10 && doc2.WhichDrWho == 10 || doc1.WhichDrWho == doc2.WhichDrWho)
            {
                return true;
            }
            else
            {
                return doc1.WhichDrWho <= doc2.WhichDrWho;
            }
        }

        public static bool operator >=(Tardis doc1, Tardis doc2)
        {
            if (doc1.WhichDrWho == 10 && doc2.WhichDrWho != 10 || doc1.WhichDrWho != doc2.WhichDrWho)
            {
                return true;
            }
            else if (doc1.WhichDrWho != 10 && doc2.WhichDrWho == 10 || doc1.WhichDrWho == doc2.WhichDrWho)
            {
                return false;
            }
            else
            {
                return doc1.WhichDrWho >= doc2.WhichDrWho;
            }
        }
    }

    // fourth child class - didn't fill out all methods b/c time/never used
    public class PhoneBooth : PushButtonPhone
    {
        //fields
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        //mtds
        public void OpenDoor()
        {
            Console.WriteLine("Never fear citizens!");
        }
        public void CloseDoor()
        {

        }
    }
}