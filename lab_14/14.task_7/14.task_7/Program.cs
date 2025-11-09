using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_7
{
    class Program
    {
        static void Main()
        {
            int maxLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> isShortEnough = delegate (string name)
            {
                return name.Length <= maxLength;
            };

            List<string> filteredNames = names.FindAll(isShortEnough);

            foreach (string name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
