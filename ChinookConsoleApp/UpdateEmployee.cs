using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    class UpdateEmployee
    {
        public void Update()
        {
            Console.Clear();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                var employeeListCommand = connection.CreateCommand();

                employeeListCommand.CommandText = "select employeeid as Id, " +
                                                  "firstname + ' ' + lastname as fullname " +
                                                  "from Employee";


                var employeeUpdateCommand = connection.CreateCommand();

                employeeUpdateCommand.CommandText = "update Employee " +
                                        "set firstname = @firstname, lastname = @lastname " +
                                        "where employeeId = @id" +
                                        "and firstname + ' ' + lastname as fullname = @fullname ";

                try
                {
                    connection.Open();
                    var reader = employeeListCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}.) {reader["FullName"]}");
                    }

                    Console.WriteLine("Select an Employee number.");
                    Console.Write(">");
                    var updateSelection = Console.ReadLine();
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
