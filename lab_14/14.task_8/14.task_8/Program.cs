using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, bool> isEven = delegate (int n)
            {
                return n % 2 == 0;
            };

            Comparison<int> customComparator = delegate (int a, int b)
            {
                bool aEven = isEven(a);
                bool bEven = isEven(b);

                if (aEven && !bEven)
                    return -1;
                else if (!aEven && bEven)
                    return 1;
                else
                    return a.CompareTo(b);
            };

            Array.Sort(numbers, customComparator);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
