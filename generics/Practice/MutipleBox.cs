namespace Practice;

public class MutipleBox<T1, T2>
{
    private Box<T1> _box1;
    private Box<T2> _box2;

    public MutipleBox(Box<T1> box1, Box<T2> box2)
    {
        _box1 = box1;
        _box2 = box2;
    }

    public void UpdateBox1(T1 newContent)
    {
        _box1.UpdateContent(newContent);
    }

    public void UpdateBox2(T2 newContent)
    {
        _box2.UpdateContent(newContent);
    }

    public (T1, T2) GetContents()
    {
        return (_box1.GetContent(), _box2.GetContent());
    }
}
