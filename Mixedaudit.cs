using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    class Audit
    {
        public string Message;
        public Audit(string message)
        {
            Message = message;
        }
        public override string ToString()
        {
            return Message;
        }
    }
    public class Mixedaudit
    {
        public static void Main(string[] args)
        {
            Audit a = new Audit("logged in");
            Audit a1 = new Audit("logged in");
            Audit a2 = a;
            object[] item = { 90, 2490.50m, "started application", DateTime.Today, a };
            foreach (object o in item)
            {
                Console.WriteLine(item + " " + item.GetType().Name);
            }
            Console.WriteLine(a.Equals(a1));
            Console.WriteLine(a.Equals(a2));

        }

    }

}
