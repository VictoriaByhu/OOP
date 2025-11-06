using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_StudentsByGroup
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
                if (parts.Length != 3)
                {
                    continue;
                }

                int groupNum;
                if (!int.TryParse(parts[2], out groupNum))
                {
                    continue;
                }

                students.Add(new Student
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    GroupNumber = groupNum
                });
            }


            IEnumerable<Student> group2Students =
                from s in students
                where s.GroupNumber == 2
                orderby s.FirstName
                select s;

            foreach (Student s in group2Students)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName);
            }

            Console.ReadLine();
        }
    }
}
