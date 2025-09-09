using System;


class Average
{
    static void Main()
    {
        Console.WriteLine("Enter the base a: ");
        float a = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter the base b: ");
        float b = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter the height: ");
        float h = float.Parse(Console.ReadLine());

        float area = (a + b) / 2 * h;

        Console.WriteLine("The area is: " + area);
    }
}
