using System;
using System.Linq;


class CompileAndSum
{
    static void Main()
    {
        Console.WriteLine("Enter the size of array that are multiples of four: ");
        int n = int.Parse(Console.ReadLine());

        while (n % 4 != 0)
        {
            Console.WriteLine("Enter the size of array that are multiples of four: ");
            n = int.Parse(Console.ReadLine());
        }

        int[] arr = new int[n];

        Console.WriteLine("Fill the array: ");
        for(int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine()); 
        }

        int k = arr.Length / 4;

        int[] left = arr.Take(k).Reverse().ToArray();
        int[] right = arr.Skip(k * 3).Reverse().ToArray();
        int[] middle = arr.Skip(k).Take(2 * k).ToArray();

        int[] combined = left.Concat(right).ToArray();

        int[] result = new int[2 * k];
        for (int i = 0; i < 2 * k; i++)
        {
            result[i] = combined[i] + middle[i];
        }

        Console.WriteLine(string.Join(" ", combined) + " +");
        Console.WriteLine(string.Join(" ", middle) + " =");
        Console.WriteLine(string.Join(" ", result));
    }
}
