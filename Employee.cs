using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    public class Employees
    {
        private int a = 10;
        protected int b = 30;
        internal int c = 40;
        protected internal int d = 20;
        public Employees(int Eid)
        {
            Console.WriteLine("Employee Id;" + Eid);
        }
    }
    public class Helper
    {
        public void show()
        {
            Employee e = new Employees(101);
            Console.WriteLine(e.c);
            Console.WriteLine(e.d);
        }
    }
    public class Child : Employees
    {
        private bool b;
        private bool c;
        private bool d;

        public Child() : base(102)
        {

        }

        public void Display()
        {
            Console.WriteLine(b);

            Console.WriteLine(c);
            Console.WriteLine(d);
        }
    }
}
