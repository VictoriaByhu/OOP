using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 1 || name.Length > 50 || !Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
        {
            throw new ArgumentException("Invalid name. It must be alphanumeric and 1-50 characters long.");
        }

        if (age < 1 || age > 100)
        {
            throw new ArgumentException("Invalid age. It must be a natural number between 1 and 100.");
        }

        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}
public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {

            result = char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
        }
        return result;
    }
}

public class AgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}
public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        if (n < 0 || n > 100)
        {
            Console.WriteLine("Invalid number of people. N must be between 0 and 100.");
            return;
        }

        SortedSet<Person> nameSet = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> ageSet = new SortedSet<Person>(new AgeComparator());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            try
            {
                Person person = new Person(name, age);
                nameSet.Add(person);
                ageSet.Add(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                i--;
            }
        }

        foreach (var p in nameSet)
        {
            Console.WriteLine(p);
        }

        foreach (var p in ageSet)
        {
            Console.WriteLine(p);
        }
    }
}
