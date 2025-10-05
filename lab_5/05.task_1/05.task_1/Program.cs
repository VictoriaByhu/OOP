using System;

class Program
{
    class Chicken
    {
        private string name;
        private int age;

        private const int minAge = 0;
        private const int maxAge = 15;

        public Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                if (value.Contains(" "))
                {
                    throw new ArgumentException("Name cannot contain spaces.");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < minAge || value > maxAge)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                age = value;
            }
        }

        private int CalculateProductPerDay()
        {
            if (age < 3)
                return 1;
            else if (age <= 7)
                return 2;
            else
                return 3;
        }

        public int ProductPerDay
        {
            get { return CalculateProductPerDay(); }
        }
    }

    static void Main()
    {
        try
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
