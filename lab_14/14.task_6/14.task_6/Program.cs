using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_6
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisibleByN = delegate (int x)
            {
                return x % n == 0;
            };

            numbers.Reverse();

            numbers.RemoveAll(isDivisibleByN);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
