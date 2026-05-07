using InterfacesApp;

namespace InheritanceApp;

public class Animal : IAnimal
{

    public void Eat()
    {
        Console.WriteLine("Eating...");
    }

    //NOTE - Virtual keyword allows to overrithe the method
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal make a generic sound");
    }

    public void Eat(string food)
    {
        Console.WriteLine($"Animal is eating {food}");
    }
}
