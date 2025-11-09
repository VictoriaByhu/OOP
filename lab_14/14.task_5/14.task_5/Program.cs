using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_5
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int> add = delegate (int n) { return n + 1; };
            Func<int, int> multiply = delegate (int n) { return n * 2; };
            Func<int, int> subtract = delegate (int n) { return n - 1; };

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                    break;

                if (command == "add")
                {
                    numbers = numbers.Select(add).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiply).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtract).ToList();
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}
