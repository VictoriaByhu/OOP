using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_11
{
    class Program
    {
        static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] parts = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string filterType = parts[1];
                string filterParameter = parts[2];
                string filter = filterType + ";" + filterParameter;

                if (command == "Add filter")
                {
                    if (!filters.Contains(filter))
                        filters.Add(filter);
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(filter);
                }

                input = Console.ReadLine();
            }

            foreach (string filter in filters)
            {
                string[] parts = filter.Split(';');
                string type = parts[0];
                string parameter = parts[1];
                Predicate<string> predicate = GetPredicate(type, parameter);

                people.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", people));
        }

        static Predicate<string> GetPredicate(string type, string parameter)
        {
            if (type == "Starts with")
                return delegate (string name) { return name.StartsWith(parameter); };
            else if (type == "Ends with")
                return delegate (string name) { return name.EndsWith(parameter); };
            else if (type == "Length")
            {
                int len = int.Parse(parameter);
                return delegate (string name) { return name.Length == len; };
            }
            else if (type == "Contains")
                return delegate (string name) { return name.Contains(parameter); };
            else
                return delegate (string name) { return false; };
        }
    }
}
