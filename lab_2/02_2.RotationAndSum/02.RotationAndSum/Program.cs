using System;
using System.Linq;


class RotationAndSum
{
    static void Main()
    {
        Console.WriteLine("Fill the array: ");
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] sum = new int[arr.Length];
        

        Console.WriteLine("Enter the num of rotations: ");
        int k = int.Parse(Console.ReadLine());

        for (int r = 0; r < k; r++)
        {
            int last = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[0] = last;

            Console.WriteLine("rotation" + (r + 1) + "[] = ");
            Console.WriteLine(string.Join(" ", arr));

            for(int i = 0;  i < arr.Length; i++)
            {
                sum[i] += arr[i];
            }
        }

        Console.WriteLine("sum[] = " + string.Join(" ", sum));

    }
}
