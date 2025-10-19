using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Auto
{
    

    public virtual void Drive(float distance) { }
    public virtual void Refuel(float liters) { }
}

class Car : Auto
{
    public float fuelQuantity;
    public float fuelConsumption;
    public float tankCapacity = 150;

    public Car(float quantity, float consumption)
    {
        this.fuelQuantity = quantity;
        this.fuelConsumption = consumption + 0.9f;
    }

    public float FuelQuantity
    {
        get { return fuelQuantity; } 
        set {  fuelQuantity = value; }
    }


    public override void Drive(float distance)
    {
        float neededFuel = distance * fuelConsumption;
        if (fuelQuantity >= neededFuel)
        {
            fuelQuantity -= neededFuel;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Car needs refueling");
        }
    }

    public override void Refuel(float liters)
    {
        if (liters <= 0)
        {
            return;
        }

        if (fuelQuantity + liters > tankCapacity)
        {
            return;
        }

        fuelQuantity += liters;
    }
}

class Truck : Auto
{
    public float fuelQuantity;
    public float fuelConsumption;
    public float tankCapacity = 200;

    public Truck(float quantity, float consumption)
    {
        this.fuelQuantity = quantity;
        this.fuelConsumption = consumption + 1.6f;
    }

    public float FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }



    public override void Drive(float distance)
    {
        float neededFuel = distance * fuelConsumption;
        if (fuelQuantity >= neededFuel)
        {
            fuelQuantity -= neededFuel;
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public override void Refuel(float liters)
    {
        if (liters <= 0)
        {
            return;
        }

        float realLiters = liters * 0.95f;

        if (fuelQuantity + realLiters > tankCapacity)
        {
            return;
        }

        fuelQuantity += realLiters;
    }
}

class Program
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine().Split(' ');
        string[] truckInfo = Console.ReadLine().Split(' ');

        Car car = new Car(
            float.Parse(carInfo[1]),
            float.Parse(carInfo[2])
        );

        Truck truck = new Truck(
            float.Parse(truckInfo[1]),
            float.Parse(truckInfo[2])
        );

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split(' ');

            string action = command[0];
            string vehicle = command[1];
            float value = float.Parse(command[2]);

            if (action == "Drive")
            {
                if (vehicle == "Car")
                    car.Drive(value);
                else if (vehicle == "Truck")
                    truck.Drive(value);
            }
            else if (action == "Refuel")
            {
                if (vehicle == "Car")
                    car.Refuel(value);
                else if (vehicle == "Truck")
                    truck.Refuel(value);
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }
}