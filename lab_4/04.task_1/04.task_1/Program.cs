using System;

interface IShape
{
    bool Contains(Point p);
}

abstract class Shape : IShape
{
    public abstract bool Contains(Point p);
}

class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Rectangle : Shape
{
    public Point TopLeft { get; }
    public Point BottomRight { get; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public override bool Contains(Point p)
    {
        bool insideX = p.X >= TopLeft.X && p.X <= BottomRight.X;
        bool insideY = p.Y >= TopLeft.Y && p.Y <= BottomRight.Y;
        return insideX && insideY;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter coordinates:");
        string[] rectData = Console.ReadLine().Split();
        int topLeftX = int.Parse(rectData[0]);
        int topLeftY = int.Parse(rectData[1]);
        int bottomRightX = int.Parse(rectData[2]);
        int bottomRightY = int.Parse(rectData[3]);

        IShape rect = new Rectangle(
            new Point(topLeftX, topLeftY),
            new Point(bottomRightX, bottomRightY)
        );

        Console.WriteLine("Number of points:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter points:");
        for (int i = 0; i < n; i++)
        {
            string[] ptData = Console.ReadLine().Split();
            int x = int.Parse(ptData[0]);
            int y = int.Parse(ptData[1]);
            Point p = new Point(x, y);

            Console.WriteLine(rect.Contains(p));
        }
    }
}

