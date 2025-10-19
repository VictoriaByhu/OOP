using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Food
{
    public int Quantity {  get; set; }
    protected Food(int quantity)
    {
        Quantity = quantity;
    }
}

class Vegetable : Food
{
    public Vegetable(int quantity) : base(quantity) { }
}
class Fruit : Food 
{ 
    public Fruit(int quantity) : base(quantity) { } 
}
class Meat : Food 
{ 
    public Meat(int quantity) : base(quantity) { } 
}
class Seeds : Food 
{ 
    public Seeds(int quantity) : base(quantity) { } 
}

abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; protected set; }

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public abstract void MakeSound();
    public abstract void Eat(Food food);
}

abstract class Bird : Animal
{
    public double WingSize { get; set; }

    protected Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight:F2}, {FoodEaten}]";
    }
}

abstract class Mammal : Animal
{
    public string LivingRegion { get; set; }

    protected Mammal(string name, double weight, string livingRegion)
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }
}

abstract class Feline : Mammal
{
    public string Breed { get; set; }

    protected Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Breed}, {Weight:F2}, {LivingRegion}, {FoodEaten}]";
    }
}

class Owl : Bird
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize) { }

    public override void MakeSound() => Console.WriteLine("Hoot Hoot");

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += food.Quantity * 0.25;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Hen : Bird
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize) { }

    public override void MakeSound() => Console.WriteLine("Cluck");

    public override void Eat(Food food)
    {
        Weight += food.Quantity * 0.35;
        FoodEaten += food.Quantity;
    }
}

class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion) { }

    public override void MakeSound() => Console.WriteLine("Squeak");

    public override void Eat(Food food)
    {
        if (food is Vegetable || food is Fruit)
        {
            Weight += food.Quantity * 0.10;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Weight:F2}, {LivingRegion}, {FoodEaten}]";
    }
}

class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion) { }

    public override void MakeSound() => Console.WriteLine("Woof!");

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += food.Quantity * 0.40;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Weight:F2}, {LivingRegion}, {FoodEaten}]";
    }
}

class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    public override void MakeSound() => Console.WriteLine("Meow");

    public override void Eat(Food food)
    {
        if (food is Meat || food is Vegetable)
        {
            Weight += food.Quantity * 0.30;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    public override void MakeSound() => Console.WriteLine("ROAR!!!");

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += food.Quantity * 1.00;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Program
{
    static void Main()
    {
        var animals = new List<Animal>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End") break;

            string[] animalData = input.Split(' ');
            string[] foodData = Console.ReadLine().Split(' ');

            string animalType = animalData[0];
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);

            Animal animal = null;

            switch (animalType)
            {
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(animalData[3]));
                    break;
                case "Hen":
                    animal = new Hen(name, weight, double.Parse(animalData[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, animalData[3]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, animalData[3]);
                    break;
                case "Cat":
                    animal = new Cat(name, weight, animalData[3], animalData[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, animalData[3], animalData[4]);
                    break;
            }

            Food food = null;

            switch (foodData[0])
            {
                case "Vegetable":
                    food = new Vegetable(int.Parse(foodData[1]));
                    break;
                case "Fruit":
                    food = new Fruit(int.Parse(foodData[1]));
                    break;
                case "Meat":
                    food = new Meat(int.Parse(foodData[1]));
                    break;
                case "Seeds":
                    food = new Seeds(int.Parse(foodData[1]));
                    break;
            }

            animal.MakeSound();
            animal.Eat(food);
            animals.Add(animal);
        }

        foreach (var a in animals)
            Console.WriteLine(a);
    }
}