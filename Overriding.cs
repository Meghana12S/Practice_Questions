using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    class DeliveryService
    {
        public virtual double Calculate(double distance)
        {
            return 0;
        }
    }

    class StandardDelivery : DeliveryService
    {
        public override double Calculate(double distance)
        {
            return 50 + (12 * distance);
        }
    }

    class ExpressDelivery : DeliveryService
    {
        public override double Calculate(double distance)
        {
            return 100 + (15 * distance);
        }
    }

    public class Overriding
    {
        public static void Main(string[] args)
        {
            double[] distances = { 0, 5, 10 };

            DeliveryService standard = new StandardDelivery();
            DeliveryService express = new ExpressDelivery();

            Console.WriteLine("Summary");

            foreach (double distance in distances)
            {
                if (distance < 0)
                {
                    Console.WriteLine("Invalid distance: Distance cannot be negative.");
                    continue;
                }

                Console.WriteLine("Distance : " + distance + " km");

                Console.WriteLine("Standard Delivery : ₹" +
                                  standard.Calculate(distance));

                Console.WriteLine("Express Delivery  : ₹" +
                                  express.Calculate(distance));

                Console.WriteLine();
            }
        }
    }
}

