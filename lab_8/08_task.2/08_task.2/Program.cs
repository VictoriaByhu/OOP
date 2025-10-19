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
    public float tankCapacity;

    public Car(float quantity, float consumption, float tankCapacity)
    {
        this.tankCapacity = tankCapacity;

        if (quantity > tankCapacity) { this.fuelQuantity = 0;}
        else { this.fuelQuantity = quantity; }

        this.fuelConsumption = consumption + 0.9f;
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
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        if (fuelQuantity + liters > tankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            return;
        }

        fuelQuantity += liters;
    }
}

class Truck : Auto
{
    public float fuelQuantity;
    public float fuelConsumption;
    public float tankCapacity;

    public Truck(float quantity, float consumption, float tankCapacity)
    {
        this.tankCapacity = tankCapacity;

        if (quantity > tankCapacity) { this.fuelQuantity = 0; }
        else { this.fuelQuantity = quantity; }

        this.fuelConsumption = consumption + 1.6f;
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
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        float realLiters = liters * 0.95f;

        if (fuelQuantity + realLiters > tankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            return;
        }

        fuelQuantity += realLiters;
    }
}
class Bus : Auto
{
    public float fuelQuantity;
    public float fuelConsumption;
    public float tankCapacity = 200;
    public Bus(float quantity, float consumption, float tankCapacity)
    {
        this.tankCapacity = tankCapacity;

        if (quantity > tankCapacity) { this.fuelQuantity = 0; }
        else { this.fuelQuantity = quantity; }

        this.fuelConsumption = consumption;
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

    public void DriveWithPeople(float distance)
    {
        float neededFuel = distance * (fuelConsumption + 1.4f);
        if (fuelQuantity >= neededFuel)
        {
            fuelQuantity -= neededFuel;
            Console.WriteLine($"Bus travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Bus needs refueling");
        }
    }
}

class Program
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine().Split(' ');
        string[] truckInfo = Console.ReadLine().Split(' ');
        string[] busInfo = Console.ReadLine().Split(' ');

        Car car = new Car(
            float.Parse(carInfo[1]),
            float.Parse(carInfo[2]),
            float.Parse(carInfo[3])
        );

        Truck truck = new Truck(
            float.Parse(truckInfo[1]),
            float.Parse(truckInfo[2]),
            float.Parse(truckInfo[3])
        );

        Bus bus = new Bus(
            float.Parse(busInfo[1]), 
            float.Parse(busInfo[2]), 
            float.Parse(busInfo[3])
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
                else if (vehicle == "Bus")
                    bus.DriveWithPeople(value);
            }
            else if (action == "DriveEmpty")
            {
                if (vehicle == "Bus")
                    bus.Drive(value);
            }
            else if (action == "Refuel")
            {
                if (vehicle == "Car")
                    car.Refuel(value);
                else if (vehicle == "Truck")
                    truck.Refuel(value);
                else if (vehicle == "Bus")
                    bus.Refuel(value);
            }
        }

        Console.WriteLine($"Car: {car.fuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.fuelQuantity:F2}");
        Console.WriteLine($"Bus: {bus.fuelQuantity:F2}");
    }
}
