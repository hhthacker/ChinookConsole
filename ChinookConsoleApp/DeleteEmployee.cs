
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class DeleteEmployee
    {
        public void Delete()
        {
            var employeeList = new ListEmployees();
            var firedEmployee = employeeList.List("Pick an employee to fire");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "Delete From Employee where EmployeeId = @EmployeeId";

                var employeeIdParameter = cmd.Parameters.Add("@EmployeeId", SqlDbType.Int);
                employeeIdParameter.Value = firedEmployee;

                try
                {
                    var affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        Console.WriteLine("Success");
                    }
                    else if (affectedRows > 1)
                    {
                        Console.WriteLine("HEEEEEEEE");
                    }
                    else
                    {
                        Console.WriteLine("Failed to find a match");
                    }
                    Console.WriteLine("Press enter to return to the menu");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}