using System;

namespace ConsoleApp1;

// Internal means that the class is accessible only within the same assembly. It cannot be accessed from other assemblies. This is useful for encapsulating implementation details and preventing external code from accessing or modifying the internal workings of the class. In this case, the Car class can only be used within the same project or assembly where it is defined.
internal class Car
{

    // member variable
    // private hides the variable from outside the class. It can only be accessed and modified through methods or properties defined within the class. This is a fundamental principle of encapsulation in object-oriented programming, which helps to protect the internal state of an object and maintain control over how it is accessed and modified.
    private string _model = "";
    private string _brand = "";

    // property 
    // public string Model { get => _model; set => _model = value; }
    // default getter an setter for the Model property.
    public string Model { get; set; }

    public string Brand
    {
        get => _brand;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Brand cannot be null or empty.");
                _brand = "Unknown"; // This line will never be reached because the exception will be thrown before it. It is generally not a good practice to have code after a throw statement, as it can lead to confusion and unreachable code. In this case, if the value is null or empty, the exception will be thrown and the method will exit immediately, so the line setting _brand to "Unknown" will never be executed.
            }
            else
            {

                _brand = value;
            }

        }
    }

    public Car(string model, string brand)
    {
        Model = model;
        Brand = brand;
        Console.WriteLine("Car constructor called. Model: " + _model + ", Brand: " + _brand);
    }

}
