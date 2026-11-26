using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Delegate.Example;

namespace Delegate
{
    public class Class2
    {
        public static void Run()
        {
            Func<int,int,int> add = (x, y) => x + y;
            Console.WriteLine($"2+1 = {add (2, 1)}");
        }
        public sealed class OrderService
        {
            public event Action<string>? OrderPlaced;
            public event MathOperation MathOpEvent;
            public void PlaceOrder(int orderId)
            {
                Console.WriteLine($"OrderPlaced {orderId}");
                OrderPlaced?.Invoke($"Order#{orderId} has been placed");
                MathOpEvent(5, 7);

            }

        }
        public static class Example
        {

        }

    }
}
