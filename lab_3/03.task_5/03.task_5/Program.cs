using System;
using System.Collections.Generic;

class Car
{
    public string Model;
    public double Fuel;
    public double Consumption;
    public double Distance;

    public Car(string model, double fuel, double consumption)
    {
        Model = model;
        Fuel = fuel;
        Consumption = consumption;
        Distance = 0;
    }

    public void Drive(double km)
    {
        double needed = km * Consumption;
        if (Fuel >= needed)
        {
            Fuel -= needed;
            Distance += km;
        }
        else
        {
            Console.WriteLine("Not enough fuel to move.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("How many cars? ");
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        Console.WriteLine("Enter the info:\n");
        for (int i = 0; i < n; i++)
        {
            string[] info = Console.ReadLine().Split();
            string model = info[0];
            double fuel = double.Parse(info[1]);
            double cons = double.Parse(info[2]);

            cars.Add(new Car(model, fuel, cons));
        }

        while (true)//driving loop
        {
            string line = Console.ReadLine();
            if (line == "End") break;

            string[] cmd = line.Split();
            string model = cmd[1];
            double km = double.Parse(cmd[2]);

            foreach (Car c in cars)
            {
                if (c.Model == model)
                {
                    c.Drive(km);
                    break;
                }
            }
        }

        
        foreach (Car c in cars)
        {
            Console.WriteLine($"{c.Model} {c.Fuel:F2} {c.Distance}");
        }
    }
}
