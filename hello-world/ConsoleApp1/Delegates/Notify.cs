

namespace Delegates;

public delegate void Notify(string Message);
public delegate void LogHandler(string message);

public class Logger
{
    public void LogToConsole(string message)
    {
        Console.WriteLine("Console Log: " + message);
    }

    public void LogFile(string message)
    {
        Console.WriteLine("File log: " + message);
    }
}
