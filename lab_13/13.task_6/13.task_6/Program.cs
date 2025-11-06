using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split(' ');
            if (parts.Length < 3) continue;

            string firstName = parts[0];
            string lastName = parts[1];
            string phone = parts[2];

            students.Add(new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone
            });
        }

        var sofiaStudents = students
            .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
            .Select(s => s.FirstName + " " + s.LastName);

        foreach (var student in sofiaStudents)
        {
            Console.WriteLine(student);
        }
    }
}
