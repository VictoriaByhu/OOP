using System;

class BiggestOfThree
{
    static void Main()
    {
        Console.WriteLine("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        int c = int.Parse(Console.ReadLine());

        if (a > b && a > c)
        {
            Console.WriteLine("The biggest is: " + a);
        }
        else if (b > c && b > a)
        {
            Console.WriteLine("The biggest is: " + b);
        }
        else
        {
            Console.WriteLine("The biggest is: " + c);
        }
    }
}
