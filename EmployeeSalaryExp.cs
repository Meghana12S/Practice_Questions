using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class EmployeeSalaryException : Exception
    {
        public EmployeeSalaryException(string message) : base(message)
        {

        }
    }
    public class EmployeeSalaryValidator
    {
        public double CalculateSalary(int employeeId, double basicSalary, double allowance, double deduction)
        {
            if(employeeId <= 0)
            {
                throw new EmployeeSalaryException("Invalid employee ID");

            }
           
            if(basicSalary <= 0 || allowance <= 0 || deduction < 0)
            {
                throw new EmployeeSalaryException("Invalid salary details");
            }
            double totalSalary = basicSalary + allowance;
            if (deduction > totalSalary)
            {
                throw new EmployeeSalaryException("Invalid salary details");

            }
            double finalSalary = totalSalary - deduction;
            return finalSalary;
        }
    }
    public class EmployeeSalaryExp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Emploee ID:");
                int employeeId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Basic Salary:");
                double basicSalary = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Allowance:");
                double allowance = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Deduction:");
                double deduction = double.Parse(Console.ReadLine());
                EmployeeSalaryValidator emp = new EmployeeSalaryValidator();
                double res = emp.CalculateSalary(employeeId, basicSalary,allowance, deduction);
                Console.WriteLine("Final Salary:" + res);



            }
            catch(EmployeeSalaryException e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
            

        }

        
    }
}
