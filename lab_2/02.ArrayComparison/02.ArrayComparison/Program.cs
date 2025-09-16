using System;


class ArrayComparison
{
    static void Main()
    {
        Console.Write("Fill the first array: ");
        char[] arr1 = Console.ReadLine().ToCharArray();

        Console.Write("Fill the second array: ");
        char[] arr2 = Console.ReadLine().ToCharArray();

        int minLength = Math.Min(arr1.Length, arr2.Length);

        int result = 0; // 0 = рівні, <0 = arr1 менший, >0 = arr1 більший

        for (int i = 0; i < minLength; i++)
        {
            if (arr1[i] != arr2[i])
            {
                result = arr1[i].CompareTo(arr2[i]);
                break;
            }
        }

        if (result == 0 && arr1.Length != arr2.Length)
        {
            result = arr1.Length.CompareTo(arr2.Length);
        }

        if (result < 0)
        {
            Console.WriteLine(arr1);
            Console.WriteLine(arr2);
        }   
        else if (result > 0)
        {
            Console.WriteLine(arr2);
            Console.WriteLine(arr1);
        }
        else
        {
            Console.WriteLine(arr1);
            Console.WriteLine(arr2);
        }
    }
}
