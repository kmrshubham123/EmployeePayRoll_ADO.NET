using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-9FUO12F;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }
}
