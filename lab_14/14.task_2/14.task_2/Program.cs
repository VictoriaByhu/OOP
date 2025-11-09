using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_2
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();


            string[] names = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            Action<string> printKnight = delegate (string name)
            {
                Console.WriteLine("Sir " + name);
            };


            foreach (string name in names)
            {
                printKnight(name);
            }
        }
    }
}
