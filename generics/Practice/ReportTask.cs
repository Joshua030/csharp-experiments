using Interfaces;

namespace Practice;

public class ReportTask : ITask<string>
{
    public string? ReportName { get; set; }
    public string Perform()
    {
        return $"Report {ReportName} generated successfully.";
    }
}
