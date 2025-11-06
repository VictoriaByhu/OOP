using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_GmailFilter
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Trim().ToUpper() == "END")
                    break;

                string[] parts = input.Split(' ');
                if (parts.Length != 3)
                {
                    continue;
                }

                students.Add(new Student
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    Email = parts[2]
                });
            }

            var gmailStudents = from s in students
                                where s.Email.Contains("@gmail.com")
                                select s;

            foreach (var s in gmailStudents)
            {
                Console.WriteLine($"{s.FirstName} {s.LastName}");
            }

            Console.ReadLine();
        }
    }
}
