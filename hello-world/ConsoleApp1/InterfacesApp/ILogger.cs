using System;
namespace InterfacesApp;

public interface ILogger
{
    void Log(string message);
}


public class FileLogger : ILogger
{
    public void Log(string message)
    {
        //NOTE - Way to append text to a file
        // The @ sign in C# is used to denote a verbatism string literal
        string directoryPath = @"C:\Logs";
        // string directoryPath = "C:\\Logs";
        Directory.CreateDirectory(directoryPath);
        File.AppendAllText(Path.Combine(directoryPath, "log.txt"), $"{message}.\n");
    }
}

public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        // implement the logic to log a message to a database
        Console.WriteLine($"Logging to database. {message}");
    }
}

public class Applicaton
{
    private readonly ILogger _logger;

    public Applicaton(ILogger logger)
    {
        _logger = logger;
    }

    public void DoWork()
    {
        _logger.Log("Work started");
        // DO ALL THE WORK
        _logger.Log("work done!");
    }
}