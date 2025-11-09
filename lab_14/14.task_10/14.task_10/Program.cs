using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_10
{
    class Program
    {
        static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(' ')
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] parts = command.Split(' ');
                string action = parts[0];
                string criteria = parts[1];
                string parameter = parts[2];

                Predicate<string> match = GetPredicate(criteria, parameter);

                if (action == "Remove")
                {
                    guests.RemoveAll(match);
                }
                else if (action == "Double")
                {
                    List<string> matches = guests.Where(g => match(g)).ToList();
                    foreach (var guest in matches)
                    {
                        int index = guests.IndexOf(guest);
                        guests.Insert(index + 1, guest);
                    }
                }
            }

            if (guests.Any())
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string criteria, string parameter)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return name => name.StartsWith(parameter);
                case "EndsWith":
                    return name => name.EndsWith(parameter);
                case "Length":
                    int length = int.Parse(parameter);
                    return name => name.Length == length;
                default:
                    return name => false;
            }
        }
    }
}



