using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    public class BankAccount
    {
        private decimal balance;
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
                balance += amount;
            else
                Console.WriteLine("invalid");
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                Console.WriteLine("invalid amount");
            else if (amount > balance)
                Console.WriteLine("insufficient balance");
            else
                balance -= amount;


        }
        public class Bank
        {
            

            public static void Main(string[] args)
            {
                BankAccount a1 = new BankAccount();
                a1.Deposit(500);
                a1.Withdraw(100);
                Console.WriteLine("Account 1 :" + a1.Balance);

            }

        }
    }
}
