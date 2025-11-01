using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_InfernoInfinity
{
    public enum WeaponType
    {
        Axe,    // 5-10 damage, 4 sockets
        Sword,  // 4-6 damage, 3 sockets
        Knife   // 3-4 damage, 2 sockets
    }

    public enum Rarity
    {
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 5
    }

    public enum Purity
    {
        Chipped = 1,
        Regular = 2,
        Perfect = 5,
        Flawless = 10
    }

    public abstract class Gem
    {
        public int Strength { get; protected set; }
        public int Agility { get; protected set; }
        public int Vitality { get; protected set; }

        protected Gem(Purity purity)
        {
            int bonus = (int)purity;
            Strength += bonus;
            Agility += bonus;
            Vitality += bonus;
        }
    }

    public class Ruby : Gem
    {
        public Ruby(Purity purity) : base(purity)
        {
            Strength += 7;
            Agility += 2;
            Vitality += 5;
        }
    }

    public class Emerald : Gem
    {
        public Emerald(Purity purity) : base(purity)
        {
            Strength += 1;
            Agility += 4;
            Vitality += 9;
        }
    }

    public class Amethyst : Gem
    {
        public Amethyst(Purity purity) : base(purity)
        {
            Strength += 2;
            Agility += 8;
            Vitality += 4;
        }
    }

    public class Weapon
    {
        public string Name { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public int SocketCount { get; private set; }
        private Gem[] sockets;

        public Weapon(string name, WeaponType type, Rarity rarity)
        {
            Name = name;

            switch (type)
            {
                case WeaponType.Axe:
                    MinDamage = 5;
                    MaxDamage = 10;
                    SocketCount = 4;
                    break;
                case WeaponType.Sword:
                    MinDamage = 4;
                    MaxDamage = 6;
                    SocketCount = 3;
                    break;
                case WeaponType.Knife:
                    MinDamage = 3;
                    MaxDamage = 4;
                    SocketCount = 2;
                    break;
            }

            int multiplier = (int)rarity;
            MinDamage *= multiplier;
            MaxDamage *= multiplier;

            sockets = new Gem[SocketCount];
        }

        public void AddGem(int index, Gem gem)
        {
            if (index >= 0 && index < SocketCount)
            {
                sockets[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < SocketCount)
            {
                sockets[index] = null;
            }
        }

        public override string ToString()
        {
            int totalStrength = 0;
            int totalAgility = 0;
            int totalVitality = 0;

            foreach (var g in sockets)
            {
                if (g != null)
                {
                    totalStrength += g.Strength;
                    totalAgility += g.Agility;
                    totalVitality += g.Vitality;
                }
            }

            int totalMin = MinDamage + totalStrength * 2 + totalAgility * 1;
            int totalMax = MaxDamage + totalStrength * 3 + totalAgility * 4;

            return string.Format("{0}: {1}-{2} Damage, +{3} Strength, +{4} Agility, +{5} Vitality",
                Name, totalMin, totalMax, totalStrength, totalAgility, totalVitality);
        }
    }

    class Program
    {
        static void Main()
        {
            List<Weapon> weapons = new List<Weapon>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split(';');
                string command = parts[0];

                if (command == "Create")
                {
                    string[] rarityType = parts[1].Split(' ');
                    Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), rarityType[0]);
                    WeaponType type = (WeaponType)Enum.Parse(typeof(WeaponType), rarityType[1]);
                    string name = parts[2];

                    Weapon weapon = new Weapon(name, type, rarity);
                    weapons.Add(weapon);
                }
                else if (command == "Add")
                {
                    string name = parts[1];
                    int index = int.Parse(parts[2]);
                    string[] gemParts = parts[3].Split(' ');
                    Purity purity = (Purity)Enum.Parse(typeof(Purity), gemParts[0]);
                    string gemType = gemParts[1];

                    Weapon weapon = null;
                    foreach (var w in weapons)
                    {
                        if (w.Name == name)
                        {
                            weapon = w;
                            break;
                        }
                    }

                    if (weapon != null)
                    {
                        Gem gem = null;
                        if (gemType == "Ruby")
                            gem = new Ruby(purity);
                        else if (gemType == "Emerald")
                            gem = new Emerald(purity);
                        else if (gemType == "Amethyst")
                            gem = new Amethyst(purity);

                        if (gem != null)
                            weapon.AddGem(index, gem);
                    }
                }
                else if (command == "Remove")
                {
                    string name = parts[1];
                    int index = int.Parse(parts[2]);

                    Weapon weapon = null;
                    foreach (var w in weapons)
                    {
                        if (w.Name == name)
                        {
                            weapon = w;
                            break;
                        }
                    }

                    if (weapon != null)
                        weapon.RemoveGem(index);
                }
                else if (command == "Print")
                {
                    string name = parts[1];

                    foreach (var w in weapons)
                    {
                        if (w.Name == name)
                        {
                            Console.WriteLine(w.ToString());
                            break;
                        }
                    }
                }
            }
        }
    }
}
