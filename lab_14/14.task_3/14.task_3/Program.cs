using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_3
{
    class Program
    {
        static void Main()
        {

            string input = Console.ReadLine();

            int[] numbers = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> findMin = delegate (int[] nums)
            {
                int min = int.MaxValue;
                foreach (int n in nums)
                {
                    if (n < min)
                    {
                        min = n;
                    }
                }
                return min;
            };

            Console.WriteLine(findMin(numbers));
        }
    }
}
