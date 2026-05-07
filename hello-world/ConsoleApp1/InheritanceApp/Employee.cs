using System;

namespace InheritanceApp;

//NOTE -  public sealed class Employee : Person, sealed protect for inheritance this class
public class Employee : Person
{
    public string JobTitle { get; private set; }
    public int EmployeeID { get; private set; }
    public Employee(string name, int age, string jobTitle, int employeeID) : base(name, age)
    {

        JobTitle = jobTitle;
        EmployeeID = employeeID;
        Console.WriteLine("Employee (derived class) constructor called");
    }


    public override void DisplayPersonInfo()
    {
        base.DisplayPersonInfo();
        Console.WriteLine($"JobTitle: {JobTitle}, EmployeeId: {EmployeeID}");
    }
}


public class Manager(string name, int age, string jobTitle, int employeeID, int teamSize) : Employee(name, age, jobTitle, employeeID)
{
    public int TeamSize { get; private set; } = teamSize;

    public override void DisplayPersonInfo()
    {
        base.DisplayPersonInfo();
        Console.WriteLine($"Team Size: {TeamSize}");
    }
}