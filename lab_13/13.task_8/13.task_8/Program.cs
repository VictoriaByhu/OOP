using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Grades { get; set; }
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
            List<int> grades = new List<int>();

            for (int i = 2; i < parts.Length; i++)
            {
                int grade;
                if (int.TryParse(parts[i], out grade))
                    grades.Add(grade);
            }

            students.Add(new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Grades = grades
            });
        }

        var weakStudents = students
            .Where(s => s.Grades.Count(g => g <= 3) >= 2)
            .Select(s => s.FirstName + " " + s.LastName);

        foreach (var student in weakStudents)
        {
            Console.WriteLine(student);
        }
    }
}
