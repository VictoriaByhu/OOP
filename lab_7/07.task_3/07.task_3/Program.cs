using System;
using System.Collections.Generic;
using System.Linq;

interface ISoldier
{
    int Id { get; }
    string FirstName { get; }
    string LastName { get; }
}

interface IPrivate : ISoldier
{
    decimal Salary { get; }
}

interface ILeutenantGeneral : IPrivate
{
    List<IPrivate> Privates { get; }
}

interface ISpecialisedSoldier : IPrivate
{
    string Corps { get; }
}

interface IEngineer : ISpecialisedSoldier
{
    List<Repair> Repairs { get; }
}

interface ICommando : ISpecialisedSoldier
{
    List<Mission> Missions { get; }
}

interface ISpy : ISoldier
{
    int CodeNumber { get; }
}


abstract class Soldier : ISoldier
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    protected Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}

class Private : Soldier, IPrivate
{
    public decimal Salary { get; }

    public Private(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {Salary:F2}";
    }
}

class LeutenantGeneral : Private, ILeutenantGeneral
{
    public List<IPrivate> Privates { get; }

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<IPrivate>();
    }

    public override string ToString()
    {
        string result = base.ToString() + "\nPrivates:";
        foreach (var p in Privates.OrderByDescending(x => x.Salary))
        {
            result += "\n  " + p.ToString();
        }
        return result;
    }
}

abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private static readonly string[] validCorps = { "Airforces", "Marines" };
    public string Corps { get; }

    protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        if (!validCorps.Contains(corps))
            throw new ArgumentException("Invalid corps!");

        Corps = corps;
    }
}

class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; }

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = new List<Repair>();
    }

    public override string ToString()
    {
        string result = base.ToString() + $"\nCorps: {Corps}\nRepairs:";
        foreach (var r in Repairs)
        {
            result += "\n  " + r.ToString();
        }
        return result;
    }
}

class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> Missions { get; }

    public Commando(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = new List<Mission>();
    }

    public override string ToString()
    {
        string result = base.ToString() + $"\nCorps: {Corps}\nMissions:";
        foreach (var m in Missions)
        {
            result += "\n  " + m.ToString();
        }
        return result;
    }
}

class Spy : Soldier, ISpy
{
    public int CodeNumber { get; }

    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCode Number: {CodeNumber}";
    }
}

class Repair
{
    public string PartName { get; }
    public int HoursWorked { get; }

    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}

class Mission
{
    public string CodeName { get; }
    public string State { get; private set; }

    public Mission(string codeName, string state)
    {
        if (state != "inProgress" && state != "Finished")
            throw new ArgumentException("Invalid mission state!");

        CodeName = codeName;
        State = state;
    }

    public void CompleteMission()
    {
        State = "Finished";
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}

class Program
{
    static void Main()
    {
        var soldiers = new Dictionary<int, ISoldier>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var parts = input.Split(' ');
            string type = parts[0];

            try
            {
                switch (type)
                {
                    case "Private":
                        {
                            int id = int.Parse(parts[1]);
                            string first = parts[2];
                            string last = parts[3];
                            decimal salary = decimal.Parse(parts[4]);
                            soldiers[id] = new Private(id, first, last, salary);
                            break;
                        }

                    case "LeutenantGeneral":
                        {
                            int id = int.Parse(parts[1]);
                            string first = parts[2];
                            string last = parts[3];
                            decimal salary = decimal.Parse(parts[4]);
                            var general = new LeutenantGeneral(id, first, last, salary);

                            for (int i = 5; i < parts.Length; i++)
                            {
                                int privateId = int.Parse(parts[i]);
                                if (soldiers.ContainsKey(privateId) && soldiers[privateId] is IPrivate p)
                                    general.Privates.Add(p);
                            }

                            soldiers[id] = general;
                            break;
                        }

                    case "Engineer":
                        {
                            int id = int.Parse(parts[1]);
                            string first = parts[2];
                            string last = parts[3];
                            decimal salary = decimal.Parse(parts[4]);
                            string corps = parts[5];

                            var engineer = new Engineer(id, first, last, salary, corps);

                            for (int i = 6; i < parts.Length - 1; i += 2)
                            {
                                string part = parts[i];
                                int hours = int.Parse(parts[i + 1]);
                                engineer.Repairs.Add(new Repair(part, hours));
                            }

                            soldiers[id] = engineer;
                            break;
                        }

                    case "Commando":
                        {
                            int id = int.Parse(parts[1]);
                            string first = parts[2];
                            string last = parts[3];
                            decimal salary = decimal.Parse(parts[4]);
                            string corps = parts[5];

                            var commando = new Commando(id, first, last, salary, corps);

                            for (int i = 6; i < parts.Length - 1; i += 2)
                            {
                                string codeName = parts[i];
                                string state = parts[i + 1];
                                try
                                {
                                    commando.Missions.Add(new Mission(codeName, state));
                                }
                                catch { continue; } 
                            }

                            soldiers[id] = commando;
                            break;
                        }

                    case "Spy":
                        {
                            int id = int.Parse(parts[1]);
                            string first = parts[2];
                            string last = parts[3];
                            int code = int.Parse(parts[4]);
                            soldiers[id] = new Spy(id, first, last, code);
                            break;
                        }
                }
            }
            catch
            {
                continue;
            }
        }

        foreach (var s in soldiers.Values)
        {
            Console.WriteLine(s);
        }
    }
}
