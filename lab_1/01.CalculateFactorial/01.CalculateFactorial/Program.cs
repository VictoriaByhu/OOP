using System;


class CalculateFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int factorial = 1;

        if (n == 0)
        {
            factorial = 1;
        }
        else if (n == 1)
        {
            factorial = 1;
        }
        else
        {
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
        }
            

        Console.WriteLine("Factorial of n is: " + factorial);
    }
}
