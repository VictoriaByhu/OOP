using System;
using System.Linq;


class MaxSequence
{
    static void Main()
    {
        Console.WriteLine("Fill the array: ");
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int start = 0;
        int len = 1;
        int bestStart = 0;
        int bestLen = 1;

        for (int pos = 1; pos < nums.Length; pos++)
        {
            if (nums[pos] != nums[pos - 1])
            {
                start = pos;
                len = 1;
            }
            else
            {
                len++;
            }
            if(len > bestLen)
            {
                bestLen = len;
                bestStart = start;
            }
        }

        Console.WriteLine("Best sequence is: ");
        for (int pos = bestStart; pos < bestStart + bestLen; pos++)
        {
            Console.WriteLine(nums[pos]);
        }

    }
}
