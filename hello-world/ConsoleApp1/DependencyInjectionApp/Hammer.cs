using System;

namespace DependencyInjectionApp;

public interface IToolUser
{
    void SetHammer(Hammer hammer);
    void SetSaw(Saw saw);
}

public class Hammer
{

    public void Use()
    {
        Console.WriteLine("Hammer Nails!");
    }
}

public class Saw
{
    public void Use()
    {
        Console.WriteLine("Sawing wood!");
    }
}

public class Builder : IToolUser
{

    // Constructor Injection
    /*     private Hammer _hammer;
        private Saw _saw;


        public Builder(Hammer hammer, Saw saw)
        {
            _hammer = hammer;
            _saw = saw;
            Console.WriteLine("House built");
        }
     */

    // Setter Injection

    /*  public Hammer? Hammer { get; set; }
     public Saw? Saw { get; set; }

     public void BuildHouse()
     {
         Hammer?.Use();
         Saw?.Use();
         Console.WriteLine("House built");
     } */

    // Interface Injection

    private Hammer _hammer;
    private Saw _saw;

    public void SetHammer(Hammer hammer)
    {
        _hammer = hammer;
    }

    public void SetSaw(Saw saw)
    {
        _saw = saw;
    }

    public void BuildHouse()
    {
        _hammer?.Use();
        _saw?.Use();
        Console.WriteLine("House built");
    }



}
