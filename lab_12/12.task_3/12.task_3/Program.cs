using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _12.task_3
{
    public interface IEmployee
    {
        string Name { get; }
        int workHours { get; }
    }

    public class StandardEmployee : IEmployee
    {
        public string Name { get; private set; }
        public int workHours { get; private set; }

        public StandardEmployee(string name)
        {
            Name = name;
            workHours = 40;
        }
        
    }

    public class PartTimeEmployee : IEmployee
    {
        public string Name { get; private set; }
        public int workHours { get; private set; }

        public PartTimeEmployee(string name)
        {
            Name = name;
            workHours = 20;
        }
    }

    public delegate void JobDoneEventHandler(Job job);
    public class Job
    {
        public string JobName { get; private set; }
        public int RequiredHours { get; private set; }
        public IEmployee Employee { get; private set; }
        public bool IsDone { get; private set; }

        public event JobDoneEventHandler JobDone;
        public Job(string jobName, int hoursOfWorkRequired, IEmployee employee)
        {
            JobName = jobName;
            RequiredHours = hoursOfWorkRequired;
            Employee = employee;
            IsDone = false;
        }

        public void Update()
        {
            if (IsDone)
                return;

            RequiredHours -= Employee.workHours;

            if (RequiredHours <= 0 && !IsDone)
            {
                IsDone = true;
                Console.WriteLine($"Job {JobName} done!");
                JobDone?.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"Job: {JobName} Hours Remaining: {RequiredHours}";
        }
    }
    public class JobList : ArrayList
    {
        public void AddJob(Job job)
        {
            job.JobDone += OnJobDone;
            Add(job);
        }

        private void OnJobDone(Job job)
        {
            job.JobDone -= OnJobDone;
            Remove(job);
        }

        public void UpdateAll()
        {
            foreach (Job job in new ArrayList(this))
            {
                job.Update();
            }
        }

        public void PrintStatus()
        {
            foreach (Job job in this)
            {
                if (!job.IsDone)
                    Console.WriteLine(job.ToString());
            }
        }
        public bool HasJob(string jobName)
        {
            foreach (Job job in this)
            {
                if (job.JobName == jobName)
                    return true;
            }
            return false;
        }
    }
    public class Program
    {
        public static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>();
            JobList jobList = new JobList();
            int commandCount = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == null) continue;
                if (input == "End") break;

                commandCount++;
                if (commandCount > 100)
                {
                    Console.WriteLine("The maximum number of commands (100) has been exceeded!");
                    break;
                }

                string[] parts = input.Split(' ');
                string command = parts[0];

                if (command == "StandardEmployee")
                {
                    string name = parts[1];
                    if (IsValidName(name) && !EmployeeExists(employees, name))
                    {
                        employees.Add(new StandardEmployee(name));
                    }
                    else
                    {
                        Console.WriteLine($"Employee {name} already exists or the name is wrong");
                    }

                }
                else if (command == "PartTimeEmployee")
                {
                    string name = parts[1];
                    if (IsValidName(name))
                        employees.Add(new PartTimeEmployee(name));
                }
                else if (command == "Job")
                {
                    string jobName = parts[1];
                    int hours = int.Parse(parts[2]);
                    string employeeName = parts[3];


                    if (!IsValidName(jobName)) continue;

                    if (jobList.HasJob(jobName))
                    {
                        Console.WriteLine($"Job {jobName} already exists!");
                        continue;
                    }

                    IEmployee worker = FindEmployee(employees, employeeName);
                    if (worker != null)
                    {
                        Job job = new Job(jobName, hours, worker);
                        jobList.AddJob(job);
                    }
                }
                else if (input == "Pass Week")
                {
                    jobList.UpdateAll();
                }
                else if (input == "Status")
                {
                    jobList.PrintStatus();
                }
            }
        }

        private static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool EmployeeExists(List<IEmployee> employees, string name)
        {
            foreach (var e in employees)
            {
                if (e.Name == name)
                    return true;
            }
            return false;
        }

        private static IEmployee FindEmployee(List<IEmployee> employees, string name)
        {
            foreach (var e in employees)
            {
                if (e.Name == name)
                    return e;
            }
            return null;
        }
    }

}
