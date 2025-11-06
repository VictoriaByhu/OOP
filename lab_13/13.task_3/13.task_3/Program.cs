using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_StudentsByAge
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
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


                int age;
                if (!int.TryParse(parts[2], out age))
                {
                    continue;
                }

                students.Add(new Student
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    Age = age
                });
            }

            // LINQ-запит: студенти від 18 до 24 років
            IEnumerable<Student> youngStudents =
                from s in students
                where s.Age >= 18 && s.Age <= 24
                select s;


            foreach (Student s in youngStudents)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName + s.Age);
            }

            Console.ReadLine();
        }
    }
}
