
using InterfacesApp;

namespace InheritanceApp;

public class Dog : Animal
{

    //NOTE - Allows to override the parent method, the parent should be have the keyword virtual
    public override void MakeSound()
    {
        //it call the methos for the base class
        base.MakeSound();
        Console.WriteLine("Barking...");
    }

}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Ct is meow...");
    }
}
