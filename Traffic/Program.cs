using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* trying to pass non-IPassengerCarrier object into function
             * gets compile time error :( - makes sense though
             */
            /*FreightTrain freightTrain = new FreightTrain();
            AddPassenger(freightTrain);*/
        }

        public void AddPassenger(IPassengerCarrier carrier)
        {
            carrier.LoadPassenger();
            Console.WriteLine(carrier.ToString());
        }
    }
}
