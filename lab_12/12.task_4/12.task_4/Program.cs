using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    public delegate void KingUnderAttackEventHandler();
    public class King
    {
        public string Name { get; private set; }

        public event KingUnderAttackEventHandler UnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public void OnAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            UnderAttack?.Invoke();
        }
    }

    public abstract class Soldier
    {
        public string Name { get; private set; }

        protected Soldier(string name)
        {
            this.Name = name;
        }

        public abstract void RespondToAttack();
    }

    public class RoyalGuard : Soldier
    {
        public int health { get; set; }
        public RoyalGuard(string name) : base(name)
        {
            health = 3;
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }

    public class Footman : Soldier
    {
        public int health { get; set; }
        public Footman(string name) : base(name)
        {
            health = 2;
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }

    class Program
    {
        static void Main()
        {
            string kingName = Console.ReadLine();
            string[] guardNames = Console.ReadLine().Split(' ');
            string[] footmanNames = Console.ReadLine().Split(' ');

            if (!IsValidName(kingName) ||
            guardNames.Any(n => !IsValidName(n)) ||
            footmanNames.Any(n => !IsValidName(n)))
            {
                Console.WriteLine("Invalid name format!");
                return;
            }

            King king = new King(kingName);

            List<RoyalGuard> royalGuards = new List<RoyalGuard>();
            List<Footman> footmen = new List<Footman>();

            foreach (var name in guardNames)
            {
                RoyalGuard guard = new RoyalGuard(name);
                royalGuards.Add(guard);
                king.UnderAttack += guard.RespondToAttack;
            }

            foreach (var name in footmanNames)
            {
                Footman footman = new Footman(name);
                footmen.Add(footman);
                king.UnderAttack += footman.RespondToAttack;
            }

            int commandCount = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                commandCount++;
                if (commandCount > 100)
                {
                    Console.WriteLine("Command limit reached");
                    break;
                }
                if (command == "Attack King")
                {
                    king.OnAttack();
                }
                else if (command.StartsWith("Kill "))
                {
                    string nameToKill = command.Split()[1];


                    RoyalGuard guardToRemove = royalGuards.FirstOrDefault(g => g.Name == nameToKill);
                    if (guardToRemove != null)
                    {
                        if (guardToRemove.health > 0)
                        {
                            guardToRemove.health -= 1;
                            if (guardToRemove.health == 0)
                            {
                                king.UnderAttack -= guardToRemove.RespondToAttack;
                                royalGuards.Remove(guardToRemove);
                                continue;
                            }
                        }
                        
                    }


                    Footman footmanToRemove = footmen.FirstOrDefault(f => f.Name == nameToKill);
                    if (footmanToRemove != null)
                    {
                        if (footmanToRemove.health > 0)
                        {
                            footmanToRemove.health -= 1;
                            if (footmanToRemove.health == 0)
                            {
                                king.UnderAttack -= footmanToRemove.RespondToAttack;
                                footmen.Remove(footmanToRemove);
                            }
                        }
                    }
                }
            }
        }

        private static bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
    }

}
