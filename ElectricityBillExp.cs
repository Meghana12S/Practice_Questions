using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class ElectricityBillException : Exception
    {
        public ElectricityBillException(string message) : base(message)
        {

        }
            

    }
    public class ElectricityBillValidator
    {
        public string PayElectricityBill(int consumerNumber, double billAmount, double availableBalance)
        {
            if (consumerNumber <= 0)
            {
                throw new ElectricityBillException("Invalid consumer number");
            }
            if (billAmount <= 0 || availableBalance < 0)
            {
                throw new ElectricityBillException("Invalid payment details");
            }
            if(availableBalance < billAmount)
            {
                throw new ElectricityBillException("Invalid payment details");
                
            }
            double remainingBalance = availableBalance - billAmount;
            return "Electricity bill payment successful. Remaining Balance:" + remainingBalance;

        }
    }
    public class ElectricityBillExp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Consumer Number:");
                int consumerNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Bill Amount:");
                double billAmount = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Available Balance:");
                double availableBalance = double.Parse(Console.ReadLine());
                ElectricityBillValidator ele = new ElectricityBillValidator();
                string res = ele.PayElectricityBill(consumerNumber, billAmount, availableBalance);
                Console.WriteLine(res);



            }
            catch(ElectricityBillException e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
        }
    }
}
