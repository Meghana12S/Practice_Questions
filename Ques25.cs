using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    public class Ques25
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] desc = new string[3];
                double[] amount = new double[3];
                double total = 0;

                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Enter Expense Description: ");
                    desc[i] = Console.ReadLine();

                    Console.Write("Enter Amount: ");
                    string input = Console.ReadLine();

                    if (!double.TryParse(input, out amount[i]) || amount[i] < 0)
                    {
                        Console.WriteLine("Invalid amount ");
                        return;
                    }

                    total += amount[i];
                }

                string folder = "Exports";
                Directory.CreateDirectory(folder);

                string fileName = "ExpenseReport_" +
                                  DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                                  ".txt";

                string path = Path.Combine(folder, fileName);

                CultureInfo india = new CultureInfo("en-IN");

                using (StreamWriter file = new StreamWriter(path))
                {
                    file.WriteLine("Expense Report");
                    file.WriteLine("Date : " + DateTime.Now);
                    file.WriteLine();

                    for (int i = 0; i < 3; i++)
                    {
                        file.WriteLine(
                            desc[i] + " - " +
                            amount[i].ToString("C", india));
                    }

                    file.WriteLine();
                    file.WriteLine("Total : " +
                        total.ToString("C", india));
                }

                Console.WriteLine("Report saved successfully.");
                Console.WriteLine("Location: " + path);
            }
            catch
            {
                Console.WriteLine("path unavailable");
            }
        }
    }
}


