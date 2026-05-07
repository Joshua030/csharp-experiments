public record Employee(string Name, int Age, int Salary);

/* That's it. This single line gives you:

Constructor (new Employee("Jose", 30, 50000))
Properties (Name, Age, Salary) — read-only by default
Deconstruct method (destructuring works automatically)
Value equality (emp1 == emp2 compares values, not references)
ToString() override (prints Employee { Name = Jose, Age = 30, Salary = 50000 })
with expressions (var older = emp with { Age = 31 };)
GetHashCode() based on values */