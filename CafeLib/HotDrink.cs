using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    // class - parent
    public abstract class HotDrink
    {
        // fields
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        // mtds
        public virtual void AddSugar(byte amount)
        {

        }

        public abstract void Steam();

        // constructors
        public HotDrink()
        {

        }

        public HotDrink(string brand)
        {

        }

    }

    //interfaces - to be inherited from
    public interface IMood
    {
        //props
        string Mood { get; }
    }

    public interface ITakeOrder
    {
        // mtds
        void TakeOrder();
    }

    // classes - will inherit from IMood
    public class Waiter : IMood
    {
        // field
        public string name;

        // props + mtds
        public string Mood { get; }

        public void ServeCustomer(HotDrink cup)
        {

        }
    }

    public class Customer : IMood
    {
        // fields
        public string name;
        public string creditCardNumber;

        // props
        public string Mood { get; }
    } 

    // classes - will inherit from HotDrink and ITakeOrder
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        // fields
        public string beanType;

        // mtds
        public override void Steam()
        {

        }

        public void TakeOrder()
        {

        }

        //constructors
        public CupOfCoffee(string brand) : base(brand)
        {

        }
    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        // fields
        public string leafType;

        //mtds
        public override void Steam()
        {
            
        }

        public void TakeOrder()
        {

        }

        //constructors
        public CupOfTea(bool customerIsWealthy)
        {

        }
    }

    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        // fields
        public static int numCups;
        public bool marshmallows;
        private string source;

        // props + mtds
        public string Source { set { } }

        public override void Steam()
        {
            
        }

        public override void AddSugar(byte amount)
        {
            base.AddSugar(amount);
        }

        public void TakeOrder()
        {

        }

        // constructors
        public CupOfCocoa() : this(false)
        {

        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Blend")
        {
            
        }
    }
}
