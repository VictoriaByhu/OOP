using System;
using System.Collections.Generic;

class Program
{
    abstract class BagItem
    {
        public string Name { get; protected set; }
        public int Quantity { get; set; }
        public abstract string Type { get; }

        protected BagItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }

    class GoldItem : BagItem
    {
        public override string Type { get { return "Gold"; } }

        public GoldItem(string name, int quantity) : base(name, quantity) { }
    }

    class GemItem : BagItem
    {
        public override string Type { get { return "Gem"; } }

        public GemItem(string name, int quantity) : base(name, quantity) { }
    }

    class CashItem : BagItem
    {
        public override string Type { get { return "Cash"; } }

        public CashItem(string name, int quantity) : base(name, quantity) { }
    }

    static BagItem CreateItem(string name, int quantity)
    {
        if (name.Length == 3)
            return new CashItem(name, quantity);
        if (name.ToLower().EndsWith("gem") && name.Length >= 4)
            return new GemItem(name, quantity);
        if (name.ToLower() == "gold")
            return new GoldItem(name, quantity);

        return null;
    }

    static void Main()
    {
        Console.WriteLine("Enter sack capacity: ");
        int capacity = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');

        List<BagItem> items = new List<BagItem>();
        int totalGold = 0, totalGem = 0, totalCash = 0, totalSum = 0;

        for (int i = 0; i < input.Length; i += 2)
        {
            string name = input[i];
            int quantity = int.Parse(input[i + 1]);

            BagItem item = CreateItem(name, quantity);
            if (item == null) continue;
            if (totalSum + quantity > capacity) continue;
            if (item.Type == "Gem" && totalGem + quantity > totalGold) continue;
            if (item.Type == "Cash" && totalCash + quantity > totalGem) continue;

            bool found = false;
            foreach (var existing in items)
            {
                if (existing.Name == name && existing.Type == item.Type)
                {
                    existing.Quantity += quantity;
                    found = true;
                    break;
                }
            }

            if (!found)
                items.Add(item);

            totalSum += quantity;
            if (item.Type == "Gold") totalGold += quantity;
            else if (item.Type == "Gem") totalGem += quantity;
            else if (item.Type == "Cash") totalCash += quantity;
        }

        string[] types = { "Gold", "Gem", "Cash" };
        foreach (string type in types)
        {
            int sum = 0;
            foreach (var item in items)
            {
                if (item.Type == type)
                    sum += item.Quantity;
            }

            if (sum > 0)
            {
                Console.WriteLine($"<{type}> ${sum}");

                foreach (var item in items)
                {
                    if (item.Type == type)
                        Console.WriteLine($"##{item.Name} - {item.Quantity}");
                }
            }
        }
    }
}
