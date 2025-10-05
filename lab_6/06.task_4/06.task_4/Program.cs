using System;

abstract class Food
{
    public abstract int Happiness { get; }
}

class Bread : Food { public override int Happiness => 2; }
class Lembas : Food { public override int Happiness => 3; }
class Apple : Food { public override int Happiness => 1; }
class Melon : Food { public override int Happiness => 1; }
class HoneyCake : Food { public override int Happiness => 5; }
class Mushrooms : Food { public override int Happiness => -10; }
class OtherFood : Food { public override int Happiness => -1; }

class FoodFactory
{
    public Food CreateFood(string name)
    {
        name = name.ToLower();
        if (name == "drybread") return new Bread();
        if (name == "lembas") return new Lembas();
        if (name == "apple") return new Apple();
        if (name == "melon") return new Melon();
        if (name == "honeyCake") return new HoneyCake();
        if (name == "mushrooms") return new Mushrooms();
        return new OtherFood();
    }
}

abstract class Mood
{
    public abstract string Name { get; }
}

class Angry : Mood { public override string Name => "Angry"; }
class Sad : Mood { public override string Name => "Sad"; }
class Happy : Mood { public override string Name => "Happy"; }
class Bliss : Mood { public override string Name => "Bliss"; }


class MoodFactory
{
    public Mood GetMood(int happiness)
    {
        if (happiness < -5) return new Angry();
        if (happiness <= 0) return new Sad();
        if (happiness <= 15) return new Happy();
        return new Bliss();
    }
}

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (input.Length > 1000)
        {
            Console.WriteLine("Error: string is too long (max 1000 characters).");
            return;
        }

        string[] foods = input.Split(' ');

        if (foods.Length < 1 || foods.Length > 100)
        {
            Console.WriteLine("Error: The amount of food should be between 1 and 100.");
            return;
        }

        FoodFactory foodFactory = new FoodFactory();
        MoodFactory moodFactory = new MoodFactory();

        int totalHappiness = 0;

        foreach (var foodName in foods)
        {
            Food food = foodFactory.CreateFood(foodName);
            totalHappiness += food.Happiness;
        }

        Mood mood = moodFactory.GetMood(totalHappiness);

        Console.WriteLine(totalHappiness);
        Console.WriteLine(mood.Name);
    }
}
