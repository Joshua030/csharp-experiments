using Interfaces;

namespace Practice;

public class EmailTask : ITask<string>
{

    public string? Recipient { get; set; }
    public string? Message { get; set; }

    public string Perform()
    {
        return $"Email to: {Recipient}, Message: {Message}";
    }
}

