namespace Practice;

//NOTE - Way to create a generic with a constraint
public class Box<T> where T : notnull
{

    private T? _content;
    private T? Content
    {
        get => _content;
        set => _content = value;
    }

    public Box(T? content)
    {
        _content = content;
    }

    public string Log()
    {
        return $"Box containes {Content}";
    }

    public void UpdateContent(T? newContent)
    {
        _content = newContent;

        Console.WriteLine($"Box updated to contain {Content}");
    }

    public T GetContent()
    {
        return Content ?? throw new InvalidOperationException("Box is empty");
    }


}
