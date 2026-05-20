using System.Reflection;
using generics;
using Practice;
// See https://aka.ms/new-console-template for more information

Box<int> box = new(42);
Console.WriteLine(box.Log());
Box<string> stringBox = new("Hello");
Console.WriteLine(stringBox.Log());

stringBox.UpdateContent("World");
Console.WriteLine(stringBox.Log());
Console.WriteLine($"The content of the box is: {stringBox.GetContent()}");
Logger.Log("This is a log message.");

Repository<Product> productRepository = new();
productRepository.Add(new Product(1));
productRepository.Add(new Product(2));

Product productOne = new Product(1);
Product productTwo = new(2);
Logger.Log(Comparer.AreEqual(productOne, productTwo).ToString());

Type type = typeof(ConfigurationManager<>); //NOTE - This gets the generic type definition of ConfigurationManager

// NOTE - Way to check type of something

string name = "Jannick";

if (name.GetType() == typeof(string))
{
    // Do something !!
}

// NOTE - Action is used to represent a method that takes parameters but does not return a value
Action<float, float, string> testAction = (x, y, z) => Console.WriteLine($"{x}, {y}, {z}");

// NOTE - Func is used to represent a method that takes parameters and returns a value
// the last parameter represent the return

Func<string, int> stringToInt = s => int.Parse(s);

//NOTE - Predicate is used to represent a method that takes a parameter and returns a 
// a boolean value
Predicate<int> isEven = n => n % 2 == 0;

var emailTask = new EmailTask()
{
    Message = "Hello, this is a test email",
    Recipient = "example@example.com"
};

ReportTask reportTask = new()
{
    ReportName = "Annual report"
};

var emailProcessor = new TaskProcessor<EmailTask, string>(emailTask);
var reportProcessor = new TaskProcessor<ReportTask, string>(reportTask);

Console.WriteLine(emailProcessor.Execute());
Console.WriteLine(reportProcessor.Execute());
