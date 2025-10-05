using System;

interface IPriceCalculator
{
    decimal CalculatePrice();
}

abstract class PriceCalculatorBase : IPriceCalculator
{
    protected decimal pricePerDay;
    protected int numberOfDays;
    protected Season season;
    protected Discount discount;

    protected PriceCalculatorBase(decimal pricePerDay, int numberOfDays,
                                  Season season, Discount discount)
    {
        this.pricePerDay = pricePerDay;
        this.numberOfDays = numberOfDays;
        this.season = season;
        this.discount = discount;
    }

    public abstract decimal CalculatePrice();
}

enum Season
{
    Spring,
    Summer,
    Fall,
    Winter
}

enum Discount
{
    None,
    VIP,
    SecondVisit
}

class StandardPriceCalculator : PriceCalculatorBase
{
    public StandardPriceCalculator(decimal pricePerDay, int numberOfDays,
                                   Season season, Discount discount)
        : base(pricePerDay, numberOfDays, season, discount) { }

    public override decimal CalculatePrice()
    {
        int seasonMultiplier = 1;
        switch (season)
        {
            case Season.Spring: seasonMultiplier = 2; break;
            case Season.Summer: seasonMultiplier = 4; break;
            case Season.Fall: seasonMultiplier = 1; break;
            case Season.Winter: seasonMultiplier = 3; break;
        }

        decimal total = pricePerDay * numberOfDays * seasonMultiplier;

        if (discount == Discount.VIP) total *= 0.80m;//20% discount
        else if (discount == Discount.SecondVisit) total *= 0.90m;//10% discount

        return total;
    }
}

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        decimal pricePerDay = decimal.Parse(input[0]);
        int days = int.Parse(input[1]);
        Season season = (Season)Enum.Parse(typeof(Season), input[2]);

        Discount discount = Discount.None;
        if (input.Length > 3)
            Enum.TryParse(input[3], out discount);

        IPriceCalculator calculator =
            new StandardPriceCalculator(pricePerDay, days, season, discount);

        Console.WriteLine($"{calculator.CalculatePrice():F2}");
    }
}
