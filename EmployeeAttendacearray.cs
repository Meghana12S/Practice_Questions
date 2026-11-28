using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment1;

namespace Assessment1
{
    public class EmployeeAttendanceValidator
    {
        public string EvaluateEmployeeAttendance(int[,] attendanceRecords, int employeeCount, int workingDays)
        {
            if(attendanceRecords == null)
            {
                return "Invalid Input";
            }
            if(employeeCount <= 0 || workingDays <= 0)
            {
                return "Invalid Input";
            }
            if(attendanceRecords.GetLength(0) != employeeCount || attendanceRecords.GetLength(1) != workingDays)
            {
                return "Invalid Input";
            }
            for(int e = 0; e < employeeCount; e++)
                {
                for (int d = 0; d < workingDays; d++)
                {
                    if (attendanceRecords[e,d] != 0 || attendanceRecords[e,d] != 1)
                    {
                        return "Invalid Input";
                    }
                }

            }
            List<string> lines = new List<string>();
            int totalPresent = 0, totalAbsent = 0;
            for (int e = 0; e < employeeCount; e++)
            {
                int present = 0, absent = 0;
                for (int d = 0; d < workingDays; d++)
                {
                    if (attendanceRecords[e, d] == 1)
                    {
                        present++;
                    }
                    else
                    {
                        absent++;
                    }
                }
                totalPresent += present;
                totalAbsent += absent;
                int percentage = (present * 100) / workingDays;
                string status = percentage >= 75 ? "Eligible" : "Not Eligible";
                lines.Add("Employee " + (e + 1) + ":");
                lines.Add("Present Days:" + present);
                lines.Add("Absent Days: " + absent);
                lines.Add("Attendance Percentage: " + percentage + "%");
                lines.Add("Attendance Status: " + status);
            }
            lines.Add("Overall Present Records: " + totalPresent);
            lines.Add("Overall Absent Records: " + totalAbsent);
            return string.Join("\n", lines);


            }

        }
    }
    public class EmployeeAttendacearray
    {
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Number of Employees:");
        int employeeCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Number of Working Days");
        int workingDays = int.Parse(Console.ReadLine());
        int[,] attendanceRecords = new int[employeeCount, workingDays];
        for (int e = 0; e < employeeCount; e++)
        {
            Console.WriteLine("Enter Attendance for Employee " + (e + 1) + ":");
            for (int d = 0; d < workingDays; d++)
            {
                attendanceRecords[e, d] = int.Parse(Console.ReadLine());
            }
        }
        EmployeeAttendanceValidator v = new EmployeeAttendanceValidator();
        Console.WriteLine(v.EvaluateEmployeeAttendance(attendanceRecords, employeeCount, workingDays));
    




        }
    }

