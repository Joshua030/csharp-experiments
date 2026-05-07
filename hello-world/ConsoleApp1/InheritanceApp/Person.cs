
namespace InheritanceApp;

public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine("Person constructor callled");

    }

    public virtual void DisplayPersonInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

    /// <summary> Makes our object older! </summary>
    /// <param name="years"> The parameters thet indicated the amount of years the object should age</param>
    /// <returns>Returns the new age after aging/becoming older</returns>
    public int BecomeOlder(int years)
    {
        Age += years;
        return Age;
    }
}
