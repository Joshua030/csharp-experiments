using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Delegates;
using DependencyInjectionApp;
using EventsApp;
using InheritanceApp;
using InterfacesApp;
using ListsApp;
using MyQuizApp;
using DelegatePerson = Delegates.Person;

namespace ConsoleApp1;

// This class groups all the general C# concepts/examples for learning purposes.
// Each method demonstrates a specific topic and can be called individually from Program.cs.
internal static class CSharpBasics
{
    // ----- Console input + parsing -----
    public static void RunUserInputAndSum()
    {
        Console.WriteLine("Hello, World!");

        int myNUmber;
        int secondNumber;
        string? usereInput = Console.ReadLine();
        myNUmber = int.Parse(usereInput ?? "0"); // Converts user input to int. If null, defaults to 0.
        Console.WriteLine($"You entered: {myNUmber}");
        string? userInput2 = Console.ReadLine();
        // double.Parse() converts a string to a double. Here we use int.Parse instead.
        Console.WriteLine($"You entered: {userInput2}");
        secondNumber = int.Parse(userInput2 ?? "0");
        Console.WriteLine($"The sum of {myNUmber} and {secondNumber} is: {myNUmber + secondNumber}");
        // ReadKey() reads a single key without requiring Enter. Returns a ConsoleKeyInfo.
        Console.ReadKey();
    }

    // ----- Type conversions -----
    public static void RunTypeConversions()
    {
        // Implicit conversion
        int myInt = 10;
        double myDouble = myInt; // int → double (safe, automatic)

        // Explicit conversion (cast)
        double myDouble2 = 9.99;
        int myInt2 = (int)myDouble2; // double → int (data may be lost)

        // Conversion helper methods
        string myString = "123";
        int myInt3 = int.Parse(myString); // string → int via Parse

        string myBoolString = "true";
        bool myBool = Convert.ToBoolean(myBoolString); // string → bool via Convert

        Console.WriteLine($"{myDouble}, {myInt2}, {myInt3}, {myBool}");
    }

    // ----- Implicit vs explicit variable typing -----
    public static void RunVariableTyping()
    {
        // Implicit type variables (var) — type is inferred
        var myVar = "Hello, World!";       // inferred as string
        var myNumberVar = 42;              // inferred as int

        // Explicit type variables
        string myExplicitString = "Hello, World!";
        int myExplicitInt = 42;

        // String interpolation
        Console.WriteLine($"The value of myVar is: {myVar}");

        // String concatenation
        Console.WriteLine("The value of myExplicitString is: " + myExplicitString);

        // String formatting (composite formatting)
        Console.WriteLine("The value of myExplicitInt is: {0}", myExplicitInt);

        Console.WriteLine($"myNumberVar = {myNumberVar}");
    }

    // ----- Escape characters -----
    public static void RunEscapeCharacters()
    {
        Console.WriteLine("This is a line with a newline character.\nThis is the next line.");
        Console.WriteLine("This is a line with a tab character.\tThis is after the tab.");
        Console.WriteLine("This is a line with a backslash character.\\This is after the backslash.");
        Console.WriteLine("This is a line with a double quote character. \"This is in quotes\"");

        // \r is a carriage return — moves the cursor to the start of the current line.
        Console.WriteLine("This is the first line.\rThis is the second line.");
    }

