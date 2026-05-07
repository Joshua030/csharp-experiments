using System;

namespace ConsoleApp1;

public class Consumer
{

    // Static field to hold the next unique ID
    private static int _nextId = 1;

    private readonly int _id; // Read-only field to store the unique ID for each instance
    public string Name { get; set; }
    public string Address { get; set; }

    public string ContactNumber { get; set; }


    public const int MaxConsumers = 100; // Constant field that represents the maximum number of consumers allowed. Constants are immutable and must be initialized at the time of declaration. They cannot be changed after they are set, and they are typically used for values that are known at compile time and should not be modified.
    public readonly DateTime CreatedAt = DateTime.Now; // Read-only field that is initialized with the current date and time when the instance is created. Read-only fields can only be assigned a value during declaration or in a constructor, and they cannot be modified afterwards. This is useful for values that should remain constant after the object is created, such as a timestamp or an ID that should not change.
    // backing field for write-only property
    private string _password;

    public string Password
    {
        set => _password = value; // Write-only property that allows setting the password but not getting it
    }


    // read only property

    public int Id
    {
        get => _id; // Return the value of the read-only field _id
    }

    public double Height { get; set; }
    public double Width { get; set; }


    public Consumer(string name, string address, string contactNumber)
    {
        _id = _nextId++; // Assign the current value of _nextId to _id, then increment _nextId for the next instance
        Name = name;
        Address = address;
        ContactNumber = contactNumber;
    }
    public Consumer(string name)
    {
        _id = _nextId++; // Assign the current value of _nextId to _id, then increment _nextId for the next instance
        Name = name;
        Address = "Unknown";
        ContactNumber = "Unknown";
    }

    //Computed property (Read-only property)
    public double Area
    {
        get => Height * Width;
    }

    // Static method we can call this method without creating an instance of the Consumer class. It belongs to the class itself rather than any specific object. Static methods are often used for utility functions or operations that do not require access to instance-specific data.
    public static void DoSomething()
    {
        Console.WriteLine("Doing something...");
    }

}
