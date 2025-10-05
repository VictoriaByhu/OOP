using System;
using System.Collections.Generic;

class Program
{
    class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if (value != "White" && value != "Wholegrain")
                    throw new ArgumentException("Invalid type of dough");
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value != "Crispy" && value != "Chewy" && value != "Homemade")
                    throw new ArgumentException("Invalid type of dough");
                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in range [1..200]");
                weight = value;
            }
        }

        private double GetFlourModifier()
        {
            if (flourType == "White") return 1.5;
            return 1.0;
        }

        private double GetTechniqueModifier()
        {
            if (bakingTechnique == "Crispy") return 0.9;
            if (bakingTechnique == "Chewy") return 1.1;
            return 1.0;
        }

        public double TotalCalories => 2 * GetFlourModifier() * GetTechniqueModifier() * weight;
    }

    class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
                    throw new ArgumentException($"Cannot place {value} on top of your pizza");
                type = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{type} weight should be in range [1..50]");
                weight = value;
            }
        }

        private double GetTypeModifier()
        {
            if (type == "Meat") return 1.2;
            if (type == "Veggies") return 0.8;
            if (type == "Cheese") return 1.1;
            return 0.9;
        }

        public double TotalCalories => 2 * GetTypeModifier() * weight;
    }

    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings = new List<Topping>();

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 characters");
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Dough cannot be null");
                dough = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
                throw new ArgumentException("Number of toppings should be in range [0..10]");
            toppings.Add(topping);
        }

        public double TotalCalories
        {
            get
            {
                double sum = dough.TotalCalories;
                foreach (var t in toppings)
                    sum += t.TotalCalories;
                return sum;
            }
        }
    }

    static void Main()
    {
        try
        {
            string pizzaName = Console.ReadLine();

            string[] doughParts = Console.ReadLine().Split();
            Dough dough = new Dough(doughParts[0], doughParts[1], double.Parse(doughParts[2]));

            Pizza pizza = new Pizza(pizzaName, dough);

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END") break;

                string[] parts = line.Split();
                Topping topping = new Topping(parts[0], double.Parse(parts[1]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
