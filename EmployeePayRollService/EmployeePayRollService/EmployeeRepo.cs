using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRollService
{
    /// <summary>
    /// setup the connection from employee Payroll database
    /// </summary>
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-9FUO12F;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        /// <summary>
        /// Method to ShowTable
        /// </summary>
        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll payroll = new EmployeePayroll();
                using (this.sqlConnection)
                {
                    string query = @"select * from EmployeePayroll";
                    //SqlCommand is interact with reational database or stored procedure to execute against SQL Server datdabase.
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    //SqlDataReader Provides a way of reading a forward-only stream of rows from a SQL Server database.
                    SqlDataReader dr = cmd.ExecuteReader(); //Returns the sqlDataReader Object.
                    if (dr.HasRows) //Gets the value that indicates whether the SQLDataReader contains one or more rows.
                    {               //Returns:true if the data SQLDataReader contains one or more rows; otherwise false
                        while (dr.Read())
                        {
                            payroll.EmployeeID = dr.GetInt32(0);
                            payroll.EmployeeName = dr.GetString(1);
                            payroll.Salary = dr.GetDouble(2);
                            payroll.StartDate = dr.GetDateTime(3);
                            payroll.Gender = dr.GetString(4);
                            payroll.PhoneNumber = dr.GetString(5);
                            payroll.Department = dr.GetString(6);
                            payroll.Address = dr.GetString(7);
                            payroll.BasicPay = dr.GetDouble(8);
                            payroll.Deduction = dr.GetDouble(9);
                            payroll.TaxablePay = dr.GetDouble(10);
                            payroll.IncomeTax = dr.GetDouble(11);
                            payroll.NetPay = dr.GetDouble(12);
                            System.Console.WriteLine(payroll.EmployeeID + " " + payroll.EmployeeName + " " + payroll.Salary + " " + payroll.StartDate + " " + payroll.Gender + " " + payroll.PhoneNumber + " " + payroll.Department + " " + payroll.Address + " " + payroll.BasicPay + " " + payroll.Deduction + " " + payroll.TaxablePay + " " + payroll.IncomeTax + " " + payroll.NetPay);

                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                    //close data reader
                    dr.Close();
                    this.sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }

}
