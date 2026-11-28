using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class ParkingManagementValidator
    {
        public string EvaluateParkingAvailability(int[,] parkingSlots, int floorCount, int slotsPerFloor)
        {
           if(parkingSlots == null)
           {
                return "Invalid Input";

           }
           if( floorCount <= 0 || slotsPerFloor <=0)
           {
                return "Invalid Input";
           }
           if (parkingSlots.GetLength(0) != floorCount || parkingSlots.GetLength(1) != slotsPerFloor)
           {
                return "Invalid Input";
           
           }
           for(int f = 0; f < floorCount;f++)
            {
                for(int s = 0;s< slotsPerFloor; s++)
                {
                    if (parkingSlots[f,s] != 0 && parkingSlots[f,s] != 1)
                    {
                        return "Invalid Input";
                    }
                }
            }
            List<string> lines = new List<string>();
            int totalAvailable = 0;
            int totalOccupied = 0;
            for (int f = 0; f < floorCount; f++)
            {
                int available = 0; int Occupied = 0;
                for (int s = 0; s < slotsPerFloor; s++)
                {
                    if (parkingSlots[f, s] == 0)
                    {
                        available++;
                    }
                    else
                    {
                        Occupied++;
                    }

                }
                totalAvailable += available;
                totalOccupied += Occupied;
                lines.Add("Floor" + (f + 1) + ":");
                lines.Add("Available Slots: " + available);
                lines.Add("Occupied Slots: " + Occupied);
            }

                lines.Add("Overall Available Slots: " + totalAvailable);
                lines.Add("Overall Occupied Slots: " + totalOccupied);
                lines.Add("Parking Status: "+ (totalAvailable > 0 ? "Parking Available" : "Parking Full"));
                return string.Join("\n", lines);

            



        }
    }
    public class SmartParking
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Floors:");
            int floorCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number of Parking Slots per Floor:");
            int slotsPerFloor = int.Parse(Console.ReadLine());
            if(floorCount <= 0 || slotsPerFloor <= 0)
            {
                Console.WriteLine( "Invalid Input");
                return;
            }
            int[,] parkingSlots = new int[floorCount,slotsPerFloor];
            for (int f = 0; f < floorCount; f++)
            {
                Console.WriteLine("Enter Parking Status For Floor " + (f + 1) + ":");
                for (int s = 0; s < slotsPerFloor; s++)
                {
                    parkingSlots[f, s] = int.Parse(Console.ReadLine());


                }
            }
            ParkingManagementValidator p = new ParkingManagementValidator();
            Console.WriteLine(p.EvaluateParkingAvailability(parkingSlots,floorCount, slotsPerFloor));


        }
    }
}
