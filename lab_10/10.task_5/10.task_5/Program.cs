using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pet
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Kind { get; private set; }

    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}

public class Clinic
{
    private Pet[] rooms;
    public string Name { get; private set; }

    public Clinic(string name, int roomsCount)
    {
        if (roomsCount % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        this.Name = name;
        this.rooms = new Pet[roomsCount];
    }

    public bool Add(Pet pet)
    {
        int center = this.rooms.Length / 2;
        for (int i = 0; i <= center; i++)
        {
            int leftIndex = center - i;
            int rightIndex = center + i;

            if (leftIndex >= 0 && this.rooms[leftIndex] == null)
            {
                this.rooms[leftIndex] = pet;
                return true;
            }

            if (rightIndex < this.rooms.Length && this.rooms[rightIndex] == null)
            {
                this.rooms[rightIndex] = pet;
                return true;
            }
        }
        return false;
    }

    public bool Release()
    {
        int center = this.rooms.Length / 2;

        for (int i = center; i < this.rooms.Length; i++)
        {
            if (this.rooms[i] != null)
            {
                this.rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < center; i++)
        {
            if (this.rooms[i] != null)
            {
                this.rooms[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        foreach (var r in this.rooms)
        {
            if (r == null)
                return true;
        }
        return false;
    }

    public void Print()
    {
        foreach (var r in this.rooms)
        {
            Console.WriteLine(r == null ? "Room is empty" : r.ToString());
        }
    }

    public void Print(int roomNumber)
    {
        Pet pet = this.rooms[roomNumber - 1];
        Console.WriteLine(pet == null ? "Room is empty" : pet.ToString());
    }
}

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Pet> pets = new Dictionary<string, Pet>();
        Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string command = input[0];

            try
            {
                if (command == "Create")
                {
                    string type = input[1];

                    if (type == "Pet")
                    {
                        string name = input[2];
                        int age = int.Parse(input[3]);
                        string kind = input[4];
                        pets[name] = new Pet(name, age, kind);
                    }
                    else if (type == "Clinic")
                    {
                        string name = input[2];
                        int rooms = int.Parse(input[3]);
                        clinics[name] = new Clinic(name, rooms);
                    }
                }
                else if (command == "Add")
                {
                    string petName = input[1];
                    string clinicName = input[2];
                    bool result = clinics[clinicName].Add(pets[petName]);
                    Console.WriteLine(result);
                }
                else if (command == "Release")
                {
                    string clinicName = input[1];
                    Console.WriteLine(clinics[clinicName].Release());
                }
                else if (command == "HasEmptyRooms")
                {
                    string clinicName = input[1];
                    Console.WriteLine(clinics[clinicName].HasEmptyRooms());
                }
                else if (command == "Print")
                {
                    string clinicName = input[1];
                    if (input.Length == 2)
                    {
                        clinics[clinicName].Print();
                    }
                    else
                    {
                        int room = int.Parse(input[2]);
                        clinics[clinicName].Print(room);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
