using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public int Group { get; set; }

    public Person(string name, int group)
    {
        Name = name;
        Group = group;
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split(' ');
            string fullName = parts[0] + " " + parts[1];
            int group = int.Parse(parts[2]);

            people.Add(new Person(fullName, group));
        }

        var grouped =
            from p in people
            group p by p.Group into g
            orderby g.Key
            select g;

        foreach (var group in grouped)
        {
            string names = string.Join(", ",
                group.Select(p => p.Name));
            Console.WriteLine(group.Key + " - " + names);
        }
    }
}
