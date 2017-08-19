using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    public class UpdateEmployee
    {
        public void Update()
        {
            var employeeList = new ListEmployees();
            var updatedEmployee = employeeList.List("Pick an employee to update");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    cmd.CommandText = "select employeeid as Id, " +
                                      "firstname, lastname" +
                                      "from Employee";

                    var newFirstName = cmd.Parameters.Add("@firstname", SqlDbType.Char);
                    var newLastName = cmd.Parameters.Add("@lastname", SqlDbType.Char);
                    var employeeIdParameter = cmd.Parameters.Add("@id", SqlDbType.Int);

                    employeeIdParameter.Value = updatedEmployee;
                    Console.WriteLine("Enter new first name");
                    Console.Write(">");
                    newFirstName.Value = Console.ReadLine();

                    Console.WriteLine("Enter new last name");
                    Console.Write(">");
                    newLastName.Value = Console.ReadLine();

                    cmd.CommandText = "update Employee " +
                                      "set firstname = @firstname, lastname = @lastname " +
                                      "where employeeId = @id";

                    var reader = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}