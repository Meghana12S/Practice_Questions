using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    public class BranchSales
    {
        public static void Main(string[] args)
        {
            decimal[,] sales =
        {
            {12000, 9000, 5000, 7000},
            {8000, 11000, 6000, 9500},
            {15000, 7000, 8500, 4000}
        };

            decimal Total = 0;
            int Branch = 0;

            Console.WriteLine("Branch Total:");
            for (int i = 0; i < 3; i++)
            {
                decimal branchTotal = 0;

                for (int j = 0; j < 4; j++)
                {
                    branchTotal += sales[i, j];
                }

                Console.WriteLine("Branch " + (i + 1) + " = " + branchTotal);

                if (branchTotal > Total)
                {
                    Total = branchTotal;
                    Branch = i + 1;
                }
            }

            Console.WriteLine("\nCategory Totals:");
            for (int j = 0; j < 4; j++)
            {
                decimal category = 0;

                for (int i = 0; i < 3; i++)
                {
                    category += sales[i, j];
                }

                Console.WriteLine("Category " + (j + 1) + " = " + category);
            }

            Console.WriteLine("Highest Branch: " + Branch);

            Console.Write("Enter Branch: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter Category: ");
            int col = int.Parse(Console.ReadLine());

            Console.Write("Enter New Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (row >= 1 && row <= 3 &&
                col >= 1 && col <= 4 &&
                amount >= 0)
            {
                sales[row - 1, col- 1] = amount;
                Console.WriteLine("Value Updated");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}
    
