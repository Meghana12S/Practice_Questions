using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public static class Example
    {
        public delegate int MathOperation(int a, int b);
        public static MathOperation Operation;
        public static void CalculateAndPrint(int a, int b)
        {
            Console.WriteLine($"Result : {Operation(a, b)}");
        }
        public static void Run()
        {
            Test t = new Test();
            t.MyMethod();
            
        }


        public class Class1
        {
            public static void Main(String[] args)
            {

            }

        }
    }
}