    // ----- TryParse (safe parsing) -----
    public static void RunTryParse()
    {
        // TryParse is safer than Parse: it returns a bool instead of throwing on failure,
        // and writes the parsed value to an out parameter when successful.
        Console.WriteLine("Please enter a number:");
        string? userInput3 = Console.ReadLine();
        if (int.TryParse(userInput3, out int parsedNumber))
        {
            Console.WriteLine($"You entered a valid number: {parsedNumber}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    // ----- Random numbers -----
    public static void RunRandom()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101); // 1..100 (upper bound is exclusive)
        Console.WriteLine($"Generated random number: {randomNumber}");
    }

    // ----- Do-while loop -----
    public static void RunDoWhile()
    {
        // do-while runs the body at least once, then repeats while the condition is true.
        int number;
        do
        {
            Console.WriteLine("Enter a positive number:");
            number = int.Parse(Console.ReadLine() ?? "0");
        } while (number <= 0);

        Console.WriteLine($"Got positive number: {number}");
    }

    // ----- Arrays (1D) -----
    public static void RunArrays()
    {
        int[] numbers = new int[5]; // array of 5 ints (all 0 by default)
        string[] names = new string[] { "Alice", "Bob", "Charlie", "David", "Eve" };

        // Array of objects (mixed types via boxing)
        object[] mixedArray = new object[] { 42, "Hello", 3.14, true };

        // Collection-expression initializer (C# 12+)
        int[] initializedNumbers = [1, 2, 3, 4, 5];

        // foreach iterates over each element of a collection.
        string[] fruits = { "Apple", "Banana", "Cherry" };
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine($"numbers.Length = {numbers.Length}, names[0] = {names[0]}, mixed[1] = {mixedArray[1]}, init[4] = {initializedNumbers[4]}");
    }

    // ----- Multidimensional arrays -----
    public static void RunMultidimensionalArrays()
    {
        int[,] matrix = new int[3, 3];     // 2D array
        int[,,] cube = new int[2, 2, 2];   // 3D array

        // Declare and initialize a 2D array
        int[,] array2DInitialized = { { 1, 2 }, { 3, 4 } };
        Console.WriteLine($"Element at [0,1]: {array2DInitialized[0, 1]}");

        // Loop through a 2D array — sum each row
        int[,] matrixExample = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int rows = matrixExample.GetLength(0);
        int cols = matrixExample.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < cols; j++)
            {
                rowSum += matrixExample[i, j];
            }
            Console.WriteLine(rowSum);
        }

