using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Box<T> : IComparable<Box<T>> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public T Value
    {
        get { return value; }
    }

    public override string ToString()
    {
        return string.Format("{0}: {1}", value.GetType().FullName, value);
    }

    public int CompareTo(Box<T> other)
    {
        if (other == null) return 1;
        return this.value.CompareTo(other.value);
    }
}

class Program
{
    public static int CountGreaterThan<T>(List<Box<T>> list, Box<T> element) where T : IComparable<T>
    {
        int count = 0;
        foreach (var box in list)
        {
            if (box.CompareTo(element) > 0)
                count++;
        }
        return count;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<double>> items = new List<Box<double>>();

        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());
            items.Add(new Box<double>(input));
        }

        double comparisonValue = double.Parse(Console.ReadLine());
        Box<double> compareBox = new Box<double>(comparisonValue);

        int count = CountGreaterThan(items, compareBox);
        Console.WriteLine(count);
    }
}
