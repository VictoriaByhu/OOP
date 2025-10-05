using System;
using System.Collections.Generic;


class Program
{
    class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public Person()
        {
            Name = "Unknown";
            Age = 1;
        }

        public Person(int age)
        {
            Name = "Unknown";
            Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


    }

    class Family
    {
        private List<Person> members = new List<Person>();

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = members[0];
            for (int i = 1; i < members.Count; i++)
            {
                if (members[i].Age > oldest.Age)
                {
                    oldest = members[i];
                }
            }
            return oldest;
        }
    }
    static void Main()
    {
        Person first = new Person("Pesho", 20);

        Person second = new Person
        {
            Name = "Gosho",
            Age = 18
        };

        Person third = new Person("Stamat", 43);

        Family family = new Family();
        Console.WriteLine("How many people are in the family? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Person p = new Person(name, age);
            family.AddMember(p);

        }
        Person oldest = family.GetOldestMember();
        Console.WriteLine("The oldest is " + oldest.Name + ", " + oldest.Age);

    }
}
