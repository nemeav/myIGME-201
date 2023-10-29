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

    // first child class
    public class RotaryPhone : Phone, PhoneInterface
    {
        // mtds
        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }
        public override void Connect() { }
        public override void Disconnect() { }
    }

    // second child class
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }
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
        public void TimeTravel() { }
    }

    // fourth child class
    public class PhoneBooth : PushButtonPhone
    {
        //fields
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        //mtds
        public void OpenDoor()
        {

        }
        public void CloseDoor()
        {

        }
    }
}
