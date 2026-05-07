using System;

namespace StructsApp;

public struct Point
{
    /* public int X { get; set; }
    public int Y { get; set; } */

    //Normal fields
    /* public int X;
    public int Y; */

    // get accesors for properties 
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
    public double Distance(Point other)
    {
        double dx = other.X - X;
        double dy = other.Y - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public void Display()
    {
        Console.WriteLine($"Point: ({X}, {Y})");
    }
}
