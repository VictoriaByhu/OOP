using System;
using System.Collections.Generic;
using System.Linq;

interface IIdentify
{
    string Id { get; }
}

interface IBirth
{
    string Birthdate { get; }
}

interface IBuyer
{
    int Food { get; }
    void BuyFood();
}

class Citizen : IIdentify, IBirth, IBuyer
{
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthdate { get; }
    public int Food { get; private set; }

    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
        Food = 0;
    }

    public void BuyFood()
    {
        Food += 10;
    }
}

class Rebel : IBuyer
{
    public string Name { get; }
    public int Age { get; }
    public string Group { get; }
    public int Food { get; private set; }

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
    }

    public void BuyFood()
    {
        Food += 5;
    }
}

class Robot : IIdentify
{
    public string Model { get; }
    public string Id { get; }

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }
}

class Pet : IBirth
{
    public string Name { get; }
    public string Birthdate { get; }

    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }
}

class Program
{
    static void Main()
    {
        int part = int.Parse(Console.ReadLine());

        switch (part)
        {
            case 1:
                var entrants = new List<IIdentify>();
                string line;

                while ((line = Console.ReadLine()) != null)
                {
                    if (line.Equals("End"))
                        break;

                    var parts = line.Split(' ');
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        if (!int.TryParse(parts[1], out int age))
                            continue;
                        string id = parts[2];
                        entrants.Add(new Citizen(name, age, id));
                    }
                    else if (parts.Length == 2)
                    {
                        string model = parts[0];
                        string id = parts[1];
                        entrants.Add(new Robot(model, id));
                    }
                }

                string fakeSuffix = Console.ReadLine();

                foreach (var e in entrants.Where(x => x.Id.EndsWith(fakeSuffix)))
                {
                    Console.WriteLine(e.Id);
                }
                break;

            case 2:
                var dates = new List<IBirth>();

                string input;
                while ((input = Console.ReadLine()) != "End")
                {
                    var parts = input.Split(' ');
                    string type = parts[0];

                    if (type == "Citizen")
                    {
                        string name = parts[1];
                        int age = int.Parse(parts[2]);
                        string id = parts[3];
                        string birthdate = parts[4];
                        dates.Add(new Citizen(name, age, id, birthdate));
                    }
                    else if (type == "Robot")
                    {
                        string model = parts[1];
                        string id = parts[2];
                    }
                    else if (type == "Pet")
                    {
                        string name = parts[1];
                        string birthdate = parts[2];
                        dates.Add(new Pet(name, birthdate));
                    }
                }

                string year = Console.ReadLine();

                foreach (var b in dates.Where(x => x.Birthdate.EndsWith(year)))
                {
                    Console.WriteLine(b.Birthdate);
                }
                break;
            case 3:
                int n = int.Parse(Console.ReadLine());
                var people = new Dictionary<string, IBuyer>();

                for (int i = 0; i < n; i++)
                {
                    string[] parts = Console.ReadLine().Split(' ');

                    if (parts.Length == 4)
                    {
                        string name = parts[0];
                        int age = int.Parse(parts[1]);
                        string id = parts[2];
                        string birthdate = parts[3];

                        people[name] = new Citizen(name, age, id, birthdate);
                    }
                    else if (parts.Length == 3)
                    {
                        string name = parts[0];
                        int age = int.Parse(parts[1]);
                        string group = parts[2];

                        people[name] = new Rebel(name, age, group);
                    }
                }

                string inputData;
                while ((inputData = Console.ReadLine()) != null)
                {
                    if (inputData.Equals("End"))
                        break;

                    if (people.ContainsKey(inputData))
                    {
                        people[inputData].BuyFood();
                    }
                }

                int totalFood = 0;
                foreach (var buyer in people.Values)
                {
                    totalFood += buyer.Food;
                }

                Console.WriteLine(totalFood);
                break;
        }
    }
}

