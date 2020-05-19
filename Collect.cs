using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace employee
{
    class EmployeeCollection<T> where T : new()
    {
        internal static List<T> coll = new List<T>();
        internal static string file;
        T this[int ind] { get => coll[ind]; set => coll[ind] = value; }
        public static void read_from_file(string f)
        {
            file = f;
            string[] Coll = File.ReadAllLines(file);
            foreach (string it in Coll)
            {
                coll.Add((T)Activator.CreateInstance(typeof(T), it));
            }
        }
        public static void sort_data(string pr)
        {
            try
            {
                coll = coll.OrderBy(p => p.GetType().GetProperty(pr).GetValue(p)).ToList();
                write_to_file();
            }
            catch
            {
                throw new Exception("Trere is not such property!");
            }
            Console.WriteLine("Done");
        }
        public static void find_data(string data)
        {
            try
            {
                foreach (var it in coll)
                {
                    if (it.ToString().Contains(data))
                    {
                        Console.WriteLine(it.ToString());
                    }
                }
            }
            catch
            {
                Console.WriteLine("There are no such elements in the collection");
            }
        }
        public static void add(T it)
        {
            coll.Add(it);
            Console.WriteLine("Done");
            write_to_file();
        }
        public static void edit_data(string data, T newIt)
        {
            try
            { 
                for (int i = 0; i < coll.Count; i++)
                {
                    if (coll[i].ToString().ToLower().Contains(data.ToLower()))
                    {
                        coll[i] = newIt;
                    }
                }
                write_to_file();
            }
            catch
            {
                Console.WriteLine("There are no such elements in the collection");
            }
            Console.WriteLine("Done");
        }
        public static void remove_data(string data)
        {
            try
            {
                for (int i = 0; i < coll.Count; i++)
                {
                    if (coll[i].ToString().ToLower().Contains(data.ToLower()))
                    {
                        coll.RemoveAt(i);
                    }
                }
                write_to_file();
            }
            catch
            {
                throw new Exception("Uncorrect data ");
            }
            Console.WriteLine("Done");
        }
        
        static void write_to_file()
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (var it in coll)
                {
                    writer.WriteLine(it.ToString());
                }
            }
        }
    }
}
