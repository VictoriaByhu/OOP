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
}

class Program
{
    public static void Swap<T>(List<T> list, int index1, int index2)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> items = new List<int>();

        for (int i = 0; i < n; i++)
        {
            items.Add(int.Parse(Console.ReadLine()));
        }

        string[] indices = Console.ReadLine().Split();
        int index1 = int.Parse(indices[0]);
        int index2 = int.Parse(indices[1]);

        Swap(items, index1, index2);

        foreach (int item in items)
        {
            Box<int> box = new Box<int>(item);
            Console.WriteLine(box);
        }
    }
}
