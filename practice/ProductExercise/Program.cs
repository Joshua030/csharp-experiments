using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

// ── 2. Raw JSON ───────────────────────────────────────
const string jsonNew = """
[
  { "id": 1,  "title": "Clean Code",             "author": { "name": "Robert Martin",   "nationality": "American" }, "genre": "Technology", "price": 34.99, "pages": 431, "year": 2008, "rating": 4.7, "inStock": true,  "tags": ["programming", "best-practices"] },
  { "id": 2,  "title": "The Pragmatic Programmer","author": { "name": "David Thomas",    "nationality": "British"  }, "genre": "Technology", "price": 39.99, "pages": 352, "year": 1999, "rating": 4.8, "inStock": true,  "tags": ["programming", "career"] },
  { "id": 3,  "title": "Dune",                   "author": { "name": "Frank Herbert",   "nationality": "American" }, "genre": "Sci-Fi",     "price": 14.99, "pages": 688, "year": 1965, "rating": 4.9, "inStock": true,  "tags": ["classic", "space"] },
  { "id": 4,  "title": "1984",                   "author": { "name": "George Orwell",   "nationality": "British"  }, "genre": "Fiction",    "price": 11.99, "pages": 328, "year": 1949, "rating": 4.7, "inStock": false, "tags": ["classic", "dystopia"] },
  { "id": 5,  "title": "Sapiens",                "author": { "name": "Yuval Noah Harari","nationality": "Israeli" }, "genre": "History",    "price": 18.99, "pages": 443, "year": 2011, "rating": 4.5, "inStock": true,  "tags": ["history", "science"] },
  { "id": 6,  "title": "Refactoring",            "author": { "name": "Martin Fowler",   "nationality": "British"  }, "genre": "Technology", "price": 44.99, "pages": 448, "year": 1999, "rating": 4.6, "inStock": false, "tags": ["programming", "best-practices"] },
  { "id": 7,  "title": "The Hobbit",             "author": { "name": "J.R.R. Tolkien",  "nationality": "British"  }, "genre": "Fantasy",    "price": 12.99, "pages": 310, "year": 1937, "rating": 4.8, "inStock": true,  "tags": ["classic", "adventure"] },
  { "id": 8,  "title": "Cosmos",                 "author": { "name": "Carl Sagan",      "nationality": "American" }, "genre": "Science",    "price": 17.99, "pages": 365, "year": 1980, "rating": 4.6, "inStock": true,  "tags": ["science", "space"] },
  { "id": 9,  "title": "Design Patterns",        "author": { "name": "Gang of Four",    "nationality": "American" }, "genre": "Technology", "price": 49.99, "pages": 395, "year": 1994, "rating": 4.5, "inStock": true,  "tags": ["programming", "architecture"] },
  { "id": 10, "title": "Brave New World",        "author": { "name": "Aldous Huxley",   "nationality": "British"  }, "genre": "Fiction",    "price": 10.99, "pages": 311, "year": 1932, "rating": 4.4, "inStock": true,  "tags": ["classic", "dystopia"] }
]
""";

// ── 3. Parse ──────────────────────────────────────────
var books = JsonSerializer.Deserialize<List<Book>>(jsonNew)!;


// ── 1. Models ─────────────────────────────────────────
public class Author
{
  [JsonPropertyName("name")]
  public string Name { get; set; }

  [JsonPropertyName("nationality")]
  public string Nationality { get; set; }
}

public class Book
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("title")]
  public string Title { get; set; }

  [JsonPropertyName("author")]
  public Author Author { get; set; }

  [JsonPropertyName("genre")]
  public string Genre { get; set; }

  [JsonPropertyName("price")]
  public decimal Price { get; set; }

  [JsonPropertyName("pages")]
  public int Pages { get; set; }

  [JsonPropertyName("year")]
  public int Year { get; set; }

  [JsonPropertyName("rating")]
  public double Rating { get; set; }

  [JsonPropertyName("inStock")]
  public bool InStock { get; set; }

  [JsonPropertyName("tags")]
  public List<string> Tags { get; set; }
}


// ── 4. Tasks ──────────────────────────────────────────

// TASK 1 — Filter + sort
// Get all books that are in stock, sorted by rating descending.

// TASK 2 — Map on nested object
// Project to anonymous type: { Title, AuthorName, Price }
// where AuthorName comes from book.Author.Name

// TASK 3 — Aggregate per group
// For each genre, get the total number of books and the average rating.
// Result: Dictionary<string, (int Count, double AvgRating)>
// Hint: value tuples — C# lets you do new { Count = ..., AvgRating = ... }
// or use (int, double) tuple syntax directly.

// TASK 4 — Find with condition on nested property
// Find all books written by British authors, sorted by year ascending.

// TASK 5 — Flat filter on nested list
// Get all books tagged "classic", return just their titles as List<string>.

// TASK 6 — Chained transforms
// From Technology books only, apply a 15% discount to the price,
// and return { Title, OriginalPrice, DiscountedPrice } sorted by DiscountedPrice.

// TASK 7 — Min / Max without hardcoding
// Find the longest book (most pages) and the shortest book.
// Print both titles and their page counts.
// Hint: MaxBy() and MinBy() — available in .NET 6+, no need to sort the whole list.

// TASK 8 — Any / All (boolean checks you'll use constantly)
// a) Is there any book out of stock?               → bool, use .Any()
// b) Are all Technology books rated above 4.0?     → bool, use .All()
// c) How many distinct nationalities are there?    → int, use .Select(...).Distinct().Count()