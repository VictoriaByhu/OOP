using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_9
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] divisors = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, bool> isDivisibleByAll = delegate (int number)
            {
                foreach (int divisor in divisors)
                {
                    if (divisor != 0 && number % divisor != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            List<int> numbers = Enumerable.Range(1, n).ToList();

            List<int> result = numbers.Where(isDivisibleByAll).ToList();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
