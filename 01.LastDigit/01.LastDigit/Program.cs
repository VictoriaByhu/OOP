using System;


class LastDigit
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int lastDigit = n % 10;

        Console.WriteLine("The last digit is: " + lastDigit);
    }
}
