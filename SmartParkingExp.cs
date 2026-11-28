using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class ParkingReservationException : Exception
    {
        public ParkingReservationException(string message) : base(message) { }
    }
    public class ParkingReservationValidator
    {
        public string ReserveParkingSlot(int slotNumber, int requestedHours, int availableHours)
        {
            if(slotNumber <= 0)
            {
                throw new ParkingReservationException("Invalid parking slot number");

            }if(requestedHours <= 0 || availableHours < 0)
            {
                throw new ParkingReservationException("Invalid parking reservation details");
            }
            if(availableHours < requestedHours)
            {
                throw new ParkingReservationException("Invalid parking reservation details");

            }
            int remainingHours = availableHours - requestedHours;
            return "Parking slot reserved successfully.Remaining Hours:" + remainingHours;

        }
    }
    public class SmartParkingExp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Parking Slot Number:");
                int slotNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Requested Parking Hours:");
                int requestedHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Available Parking Hours:");
                int availableHours = int.Parse(Console.ReadLine());
                ParkingReservationValidator parking = new ParkingReservationValidator();
                string res = parking.ReserveParkingSlot(slotNumber, requestedHours, availableHours);
                Console.WriteLine(res);

                
            }
            catch(ParkingReservationException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }


        }
    }
}
