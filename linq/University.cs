using System;

namespace linq;

public class University
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public void Print()
    {
        Console.WriteLine("University {0} with id {1}", Name, Id);
    }
}
