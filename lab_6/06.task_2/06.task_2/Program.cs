using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public class Person
    {
        string firstName;
        string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get 
            { 
                return firstName; 
            }
            set
            {
                string fn = value;

                if (!char.IsUpper(fn[0]))
                {
                    throw new ArgumentException("Expected upper case! Argument: firstName");
                }
                if (fn.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                this.firstName = fn;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                string ln = value;

                if (!char.IsUpper(ln[0]))
                {
                    throw new ArgumentException("Expected upper case! Argument: lastName");
                }
                if (ln.Length <= 2)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: lastName");
                }

                this.lastName = ln;
            }
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName}\nLast Name: {this.LastName}";
        }
    }

    class Student : Person
    {
        string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                string fNum = value;

                if (fNum.Length < 5 || fNum.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = fNum;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nFaculty number: {this.FacultyNumber}";
        }
    }

    class Employee : Person
    {
        decimal weekSalary;
        decimal hoursPerDay;
        decimal salaryPerHour;

        public Employee(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return Math.Round(this.weekSalary, 2);
            }
            set
            {
                decimal wSalary = value;
                if (wSalary <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = wSalary;
            }
        }
        public decimal HoursPerDay
        {
            get
            {
                return Math.Round(this.hoursPerDay, 2);
            }
            set
            {
                decimal hours = value;

                if (hours < 1 || hours > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: hoursPerDay");
                }
                this.hoursPerDay = hours;
            }
        }

        public decimal SalaryPerHour => Math.Round(this.WeekSalary / (this.HoursPerDay * 5), 2);

        public override string ToString()
        {
            return $"{base.ToString()}\nWeek Salary: {this.WeekSalary:F2}\nHours per day: {this.HoursPerDay:F2}\nSalary per hour: {this.SalaryPerHour:F2}";
        }
    }

    static void Main()
    {
        try
        {
            string[] studentData = Console.ReadLine().Split(' ');
            string studentFirstName = studentData[0];
            string studentLastName = studentData[1];
            string facultyNumber = studentData[2];

            string[] employeeData = Console.ReadLine().Split(' ');
            string employeeFirstName = employeeData[0];
            string employeeLastName = employeeData[1];
            decimal weekSalary = decimal.Parse(employeeData[2]);
            decimal hoursPerDay = decimal.Parse(employeeData[3]);

            Student student = new Student(studentFirstName, studentLastName, facultyNumber);
            Employee employee = new Employee(employeeFirstName, employeeLastName, weekSalary, hoursPerDay);

            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(employee);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}