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
      
        /// <summary>
        /// Method to ShowTable
        /// </summary>
        public void GetAllEmployee()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try //When an exception occurs, the control will move to the catch block
            {
              
                EmployeePayroll payroll = new EmployeePayroll();
                using (sqlConnection)
                {
                    string query = @"select * from EmployeePayroll";
                    //SqlCommand is interact with reational database or stored procedure to execute against SQL Server datdabase.
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
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
                            Console.WriteLine(payroll.EmployeeID + " " + payroll.EmployeeName + " " + payroll.Salary + " " + payroll.StartDate + " " + payroll.Gender + " " + payroll.PhoneNumber + " " + payroll.Department + " " + payroll.Address + " " + payroll.BasicPay + " " + payroll.Deduction + " " + payroll.TaxablePay + " " + payroll.IncomeTax + " " + payroll.NetPay);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    //close data reader
                    dr.Close();
                    //this.sqlConnection.Close();
                }
            }
            catch (Exception e) //Catch/Handle the exception  
            {
                Console.WriteLine(e.Message);
            }
            finally //this block of code will always get executed whether an exception occurs or not.
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// Create a add method 
        /// using Store Procedure
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(EmployeePayroll employee)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
              
                using (sqlConnection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetail", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    command.Parameters.AddWithValue("@Deduction", employee.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", employee.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", employee.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", employee.NetPay);
                    sqlConnection.Open();
                    var result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Data add successful");
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
         
            }
        }

    }

}
