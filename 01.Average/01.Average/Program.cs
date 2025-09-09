using System;


class Average
{
    static void Main()
    {
        Console.WriteLine("Enter value of a: ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter value of b: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter value of c: ");
        int c = int.Parse(Console.ReadLine());

        float average = (float)(a + b + c) / 3;

        Console.WriteLine("The average is: " + average);
    }
}
