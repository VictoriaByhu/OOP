using System;
using System.Linq;


class MostFreqNum
{
    static void Main()
    {
        Console.WriteLine("Enter numbers:");
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int mostFrequent = nums[0];
        int maxCount = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            int count = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] == nums[i])
                {
                    count++;
                }
            }

            if (count > maxCount)
            {
                maxCount = count;
                mostFrequent = nums[i];
            }
        }

        Console.WriteLine("Most frequent number: " + mostFrequent);
    }
}
