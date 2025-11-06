using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_StudentsByNameOrder
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupNumber { get; set; }
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


                students.Add(new Student
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                });
            }

            IEnumerable<Student> nameBeforeLast =
                from s in students
                where string.Compare(s.FirstName, s.LastName, StringComparison.Ordinal) < 0
                select s;

            foreach (Student s in nameBeforeLast)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName);
            }

            Console.ReadLine();
        }
    }
}
