using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Town { get; private set; }

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        if (result == 0)
        {
            result = this.Town.CompareTo(other.Town);
        }
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] parts = input.Split();
            string name = parts[0];
            int age = int.Parse(parts[1]);
            string town = parts[2];

            people.Add(new Person(name, age, town));

            input = Console.ReadLine();
        }

        int n = int.Parse(Console.ReadLine());
        Person target = people[n - 1];

        int equalCount = 0;
        int notEqualCount = 0;

        foreach (var person in people)
        {
            if (person.CompareTo(target) == 0)
                equalCount++;
            else
                notEqualCount++;
        }

        if (equalCount == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
        }
    }
}
