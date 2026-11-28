using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment11
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string category { get; set; }
        public int StockQuantity { get; set; }
        public int UnitPrice { get; set; }
    }
    public class MedicineInventory
    {
        public static List<Medicine> MedicineList = new List<Medicine>();
        public void AddMedicine(int id, string name, string category, int stock, int price)
        {
            Medicine med = new Medicine();
            med.MedicineId = id;
            med.MedicineName = name;
            med.category = category;
            med.StockQuantity = stock;
            med.UnitPrice = price;
            MedicineList.Add(med);
        }
        public List<Medicine> GetMedicineByCategory(string category)
        {
            List<Medicine> result = new List<Medicine>();
            foreach (Medicine med in MedicineList)
            {
                if (med.category == category)
                {
                    result.Add(med);
                }
            }
            return result;


        }
        public string CalculateBill(int id, int quantity)
        {
            Medicine found = null;
            foreach (Medicine med in MedicineList)
            {
                if (med.MedicineId == id)
                {
                    found = med;
                    break;
                }
            }
            if (found == null)
            {
                return "Medicine not found";
            }
            if (quantity <= 0)
            {
                return "Invalid Quantity";
            }
            if (quantity > found.StockQuantity)
            {
                return "Insufficient stock";
            }
            double totalAmount = found.UnitPrice * quantity;
            string message = "No Discount";
            double discount = 0;
            if (totalAmount > 1000)
            {
                discount = 10;
                message = "Bulk Discount";
                
            }
            else if (totalAmount > 500)
            {
                discount = 5;
                message = "Standard Discount";
                
            }
            
            double finalAmount = totalAmount - (totalAmount * discount / 100);
            return "Bill" + message + ", Medicine: " + found.MedicineName + ", Quantity: " + quantity + ", Final Amount: " + finalAmount.ToString("F2");


        }
        public static void Main(string[] args)
        {
            MedicineInventory medicine = new MedicineInventory();
            while (true)
            {
                Console.WriteLine("1. Add Medicine");
                Console.WriteLine("2. List by Category");
                Console.WriteLine("3. Calculate Bill");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Medicine Id:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Medicine Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Category:");
                        string category = Console.ReadLine();
                        Console.WriteLine("Enter Stock Quantity:");
                        int stock = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Unit Price");
                        int price = int.Parse(Console.ReadLine());
                        medicine.AddMedicine(id, name, category, stock, price);
                        Console.WriteLine("Medicine record added successfully");
                        break;
                    case 2:
                        Console.WriteLine("Enter category");
                        string category1 = Console.ReadLine();
                        List<Medicine> result = medicine.GetMedicineByCategory(category1);
                        if (result.Count == 0)
                        {
                            Console.WriteLine("No medicine fount in category " + category1);
                        }
                        else
                        {
                            Console.WriteLine("ID Name Category Stock Price");
                            foreach (Medicine med in result)
                            {
                                Console.WriteLine(med.MedicineId + " " + med.MedicineName + " " + med.category + " " + med.StockQuantity + " " + med.UnitPrice);
                            }

                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Medicine Id:");
                        int id1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Quantity");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine(medicine.CalculateBill(id1, quantity));
                        break;
                    case 4:
                        Console.WriteLine("Existing system.Goodbye!");
                        break;

                }


            }

        }
    }
}
