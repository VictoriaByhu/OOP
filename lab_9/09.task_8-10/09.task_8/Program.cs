using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public void Add(T element)
    {
        elements.Add(element);
    }

    public T Remove(int index)
    {
        T removed = elements[index];
        elements.RemoveAt(index);
        return removed;
    }

    public bool Contains(T element)
    {
        return elements.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temp = elements[index1];
        elements[index1] = elements[index2];
        elements[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (var el in elements)
            if (el.CompareTo(element) > 0)
                count++;
        return count;
    }

    public T Max()
    {
        T max = elements[0];
        foreach (var el in elements)
            if (el.CompareTo(max) > 0) max = el;
        return max;
    }

    public T Min()
    {
        T min = elements[0];
        foreach (var el in elements)
            if (el.CompareTo(min) < 0) min = el;
        return min;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    public void Print()
    {
        foreach (var el in elements)
            Console.WriteLine(el);
    }

    public List<T> Elements => elements;
}

public static class Sorter
{
    public static void Sort<T>(CustomList<T> list) where T : IComparable<T>
    {
        list.Elements.Sort();
    }
}

class Program
{
    static void Main()
    {
        CustomList<string> list = new CustomList<string>();
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            string action;
            string argument;

            int spaceIndex = command.IndexOf(' ');
            if (spaceIndex == -1)
            {
                action = command;
                argument = null;
            }
            else
            {
                action = command.Substring(0, spaceIndex);
                argument = command.Substring(spaceIndex + 1);
            }

            switch (action)
            {
                case "Add":
                    list.Add(argument);
                    break;
                case "Remove":
                    list.Remove(int.Parse(argument));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(argument));
                    break;
                case "Swap":
                    string[] indices = argument.Split();
                    list.Swap(int.Parse(indices[0]), int.Parse(indices[1]));
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(argument));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    list.Print();
                    break;
                case "Sort":
                    Sorter.Sort(list);
                    break;
            }
        }
    }
}
