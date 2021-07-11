using System;

namespace EmployeePayRollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Welcome to Employee PayRoll****");
            //UC2
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.GetAllEmployee();
            Console.WriteLine();
            //UC4:-Update Salary 
            EmployeePayroll employee = new EmployeePayroll();
            employee.EmployeeName = "Tom";
            employee.Salary = 40000000;
            employee.StartDate = Convert.ToDateTime("12 / 31 / 2020");
            employee.Gender = "Female";
            employee.PhoneNumber = "+91-7060325698";
            employee.Department = "Support";
            employee.Address = "Mumbai";
            employee.BasicPay = 300000;
            employee.Deduction = 1000;
            employee.TaxablePay = 2000;
            employee.IncomeTax = 1000;
            employee.NetPay = 1000;
            employeeRepo.AddEmployee(employee);
            Console.WriteLine();
            employeeRepo.GetAllEmployee();
        }
    }
}
