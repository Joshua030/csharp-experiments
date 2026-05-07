using System;

namespace Delegates;


public delegate int Comparison<T>(T x, T y);


public class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
}

public class PersonSorter
{
    public void Sort(Person[] people, Comparison<Person> comparison)
    {
        for (int i = 0; i < people.Length - 1; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                // Compare people
                if (comparison(people[i], people[j]) > 0)
                {
                    // Swap people
                    Person temp = people[i];
                    people[i] = people[j];
                    people[j] = temp;
                }

            }
        }
    }
}