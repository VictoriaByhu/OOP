using System;


class nthDigit
{
    static void Main()
    {
        int number = 2174;

        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        if (n >= 1 && n <= 4)
        {
            int nDigit = (number / (int)Math.Pow(10, n - 1)) % 10;
            Console.WriteLine("Your digit is:" + nDigit);
        }
        else
        {
            Console.WriteLine("-");
        }
        
    }
}
