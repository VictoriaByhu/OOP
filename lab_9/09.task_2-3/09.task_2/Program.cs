using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return string.Format("{0}: {1}", value.GetType().FullName, value);
    }

    public static Box<T> ReadFromConsole()
    {
        string input = Console.ReadLine();
        T convertedValue = (T)Convert.ChangeType(input, typeof(T));
        return new Box<T>(convertedValue);
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Box<string> strBox = Box<string>.ReadFromConsole();
            Console.WriteLine(strBox);
        }

        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Box<int> intBox = Box<int>.ReadFromConsole();
            Console.WriteLine(intBox);
        }
    }
}
