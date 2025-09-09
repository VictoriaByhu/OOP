using System;


class CalculateFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int factorial = 1;

        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("Factorial of n is: " + factorial);
    }
}
