using System;
using System.Collections.Generic;
using System.Linq;

class CompanyOrder
{
    public string Company { get; set; }
    public string Product { get; set; }
    public int Amount { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<CompanyOrder> orders = new List<CompanyOrder>();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine().Trim('|', ' ');

            string[] parts = line.Split(new[] { " - " }, StringSplitOptions.None);
            string company = parts[0];
            int amount = int.Parse(parts[1]);
            string product = parts[2];

            orders.Add(new CompanyOrder
            {
                Company = company,
                Product = product,
                Amount = amount
            });
        }

   
        var grouped = orders
            .GroupBy(o => o.Company)
            .OrderBy(g => g.Key);

        foreach (var companyGroup in grouped)
        {
            var products = companyGroup
                .GroupBy(o => o.Product)
                .Select(g => new
                {
                    Product = g.Key,
                    Total = g.Sum(x => x.Amount),
                    FirstIndex = orders.FindIndex(o => o.Company == companyGroup.Key && o.Product == g.Key)
                })
                .OrderBy(p => p.FirstIndex);

            Console.Write(companyGroup.Key + ": ");
            Console.WriteLine(string.Join(", ", products.Select(p => $"{p.Product}-{p.Total}")));
        }
    }
}
