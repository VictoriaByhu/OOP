using System;
using System.Collections.Generic;
using System.Linq;

class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }

    public StudentSpecialty(string specialtyName, string facultyNumber)
    {
        SpecialtyName = specialtyName;
        FacultyNumber = facultyNumber;
    }
}

class Student
{
    public string Name { get; set; }
    public string FacultyNumber { get; set; }

    public Student(string name, string facultyNumber)
    {
        Name = name;
        FacultyNumber = facultyNumber;
    }
}

class Program
{
    static void Main()
    {
        List<StudentSpecialty> specialties = new List<StudentSpecialty>();
        List<Student> students = new List<Student>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Students:") break;

            string[] parts = input.Split(' ');
            string specialtyName = parts[0] + " " + parts[1];
            string facultyNumber = parts[2];

            specialties.Add(new StudentSpecialty(specialtyName, facultyNumber));
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split(' ');
            string facultyNumber = parts[0];
            string fullName = parts[1] + " " + parts[2];

            students.Add(new Student(fullName, facultyNumber));
        }

        var result = from s in students
                     join sp in specialties on s.FacultyNumber equals sp.FacultyNumber
                     orderby s.Name
                     select new
                     {
                         Name = s.Name,
                         FacultyNumber = s.FacultyNumber,
                         SpecialtyName = sp.SpecialtyName
                     };

        foreach (var r in result)
        {
            Console.WriteLine("{0} {1} {2}", r.Name, r.FacultyNumber, r.SpecialtyName);
        }
    }
}
