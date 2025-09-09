using System;


class ProductSign
{
    static void Main()
    {
        Console.WriteLine("Enter a: ");
        float a = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter b: ");
        float b = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        float c = float.Parse(Console.ReadLine());

        string product;
        int negativeCount = 0;

        if (a < 0) negativeCount++;
        if (b < 0) negativeCount++;
        if (c < 0) negativeCount++;

        if (negativeCount % 2 == 0)
        {
            product = "positive";
        }
        else
        {
            product = "negative";
        }

            Console.WriteLine("The product will be " + product);
      
    }
}
