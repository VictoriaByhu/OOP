using System;
using System.Collections.Generic;



class Program
{
    class Employee
    {
        public string Name {get; set; }//auto properties
        public double Salary {get; set;}
        public string Position {get; set;}
        public string Department {get; set;}
        public string Email {get; set;}
        public int Age {get; set;}

        public Employee(string name, double salary, string position, string department)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;

           
            Email = "Unknown";
            Age = 0;
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            
            string[] parts = Console.ReadLine().Split(' ');//filling the info

            string name = parts[0];
            double salary = double.Parse(parts[1]);
            string position = parts[2];
            string department = parts[3];

            Employee emp = new Employee(name, salary, position, department);

            
            if (parts.Length == 5)
            {
               
                if (int.TryParse(parts[4], out int age))
                    emp.Age = age;
                else
                    emp.Email = parts[4];
            }
            else if (parts.Length == 6)
            {
                emp.Email = parts[4];
                emp.Age = int.Parse(parts[5]);
            }

            employees.Add(emp);
        }


        string bestDept = "";
        double bestAvg = 0;
        List<Employee> bestEmployees = null;

        foreach (Employee e in employees)//choosing the best dep
        {
            double sum = 0;
            int count = 0;

            foreach (Employee x in employees)
            {
                if (x.Department == e.Department)
                {
                    sum += x.Salary;
                    count++;
                }
            }

            double avg = sum / count;

            if (avg > bestAvg)
            {
                bestAvg = avg;
                bestDept = e.Department;

                
                bestEmployees = new List<Employee>();
                foreach (Employee x in employees)
                    if (x.Department == e.Department)
                        bestEmployees.Add(x);
            }
        }

        
        bestEmployees.Sort((a, b) => b.Salary.CompareTo(a.Salary));//lam

        Console.WriteLine("Highest Average Salary: " + bestDept);

        foreach (Employee e in bestEmployees)
        {
            Console.WriteLine($"{e.Name} {e.Salary:F2} {e.Email} {e.Age}");
        }
    }
}
