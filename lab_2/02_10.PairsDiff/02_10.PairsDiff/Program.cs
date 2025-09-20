using System;
using System.Linq;


class PairsDiff
{
    static void Main()
    {
        Console.WriteLine("Enter numbers: ");
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine("Enter difference: ");
        int diff = int.Parse(Console.ReadLine());

        int pairsCount = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = i+1; j < nums.Length; j++)
            {
                if (Math.Abs(nums[i] - nums[j]) == diff)
                {
                    pairsCount++;
                }
            }
        }


        if(pairsCount == 1)
        {
            Console.WriteLine("There is 1 pair with difference " + diff);
        }else if (pairsCount > 1)
        {
            Console.WriteLine("There are " + pairsCount + " pairs with difference " + diff);
        }else
        {
            Console.WriteLine("There are no pairs with difference " + diff);
        }
    }
}
