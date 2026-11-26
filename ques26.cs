using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    public class Employee
    {
        public int eID;
        public string Name;
        public string email;
        internal bool c;
        internal bool d;
        private int v;

        public Employee(int v)
        {
            this.v = v;
        }

        public Employee(int eID, string Name, string email)
        {
            this.eID = eID;
            this.Name = Name;
            this.email = email;
        }
        public virtual void Display()
        {
            Console.WriteLine(eID + " " + Name + " " + email);
        }

        public static implicit operator Employee(Employees v)
        {
            throw new NotImplementedException();
        }

        public class Manager : Employee
        {
            public string department;
            public int size;

            public Manager(int eID, string Name, string email,string department,int size) : base(eID, Name, email)
            {
                this.department = department;
                this.size = size;

            }
            public override void Display()
            {
                
                Console.WriteLine(eID+" "+Name+" "+ email +" "+department + " " + size);
            }
        }


        public class ques26
        {
            public static void Main(string[] args)
            {
                Employee[] e = {new Employee(1,"megha","megha12@gmail.com"),
                new Employee(2,"bha","bha23@gmail.com"),
                new Manager(3,"test","test56@gmail.com","aids",4),
                new Manager(4,"test2","test2@gmail.com","cse",5)};
                foreach (Employee emp in e)
                    emp.Display();

            }
        }
    }
}

