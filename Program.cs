using System.Globalization;

namespace Delegate
{
    public class Program
    {
       private delegate void Greeting(string name);
       public static void Morning(string name) {
           Console.WriteLine("Good Morning " + name);
       }
       public static void Afternoon(string name)
       {
           Console.WriteLine("Good Afternoon " + name);
       }
       public static void Evening(string name)
       {
          Console.WriteLine("Good evening " + name);
       }



    
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string name = Console.ReadLine();
            Greeting greet = Morning;
            greet(name);

        }
    }
}
