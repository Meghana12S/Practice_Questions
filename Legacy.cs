using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    class LegacyReport
    {
        
        public void Show()
        {
            Console.WriteLine("Legacy Report Display");
        }

        
        public virtual void ShowDetails()
        {
            Console.WriteLine("Legacy Report Details");
        }
    }

    class DashboardReport : LegacyReport
    {
        
        public new void Show()
        {
            Console.WriteLine("Dashboard Report Display");
        }

        
        public override void ShowDetails()
        {
            Console.WriteLine("Dashboard Report Details");
        }
    }
    public  class Legacy
    {
        public static void Main(string[] args)
        {
            DashboardReport r = new DashboardReport();

            LegacyReport r2 = r;

            Console.WriteLine("Derived ref");
            r.Show();
            r.ShowDetails();

            Console.WriteLine();

            Console.WriteLine("Base ref");
            r2.Show();
            r2.ShowDetails();
        }
    }
}