        Console.WriteLine($"matrix size: {matrix.GetLength(0)}x{matrix.GetLength(1)}, cube rank: {cube.Rank}");
    }

    // ----- Quiz mini project demo -----
    public static void RunQuizDemo()
    {
        Question[] questions = new Question[]
        {
            new Question("What is the capital of Germany?", new string[] {"Paris", "Berlin", "London", "Madrid"}, 1),
            new Question("Which planet is known as the Red Planet?", new string[] {"Venus", "Jupiter", "Mars", "Saturn"}, 2),
            new Question("Who painted the Mona Lisa?", new string[] {"Van Gogh", "Picasso", "Da Vinci", "Michelangelo"}, 2),
            new Question("What is the largest ocean on Earth?", new string[] {"Atlantic", "Indian", "Arctic", "Pacific"}, 3),
            new Question("In which year did World War II end?", new string[] {"1943", "1945", "1947", "1950"}, 1),
            new Question("What is the chemical symbol for gold?", new string[] {"Go", "Gd", "Au", "Ag"}, 2)
        };
        Quiz myQuiz = new(questions);
        myQuiz.StartQuiz();
    }

    public static void WorkWithLists()
    {
        //NOTE - Declarin a list and initializing
        List<string> colors = ["red", "blue", "green"];
        List<int> numbers = new List<int> { 10, 5, 15, 3, 9, 25, 18 };
        // delete the first coincidence
        colors.Remove("red");
        foreach (string color in colors)
        {
            Console.WriteLine("Current colors in the colors list!");
            Console.WriteLine(color);
        }

        // delete all the coincidences

        bool isDeletingSuccesful = colors.Remove("red");
        while (isDeletingSuccesful)
        {
            isDeletingSuccesful = colors.Remove("red");
        }

        // Sorting 
        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine("List of sorting numbers!!!");
            Console.WriteLine(number);
        }


        // Define a predicate
        Predicate<int> isGreaterThanTen = x => x >= 10;


        // Find all
        // This will return a list of numbers that are 10 and higher
        List<int> higherEqualTen = numbers.FindAll(isGreaterThanTen);
        foreach (int number in higherEqualTen)
        {
            Console.WriteLine("List ofnumbers greater or eaual  than ten!");
            Console.WriteLine(number);
        }


        Console.ReadKey();

    }

    public static void ComplexLists()
    {
        //NOTE - Method to assign values without a constructor;
        List<Product> products = [
            new Product { Name = "Berries", Price = 2.99 },
            new Product { Name = "Banana", Price = 0.30 },
            new Product { Name = "Cherry", Price = 5.99 },

            ];
        products.Add(new Product { Name = "Apple", Price = 0.80 });

        Console.WriteLine("Available Products");

        foreach (Product product in products)
        {
            Console.WriteLine($"Product name: {product.Name} for {product.Price}");
        }

        //NOTE - Linq Where Statement
        // Defaul way to do it
        // List<Product> cheapProducts = products.Where(x => x.Price < 1.0).ToList();
        List<Product> cheapProducts = [.. products.Where(p => p.Price < 1.0)];

    }

    public static void NullableVariable()
    {


        int? number = 3;

        // Option 1: != null  (most common, works for any type)
        if (number != null)
        {
            Console.WriteLine(number.Value);
        }

        // Option 2: HasValue  (only for Nullable<T>, very explicit)
        if (number.HasValue)
        {
            Console.WriteLine(number.Value);
        }

        // Option 3: pattern matching (modern C#, very clean)
        if (number is int n)
        {
            Console.WriteLine(n);  // 'n' is unwrapped int, not int?
        }
    }


    public static void DictionaryTest()
    {
        //NOTE - defaulinitialization
        /*     Dictionary<int, string> employees = new Dictionary<int, string>
     {
         { 103, "Carlos" },
         { 101, "John Doe" },
         { 102, "Bob Smith" }
     }; */
        Dictionary<int, string> employees = new()
        {
            [103] = "Carlos",
            [101] = "John Doe",
            [102] = "Bob Smith"
        };

        Dictionary<int, Employee> employeesList = new()
        {
            [1] = new Employee("John Doe", 35, 100000),
            [2] = new Employee("Elena Rodriguez", 29, 85000),
            [3] = new Employee("Marcus Chen", 42, 120000),
            [4] = new Employee("Sarah Jenkins", 31, 92000),
            [5] = new Employee("Arjun Patel", 38, 110000)
        };

        // access
        string name = employees[101];

        if (employeesList.TryGetValue(1, out Employee? state))
        {
            Console.WriteLine(state);
        }

        // update (same syntax as initializer!)
        employees[102] = "Jane Smith";

        // remove
        employees.Remove(101);

        // Add a new entry safely

        if (!employees.ContainsKey(104))
        {
            employees.Add(104, "Mike juike");
        }

        bool added = employees.TryAdd(102, "Michael Brins");
        if (!added) Console.WriteLine("Employee with the id 102 was not added");

        // loop over the dictionary
        // With destructuring

        foreach (var (id, named) in employees)
        {
            Console.WriteLine($"ID: {id}, Name: {named}");
        }

        foreach (KeyValuePair<int, string> employee in employees)
        {
            Console.WriteLine($"ID: {employee.Key}, Name: {employee.Value}");
        }


        // Loop employee list

        foreach (var (id, employee) in employeesList)
        {
            Console.WriteLine($"ID:{id} named:{employee.Name}");
        }

        foreach (var (id, (named, age, salary)) in employeesList)
        {
            Console.WriteLine($"ID:{id} named:{named}");
        }



    }

    public static void TryCatchTest()
    {

        int result = 0;

        try
        {
            Console.WriteLine("Please enter a number");

            // _ = int.TryParse(Console.ReadLine(), out int num1);
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter your age");
            string age = Console.ReadLine();
            GetUserAge(age ?? "18");
            int num2 = 2;
            result = num2 / num1;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("DONT DIVIDE BY ZERO!!! " + ex.Message);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.ToString()); // entire error
            Console.WriteLine(error.Message); // error message
            Debug.WriteLine(error.StackTrace); // console erro for debug

        }
        finally
        {
            //Code to cleanup or finalize
            // ideal for cleaning up resources
            // like closing file streams or database connections

            Console.WriteLine("This always executes");
        }

        Console.WriteLine("Result: " + result);



    }

    public static void TryInheritance()
    {
        // InheritanceApp.Employee joe = new("Joe", 36, "Sales Rep", 12345);
        // joe.DisplayPersonInfo();

        Manager carl = new("Carl", 45, "Manager", 123123, 7);
        carl.DisplayPersonInfo();
        carl.BecomeOlder(5);
    }

    public static void TestPolymorphism()
    {

        IPaymentProcesser creditcardProcessor = new CreditCardProcessor();
        PaymentService paymentService = new(creditcardProcessor);
        paymentService.ProcessOrderPayment(100.00m);

        IPaymentProcesser paypalProcessor = new PaypalProcessor();
        PaymentService paypalService = new(paypalProcessor);
        paypalService.ProcessOrderPayment(100.00m);
    }

    public static void TestReadFile()
    {

        /* 
        Decoupling: The Application class depends on the ILogger interface rather than specific 
        implemntations  like FileLogger or DatabaseLogger. This means you can easily switch the logging mechanism
        without changin the Application class.
        */
        ILogger fileLogger = new FileLogger();
        Applicaton app = new Applicaton(fileLogger);
        app.DoWork();

        ILogger dbLogger = new FileLogger();
        app = new Applicaton(dbLogger);
        app.DoWork();
    }

    public static void TestDependencyInjection()
    {
        Hammer hammer = new Hammer();
        Saw saw = new();
        // constructor imjection
        // Builder builder = new(hammer, saw);

        Builder builder = new();

        // setter imjection
        // builder.Hammer = hammer;
        // builder.Saw = saw;

        // interface injection
        builder.SetHammer(hammer);
        builder.SetSaw(saw);

        builder.BuildHouse();

    }

    public static void TestStructs()
    {
        StructsApp.Point p1 = new(10, 20);
        p1.Display();
        // can be initialize without new keyword it needs normal fields
        /*   StructsApp.Point p2;
          p2.X = 10;
          p2.Y = 20;
          p2.Display(); */
        StructsApp.Point p2 = new(20, 30);
        p2.Display();

        double distance = p1.Distance(p2);
        Console.WriteLine($"Distance between points: {distance:F2}");

        // use another point as reference
        StructsApp.Point p3 = p1;
        // p3.X = 50;
        p1.Display();
        p3.Display();

    }

    public static void TestDateTime()
    {

        DateTime dateTime = new DateTime(2018, 5, 31);
        Console.WriteLine($"My birthday is {dateTime}");

        // Write todayn on screen 
        Console.WriteLine(DateTime.Today);
        // Write current time on screen
        Console.WriteLine(DateTime.Now);

        // Get Tomorrow

        DateTime tomorrow = GetTomorrow();
        Console.WriteLine("Tomorrow will be the {0}", tomorrow);
        Console.WriteLine("Today is {0}", DateTime.Today.DayOfWeek);

        // Get first day of specific year
        Console.WriteLine(GetFirstDayOfYear(1999));

        // Get days in a month
        int days = DateTime.DaysInMonth(2000, 2);
        Console.WriteLine("Days in Feb 2000: {0}", days);

        // Get now in minutes
        DateTime now = DateTime.Now;
        Console.WriteLine("Minute: {0}", now.Minute);

        // Display the time in this structure x o'clock y minutes and z seconds
        Console.WriteLine("{0} o'clock {1} minutes and {2} seconds", now.Hour, now.Minute, now.Second);

        // Parse date time
        Console.WriteLine("Write a date in this format: yyyy-mm-dd");
        string? input = Console.ReadLine();
        if (DateTime.TryParse(input, out dateTime))
        {
            Console.WriteLine(dateTime);
            TimeSpan dayPassed = now.Subtract(dateTime);

            Console.WriteLine("Days passed since: {0}", dayPassed.Days);

            // Get the min number
            int num1 = 13;
            int num2 = 9;
            Console.WriteLine("Lower of num1 {0} and num2 {1} is {2}", num1, num2, Math.Min(num1, num2));

        }

    }

    public static void TestMath()
    {
        Console.WriteLine("Ceiling " + Math.Ceiling(15.3));
        Console.WriteLine("Floor " + Math.Floor(15.3));

    }

    private static DateTime GetTomorrow()
    {
        return DateTime.Today.AddDays(1);
    }

    private static DateTime GetFirstDayOfYear(int year)
    {
        return new DateTime(year, 1, 1);
    }

    public static void TestDelegates()
    {
        // Delegates define a method signature,
        // and any method assigned to a delegate mst match this signature

        // 1. Declaration:
        // public delegate void Notify(string Message);

        // 2. Initiation
        Notify notifyDelegate = ShowMessage;
        //Notify notifyDelegate = new Notify(notifyDelegate);

        //3. Invocation
        notifyDelegate("Hello, Delegates");

        /*        Logger logger = new Logger();
               LogHandler logHandler = logger.LogToConsole;
               logHandler("Logging to console");

               logHandler = logger.LogFile;
               logHandler("Log some stuff"); */

        // Multicast delegates
        Logger logger = new Logger();
        LogHandler? logHandler = logger.LogToConsole;
        logHandler += logger.LogFile;

        logHandler("Log some stuff");

        foreach (LogHandler handler in logHandler.GetInvocationList().Cast<LogHandler>())
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }

        logHandler -= logger.LogFile;

        InvokeSafely(logHandler, "After removing logToFile");

    }

    public static void TestDelegatesGenerics()
    {

        DelegatePerson[] people =
         {
            new DelegatePerson{Name = "Alice", Age =30},
            new DelegatePerson{Name = "Bob", Age =25},
            new DelegatePerson{Name = "Denis", Age =36},
            new DelegatePerson{Name = "Charlie", Age =35},

        };

        PersonSorter sorter = new();
        sorter.Sort(people, CompareByAge);

        foreach (DelegatePerson person in people)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }

        sorter.Sort(people, CompareByName);

        foreach (DelegatePerson person in people)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }
    }

    public static void TestEvents()
    {
        EventPublisher publisher = new();
        EventSubscriber subscriber = new();

        publisher.OnNotify += subscriber.OnEventRaised;
        publisher.RaiseEvent("test");

        TemperatureMonitor monitor = new();
        TemperatureAlert alert = new TemperatureAlert();
        monitor.TemperatureChange += alert.OnTemperatureChange;

        monitor.Temperature = 20;
        Console.WriteLine("Please enter the temperature");
        monitor.Temperature = int.Parse(Console.ReadLine() ?? "0");

    }

    public static void TestRegex()
    {
        string pattern = @"\d";
        Regex regex = new(pattern);

        string text = "Hi there, my number is 12314";
        MatchCollection matches = regex.Matches(text);
        Console.WriteLine("{0} hits found", matches.Count);
        foreach (Match match in matches)
        {
            Console.WriteLine("Found number: " + match.Value);

        }
    }

    private static void InvokeSafely(LogHandler? logHandler, string message)
    {
        LogHandler? tempLogHandler = logHandler;
        if (tempLogHandler != null)
        {
            tempLogHandler(message);
        }
    }

    /*  private static bool IsMethodInDelegate(LogHandler logHandler, LogHandler method)
     {
         if (logHandler == null)
         {
             return false;
         }

         foreach (var d in logHandler.GetInvocationList())
         {
             if (d == (Delegate)method)
             {
                 return true;
             }
         }
     } */

    static int CompareByAge(DelegatePerson x, DelegatePerson y)
    {
        return x.Age.CompareTo(y.Age);
    }

    static int CompareByName(DelegatePerson x, DelegatePerson y)
    {
        return x.Name.CompareTo(y.Name);
    }

    public static void TestGenerics()
    {
        int[] intArray = { 1, 2, 3, 4, 5 };
        string[] stringArray = ["one", "Two", "Three"];

        PrintArray(stringArray);
        PrintArray(intArray);

    }

    private static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }


    private static void PrintArray<T>(T[] array)
    {
        foreach (T item in array)
        {
            Console.WriteLine(item);
        }
    }


    private static int GetUserAge(string input)
    {
        if (!int.TryParse(input, out int age))
        {
            throw new Exception("You didn't enter a valid age,");
        }
        if (age < 0 || age > 120)
        {
            throw new Exception("Your age must be between 0 and 120");
        }
        return age;
    }
}
