using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dispatcher
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    public class Dispatcher
    {
        private string name;
        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get { return name; }
            set
            {
                if (this.name != value && !string.IsNullOrWhiteSpace(value) )
                {
                    this.name = value;
                    this.OnNameChange(new NameChangeEventArgs(value));
                }
            }
        }

        protected void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
            {
                this.NameChange(this, args);
            }
        }
    }

    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }

    public class NameChangeEventArgs : EventArgs
    {
        public string Name { get; private set; }

        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }
    }

    class Program
    {
        static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            int commandCount = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;

                if (!IsAlphanumeric(input))
                {
                    Console.WriteLine("Error: The name must contain only alphanumeric characters");
                    continue;
                }
                commandCount++;

                if (commandCount > 100)
                {
                    Console.WriteLine("The limit of 100 teams has been reached");
                    break;
                }

                dispatcher.Name = input;

            }
        }

        static bool IsAlphanumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
    }
}
