using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    class Person
    {
        public string Name { get; private set; }
        public float Money { get; private set; }
        private List<Product> bag;

        public Person(string name, float money)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains(" "))
            {
                Console.WriteLine("Name cannot be empty.");
                Environment.Exit(0);
            }
            if (money < 0)
            {
                Console.WriteLine("Money cannot be negative.");
                Environment.Exit(0);
            }
            Name = name;
            Money = money;
            bag = new List<Product>();
        }
        
        public void Buy(Product product)
        {
            if (Money >= product.Price)
            {
                Money -= product.Price;
                bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public void PrintBag()
        {
            if (bag.Count == 0)
            {
                Console.WriteLine($"{Name} - Nothing bought.");
            }
            else
            {
                Console.WriteLine($"{Name} -");
                for (int i = 0; i < bag.Count; i++)
                {
                    Console.WriteLine($"{bag[i].Name} ");
                }
                Console.WriteLine();
            }
        }

    }

    class Product
    {
        public string Name { get; private set; }
        public float Price { get; private set; }

        public Product(string name, float price)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains(" "))
            {
                Console.WriteLine("Name cannot be empty.");
                Environment.Exit(0);
            }
            if (price < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                Environment.Exit(0);
            }
            Name = name;
            Price = price;
        }
    }

    static void Main()
    {
        string[] peopleInput = Console.ReadLine().Split(';');
        List<Person> people = new List<Person>();
        foreach (var p in peopleInput)
        {
            var parts = p.Split();
            people.Add(new Person(parts[0], float.Parse(parts[1])));
        }

        string[] productsInput = Console.ReadLine().Split(';');
        List<Product> products = new List<Product>();
        foreach (var p in productsInput)
        {
            var parts = p.Split();
            products.Add(new Product(parts[0], float.Parse(parts[1])));
        }

        while (true)
        {
            string cmd = Console.ReadLine();
            if (cmd == "end") break;

            var parts = cmd.Split();
            var buyer = people.Find(x => x.Name == parts[0]);
            var product = products.Find(x => x.Name == parts[1]);

            if (buyer != null && product != null)
                buyer.Buy(product);
        }


        foreach (var person in people)
            person.PrintBag();
    }
}
