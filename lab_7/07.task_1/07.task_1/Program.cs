using System;
using System.Linq;

namespace PhoneApp
{
    interface ICall
    {
        void Call(string number);
    }

    interface IBrowse
    {
        void Browse(string url);
    }

    abstract class BasePhone
    {
        public string Model { get; set; }

        public BasePhone(string model)
        {
            Model = model;
        }
    }

    class Smartphone : BasePhone, ICall, IBrowse
    {
        public Smartphone(string model) : base(model) { }

        public void Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public void Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ');
            string[] websites = Console.ReadLine().Split(' ');

            Smartphone phone = new Smartphone("SPhone");

            foreach (string number in phoneNumbers)
            {
                phone.Call(number);
            }

            foreach (string site in websites)
            {
                phone.Browse(site);
            }
        }
    }
}

