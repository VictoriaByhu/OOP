using System;
using System.Diagnostics.Eventing.Reader;


class TheBiggestMutualEnd
{
    static void Main()
    {

        Console.WriteLine("Fill the first array: ");
        string[] words1 = Console.ReadLine().Split(' ');
        Console.WriteLine("Fill the second array: ");
        string[] words2 = Console.ReadLine().Split(' ');

        int leftCount = 0;
        for (int i = 0, j = 0; i < words1.Length && j < words2.Length; i++, j++)
        {
            if (words1[i] == words2[j])
            {
                leftCount++;
            }
            else
            {
                break;
            }
            
        }

        int rightCount = 0;
        for(int i = words1.Length - 1, j = words2.Length - 1; i >= 0 && j >=0;  i--, j--)
        {
            if(words1[i] == words2[j])
            {
                rightCount++;
            }
            else
            {
                break;
            }
        }

        if(leftCount == 0 && rightCount == 0)
        {
            Console.WriteLine("There's no mutual ends.");
        }
        else if(leftCount > rightCount)
        {
            Console.WriteLine("The biggest mutual end is on the left: ");
            for(int i = 0; i < leftCount; i++)
            {
                Console.WriteLine(words1[i]);
            }
        }
        else
        {
            Console.WriteLine("The biggest mutual end is on the right: ");
            for(int i = words1.Length - rightCount; i < words1.Length; i++)
            {
                Console.WriteLine(words1[i]);
            }
        }
    }
}
