using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Test
    {
        

        public void SomeOperation()
        {
            {
                Example.Operation = new Example.MathOperation();
                Example.CalculateAndPrint(5, 7);

            }
        }
      
        
        private int MyMethod(int a , int b)
        {
            return a + b;
        }
    }
}
