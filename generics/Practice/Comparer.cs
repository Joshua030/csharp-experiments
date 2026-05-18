namespace Practice;

using Interfaces;

public class Comparer
{

    public static bool AreEqual<T>(T first, T second) where T : class
    {
        return first == second;
    }

}
