using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    public class Book
    {
        private bool available = true;
        public int id { get; set; }
        public string title { get; set; }

        public Book(int id, string title)
        {
            id = id;
            title = title;


        }
        public void Borrow()
        {
            if (available)
            {
                available = false;
                Console.WriteLine(title + "borrowed");
            }
            else
                Console.WriteLine(title + "is unavailable");
        }
        public void Return()
        {
            if (!available)
            {
                available = true;
                Console.WriteLine(title + "returned");
            }
            else
                Console.WriteLine(title + "already available");
        }
        public class Library

        {
            public static void Main(string[] args)
            {
                Book b = new Book(1, "C#sharp Programming");
                b.Borrow();
                b.Return();
            }
        }
    }
}
