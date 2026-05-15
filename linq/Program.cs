using linq;

/* int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
OddNumbers(numbers);
UniversityManager um = new UniversityManager();
um.MaleStudents();
um.SortStudentsByAge();
um.AllStudentsFromBeijingTech();
um.StudentAndUniversityNameCollection();
LinkqWithXML.Test();
 */

DatabaseConnection.InsertUniversities();
DatabaseConnection.GetUniversities();
DatabaseConnection.InsertStudents();
DatabaseConnection.GetStudents();

/* string? userInput = Console.ReadLine();
if (int.TryParse(userInput, out int parsedNumber))
{
    um.GetStudentsByUniversityId(parsedNumber);
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
} */



/* 
void OddNumbers(int[] numbers)
{
    Console.WriteLine("Odd NUmbers");
    // IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;
    IEnumerable<int> oddNumbers = numbers.Where(n => n % 2 != 0);

    // Loop over each number
    oddNumbers.ToList()
       .ForEach(Console.WriteLine);

} */