using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_SortStudents
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
                if (parts.Length != 2)
                {
                    continue;
                }

                students.Add(new Student
                {
                    FirstName = parts[0],
                    LastName = parts[1]
                });
            }

            IEnumerable<Student> sortedStudents = students
                .OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FirstName);

            foreach (Student s in sortedStudents)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName);
            }

            Console.ReadLine();
        }
    }
}
