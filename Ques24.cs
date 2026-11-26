using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    class ExportTracker
    {
        string name;

        public ExportTracker(string name)
        {
            this.name = name;
            Console.WriteLine(name + " Created");
        }

        ~ExportTracker()
        {
            Console.WriteLine(name + " Destroyed");
        }
    }

    public class Ques24
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                ExportTracker e = new ExportTracker("Tracker" + i);
            }

            using (StreamWriter s = new StreamWriter("Report.txt"))
            {
                s.WriteLine("Export Report");
                s.WriteLine("objects created.");
            }

            Console.WriteLine("Report file closed");

            
            Console.WriteLine("Running ");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Program Ended");
        }
    }
}

