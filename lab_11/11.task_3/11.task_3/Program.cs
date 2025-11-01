using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lights = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());

        string[] states = { "Red", "Green", "Yellow" };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < lights.Length; j++)
            {
                int currentIndex = Array.IndexOf(states, lights[j]);
                int nextIndex = (currentIndex + 1) % states.Length;
                lights[j] = states[nextIndex];
            }

            Console.WriteLine(string.Join(" ", lights));
        }
    }
}
