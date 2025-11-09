using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] names = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> printName = delegate (string name)
            {
                Console.WriteLine(name);
            };

            foreach (var name in names)
            {
                printName(name);
            }
        }
    }
}
