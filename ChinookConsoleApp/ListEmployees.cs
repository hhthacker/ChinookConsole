
using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class EmployeeListResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class ListEmployees
    {
        public int List(string prompt)
        {
            Console.Clear();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    var result = connection.Query<EmployeeListResult>("select employeeid as Id, " +
                                                                      "firstname + ' ' + lastname as fullname " +
                                                                      "from Employee");

                    foreach (var employee in result)
                    {
                        Console.WriteLine($"{employee.Id}.) {employee.FullName}");
                    }

                    Console.WriteLine(prompt);
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                return 0;
            }
        }
    }
}