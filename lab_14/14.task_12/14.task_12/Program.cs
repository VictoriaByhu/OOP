using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.task_12
{
    class Program
    {
        static void Main()
        {
            List<int> gems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<Tuple<string, int>> filters = new List<Tuple<string, int>>();

            string input = Console.ReadLine();
            while (input != "Forge")
            {
                string[] parts = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string filterType = parts[1];
                int parameter = int.Parse(parts[2]);
                var filterTuple = new Tuple<string, int>(filterType, parameter);

                if (command == "Exclude")
                {
                    filters.Add(filterTuple);
                }
                else if (command == "Reverse")
                {
                    filters.RemoveAll(f => f.Item1 == filterType && f.Item2 == parameter);
                }

                input = Console.ReadLine();
            }

            List<int> result = new List<int>();
            HashSet<int> excludedIndices = new HashSet<int>();

            foreach (var filter in filters)
            {
                string type = filter.Item1;
                int param = filter.Item2;

                for (int i = 0; i < gems.Count; i++)
                {
                    int sum = gems[i];

                    if (type == "Sum Left")
                    {
                        if (i > 0)
                            sum += gems[i - 1];
                    }
                    else if (type == "Sum Right")
                    {
                        if (i < gems.Count - 1)
                            sum += gems[i + 1];
                    }
                    else if (type == "Sum Left Right")
                    {
                        if (i > 0)
                            sum += gems[i - 1];
                        if (i < gems.Count - 1)
                            sum += gems[i + 1];
                    }

                    if (sum == param)
                        excludedIndices.Add(i);
                }
            }


            for (int i = 0; i < gems.Count; i++)
            {
                if (!excludedIndices.Contains(i))
                    Console.Write(gems[i] + " ");
            }
        }
    }
}
