using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    public class Book
    {
        protected string author;
        protected string title;
        protected decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                string[] parts = value.Split(' ');

                if (parts.Length >= 2)
                {
                    string surname = parts[1];

                    if (char.IsDigit(surname[0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                string title = value;

                if (title.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
            }
        }
        public virtual decimal Price
        {
            get
            {
                return Math.Round(this.price, 2);
            }
            set
            {
                this.price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }

    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {

        }

        public override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }
        }
    }

    static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book + Environment.NewLine);
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}