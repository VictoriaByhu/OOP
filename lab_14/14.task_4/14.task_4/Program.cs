using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bounds = Console.ReadLine().Split(' ');
            int start = int.Parse(bounds[0]);
            int end = int.Parse(bounds[1]);

            string command = Console.ReadLine();

            Predicate<int> filter;

            if (command == "even")
            {
                filter = delegate (int number) { return number % 2 == 0; };
            }
            else
            {
                filter = delegate (int number) { return number % 2 != 0; };
            }

            List<int> numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
