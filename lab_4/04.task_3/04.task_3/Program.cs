using System;
using System.Collections.Generic;
using System.Linq;

abstract class HospitalUnit
{
    protected readonly List<Patient> patients = new List<Patient>();

    public List<Patient> Patients
    {
        get { return patients; }
    }

    public abstract bool AddPatient(Patient p);
}

class Patient
{
    public string Name {get;}

    public Patient(string name)
    {
        Name = name;
    }
}

class Room : HospitalUnit
{
    public int Number {get;}

    public Room(int number)
    {
        Number = number;
    }

    public override bool AddPatient(Patient p)
    {
        if (patients.Count < 3)
        {
            patients.Add(p);
            return true;
        }
        return false;
    }
}

class Department : HospitalUnit
{
    public string Name {get;}
    public List<Room> Rooms {get;}
    public List<Patient> arrivalOrder = new List<Patient>();

    public Department(string name)
    {
        Name = name;
        Rooms = new List<Room>();
        for (int i = 1; i <= 20; i++)
        {
            Rooms.Add(new Room(i));
        }
    }

    public List<Patient> ArrivalOrder
    {
        get { return arrivalOrder; }
    }

    public override bool AddPatient(Patient p)
    {
        foreach (Room r in Rooms)
        {
            if (r.AddPatient(p))
            {
                patients.Add(p);
                arrivalOrder.Add(p);
                return true;
            }
        }
        return false;
    }
}

class Doctor : HospitalUnit
{
    public string FullName { get; private set; }

    public Doctor(string fullName)
    {
        FullName = fullName;
    }

    public override bool AddPatient(Patient p)
    {
        patients.Add(p);
        return true;
    }
}

class Program
{
    static void Main()
    {
        List<Department> departments = new List<Department>();
        List<Doctor> doctors = new List<Doctor>();

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "Output") break;

            string[] parts = line.Split(' ');
            string depName = parts[0];
            string doctorName = parts[1] + " " + parts[2];
            string patientName = parts[3];

            Department dep = departments.FirstOrDefault(d => d.Name == depName);
            if (dep == null)
            {
                dep = new Department(depName);
                departments.Add(dep);
            }

            Doctor doc = doctors.FirstOrDefault(d => d.FullName == doctorName);
            if (doc == null)
            {
                doc = new Doctor(doctorName);
                doctors.Add(doc);
            }

            Patient patient = new Patient(patientName);
            if (dep.AddPatient(patient))
            {
                doc.AddPatient(patient);
            }
        }

        while (true)
        {
            string cmd = Console.ReadLine();
            if (cmd == "End") break;

            string[] c = cmd.Split(' ');

            if (c.Length == 1)
            {
                Department d = departments.FirstOrDefault(x => x.Name == c[0]);
                if (d != null)
                {
                    foreach (Patient p in d.ArrivalOrder)
                        Console.WriteLine(p.Name);
                }
            }
            else if (c.Length == 2 && int.TryParse(c[1], out int roomNum))
            {
                Department d = departments.FirstOrDefault(x => x.Name == c[0]);
                if (d != null && roomNum >= 1 && roomNum <= 20)
                {
                    Room r = d.Rooms[roomNum - 1];
                    foreach (Patient p in r.Patients.OrderBy(p => p.Name))
                        Console.WriteLine(p.Name);
                }
            }
            else
            {
                string doctorName = c[0] + " " + c[1];
                Doctor doc = doctors.FirstOrDefault(x => x.FullName == doctorName);
                if (doc != null)
                {
                    foreach (Patient p in doc.Patients.OrderBy(p => p.Name))
                        Console.WriteLine(p.Name);
                }
            }
        }
    }
}
