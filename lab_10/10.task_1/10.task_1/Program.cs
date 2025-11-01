using System;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T>
{
    private readonly List<T> items;
    private int index;

    public ListyIterator(IEnumerable<T> collection)
    {
        this.items = new List<T>(collection);
        this.index = 0;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.index++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return this.index + 1 < this.items.Count;
    }

    public void Print()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.items[this.index]);
    }
}

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        ListyIterator<string> listy = null;

        while (input != "END")
        {
            string[] parts = input.Split();
            string command = parts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        var elements = parts.Skip(1).ToList();
                        listy = new ListyIterator<string>(elements);
                        break;

                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;

                    case "Print":
                        listy.Print();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine();
        }
    }
}
