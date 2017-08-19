using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();

                Console.WriteLine("----------------------Welcome to Chinook---------------------");
                Console.WriteLine("------------Please select from the following options---------");
                Console.WriteLine("1. List Employees");
                Console.WriteLine("2. Add an Employee");
                Console.WriteLine("3. Update an Employee");
                Console.WriteLine("4. Delete an Employee");
                Console.WriteLine("9. Exit");
                Console.WriteLine("");
                Console.Write(">");
                var selection = Console.ReadLine();


                if (selection == "1") new ListEmployees().List("Press enter to return to menu");
                if (selection == "2") new AddEmployee().Add();
                if (selection == "3") new UpdateEmployee().Update();
                if (selection == "4") new DeleteEmployee().Delete();
<<<<<<< HEAD

=======
>>>>>>> 969c45980436afe10a97c0fe707f5af66f7676b3
                if (selection == "9") break;

            }
        }
    }
}
