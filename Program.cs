using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;

namespace employee
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeCollection<Employee>.read_from_file("text.txt");
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Data from file");
            Console.WriteLine("2.Sort by");
            Console.WriteLine("3.Find by");
            Console.WriteLine("4.Add new");
            Console.WriteLine("5.Edit");
            Console.WriteLine("6.Remove");
            Console.WriteLine("0.Exit");

            int z = 1;
            while (z != 0)
            {
                Console.WriteLine("Enter the number: ");
                z = int.Parse(Console.ReadLine());
                if (z == 1)
                {
                    foreach (var item in EmployeeCollection<Employee>.coll)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (z == 2)
                {
                    Console.Write("The possible properties for sorting: surname name age year sallary");
                    Console.Write("\nInput property: ");
                    string pr = Console.ReadLine();
                    EmployeeCollection<Employee>.sort_data(pr);
 
                }
                else if (z == 3)
                {
                    Console.Write("\nInput the data you want to find: \n");
                    string data = Console.ReadLine();
                    EmployeeCollection<Employee>.find_data(data);

                }
                else if (z == 4)
                {
                    Employee a = new Employee();
                    a.Add_new();
                    EmployeeCollection<Employee>.add(a);
                }
                else if (z == 5)
                {
                    Console.Write("Input the data you want to edit: ");
                    string data = Console.ReadLine();
                    Employee a = new Employee();
                    a.Add_new();
                    EmployeeCollection<Employee>.edit_data(data, a);
                }
                else if (z == 6)
                {
                    Console.Write("Input the data you want to remove: ");
                    string data = Console.ReadLine();
                    EmployeeCollection<Employee>.remove_data(data);
                }
                else if (z == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the correct number: ");
                    continue;
                }
            }
            Console.ReadKey();
        }
    }
}
