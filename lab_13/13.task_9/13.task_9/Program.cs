using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FacultyNumber { get; set; }
    public List<int> Grades { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        string input;

        // Зчитування даних до "END"
        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split(' ');
            if (parts.Length < 2) continue;

            string facultyNumber = parts[0];
            List<int> grades = new List<int>();

            for (int i = 1; i < parts.Length; i++)
            {
                int grade;
                if (int.TryParse(parts[i], out grade))
                    grades.Add(grade);
            }

            students.Add(new Student
            {
                FacultyNumber = facultyNumber,
                Grades = grades
            });
        }

        var selectedStudents = students
            .Where(s => s.FacultyNumber.Length >= 6 &&
                        (s.FacultyNumber.Substring(4, 2) == "14" ||
                         s.FacultyNumber.Substring(4, 2) == "15"))
            .Select(s => s.Grades);

        foreach (var grades in selectedStudents)
        {
            Console.WriteLine(string.Join(" ", grades));
        }
    }
}
