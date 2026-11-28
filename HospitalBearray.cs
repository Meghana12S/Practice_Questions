using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment1;

namespace Assessment1
{
    public class HospitalBedAllocationValidator
    {
        public string EvaluateBedAvailability(int[,] hospitalBeds, int wardCount, int bedsPerWard)
        {
            if(hospitalBeds == null)
            {
                return "Invalid Input";
            }
            if(wardCount <= 0 || bedsPerWard <= 0)
            {
                return "Invalid Input";
            }
            if(hospitalBeds.GetLength(0)!= wardCount || hospitalBeds.GetLength(1) != bedsPerWard)
            {
                return "Invalid Input";
            }
            for(int w = 0;w<wardCount;w++)
            {
                for(int b = 0;b<bedsPerWard;b++)
                {
                    if (hospitalBeds[w,b]!= 0 && hospitalBeds[w, b]!= 1)
                    {
                        return "Invalid Input";
                    }
                }
            }
            List<string> lines = new List<string>();
            int totalAvailable = 0, totalOccupied = 0;
            for (int w = 0; w < wardCount; w++)
            {
                int available = 0, Occupied = 0;
                for (int b = 0; b < bedsPerWard; b++)
                {
                    if (hospitalBeds[w, b] == 0)
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
                lines.Add("Ward " + (w + 1) + ":");
                lines.Add("Available Beds:" + available);
                lines.Add("Occupied Beds:" + Occupied);
            }
            lines.Add("Overall Available Beds: " + totalAvailable);
            lines.Add("Overall Occupied Beds: " + totalOccupied);
            lines.Add("Hospital Status: " + (totalAvailable > 0 ? "Beds Available" : "Hospital Full"));
                return string.Join("\n", lines);


            }
               

        }
    }
    public class HospitalBearray
    {
        public static void Main(string[] args)
        {
        Console.WriteLine("Enter Number of Wards:");
        int wardCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Number of Beds per Ward:");
        int bedsPerWard = int.Parse(Console.ReadLine());
        int[,] hospitalBeds = new int[wardCount, bedsPerWard];
        for(int w = 0;w<wardCount;w++)
        {
            Console.WriteLine("Enter Bed Status for Ward " + (w + 1) + ":");
            for(int b = 0;b<bedsPerWard;b++)
            {
                hospitalBeds[w, b] = int.Parse(Console.ReadLine());


            }
        }
        HospitalBedAllocationValidator h = new HospitalBedAllocationValidator();
        Console.WriteLine(h.EvaluateBedAvailability(hospitalBeds, wardCount, bedsPerWard));



    }
}
