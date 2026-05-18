
using Practice;
// See https://aka.ms/new-console-template for more information

Box<int> box = new(42);
Console.WriteLine(box.Log());
Box<string> stringBox = new("Hello");
Console.WriteLine(stringBox.Log());

stringBox.UpdateContent("World");
Console.WriteLine(stringBox.Log());
Console.WriteLine($"The content of the box is: {stringBox.GetContent()}");
Logger.Log("This is a log message.");

Repository<Product> productRepository = new();
productRepository.Add(new Product(1));
productRepository.Add(new Product(2));

Product productOne = new Product(1);
Product productTwo = new(2);
Logger.Log(Comparer.AreEqual(productOne, productTwo).ToString());