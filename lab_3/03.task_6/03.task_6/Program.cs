using System;
using System.Collections.Generic;

class Engine
{
    public string Model;
    public int Power;
    public string Displacement;
    public string Efficiency;

    public Engine(string model, int power, string displacement = "n/a", string efficiency = "n/a")
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }
}

class Car
{
    public string Model;
    public Engine Engine;
    public string Weight;
    public string Color;

    public Car(string model, Engine engine, string weight = "n/a", string color = "n/a")
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("How many engines? ");
        int n = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        
        for (int i = 0; i < n; i++)//filling engines info
        {
            string[] data = Console.ReadLine().Split(' ');
            string model = data[0];
            int power = int.Parse(data[1]);

            string displacement = "n/a";
            string efficiency = "n/a";

            if (data.Length == 3)
            {
                
                if (int.TryParse(data[2], out _))
                    displacement = data[2];
                else
                    efficiency = data[2];
            }
            else if (data.Length == 4)
            {
                displacement = data[2];
                efficiency = data[3];
            }

            engines.Add(new Engine(model, power, displacement, efficiency));
        }


        Console.WriteLine("How many cars? ");
        int m = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        
        for (int i = 0; i < m; i++)//filling cars info
        {
            string[] info = Console.ReadLine().Split(' ');
            string carModel = info[0];
            string engineName = info[1];

            
            Engine carEngine = null;//searching for engine
            foreach (Engine e in engines)
            {
                if (e.Model == engineName)
                {
                    carEngine = e;
                    break;
                }
            }

            string weight = "n/a";
            string color = "n/a";

            if (info.Length == 3)
            {
                
                if (int.TryParse(info[2], out _))
                    weight = info[2];
                else
                    color = info[2];
            }
            else if (info.Length == 4)
            {
                weight = info[2];
                color = info[3];
            }

            cars.Add(new Car(carModel, carEngine, weight, color));
        }

       
        foreach (Car c in cars)
        {
            Console.WriteLine($"{c.Model}:");
            Console.WriteLine($"  {c.Engine.Model}:");
            Console.WriteLine($"    Power: {c.Engine.Power}");
            Console.WriteLine($"    Displacement: {c.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {c.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {c.Weight}");
            Console.WriteLine($"  Color: {c.Color}");
        }
    }
}

