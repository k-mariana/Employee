using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace employee
{
    class Employee
    {
        public string surname { get; set; }
        public int year { get; set; }
        public double sallary { get; set; }
        public Employee()
        {
            this.surname = null;
            this.year = 2000;
            this.sallary = 0;
        }
        public static string or_word(string el)
        {
            while (!Regex.IsMatch(el, @"^[a-z]*$", RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Enter the correct word: ");
                el = Console.ReadLine();
            }
            return el;
        }
        public static int or_year(string el)
        {
            while (el.All(Char.IsDigit) == false || int.Parse(el) > 2020 || int.Parse(el) < 1000)
            {
                Console.WriteLine("Enter another year: ");
                el = Console.ReadLine();
            }
            return int.Parse(el);
        }
        public static double or_number(string el)
        {
            while (double.Parse(el) < 0)
            {
                Console.WriteLine("Enter another number: ");
                el = Console.ReadLine();
            }
            return double.Parse(el);
        }
        public Employee(string el)
        {
            string[] a = el.Split(' ');
            surname = or_word(a[0]);
            year = or_year(a[1]);
            sallary = or_number(a[2]);
        }
        public Employee(string surname, int year, double sallary)
        {
            surname = or_word(surname);
            year = or_year(year.ToString());
            sallary = or_number(sallary.ToString());
        }
        public void Add_new()
        {
            Console.Write("surname: ");
            string s = Console.ReadLine();
            this.surname = or_word(s);
            Console.Write("year: ");
            string y = Console.ReadLine();
            this.year = or_year(y);
            Console.Write("sallary: ");
            string sal = Console.ReadLine();
            this.sallary = or_number(sal);
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", surname, year, sallary);
        }
    }
}

