using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class MedicineStockException : Exception
    {
        public MedicineStockException(string message):base(message)
        {

        }
    }
    public class MedicineStockValidator
    {
        public string DispenseMedicine(int medicineId, int availableStock, int requestedQuantity)
        {
            if(medicineId <= 0)
            {
                throw new MedicineStockException("Invalid medicine ID");
            }
            if(availableStock < 0 || requestedQuantity <= 0)
            {
                throw new MedicineStockException("Invalid medicine stock details");
            }
            if(requestedQuantity > availableStock)
            {
                throw new MedicineStockException("Invalid medicine stock details");
            }
            int remainingStock = availableStock - requestedQuantity;
            return "Medicine dispensed successfully.Remaining Stock:" + remainingStock;

        }
        
    }
    public class HospitalExp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Medicine ID:");
                int medicineId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Available Stock:");
                int availableStock = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Requested Quantity:");
                int requestedQuantity = int.Parse(Console.ReadLine());
                MedicineStockValidator val = new MedicineStockValidator();
                string res = val.DispenseMedicine(medicineId, availableStock, requestedQuantity);
                Console.WriteLine(res);

            }
            catch(MedicineStockException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            


        }
    }
}
