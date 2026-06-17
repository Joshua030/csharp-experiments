
// Exercise: Product data manipulation
// You receive this JSON from an API endpoint. Your job:
// parse it, then complete each task below using LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

// ──  Raw JSON (pretend this came from HttpClient) ───
string json = """
[
  { "id": 1, "name": "Wireless Mouse",     "category": "Electronics", "price": 29.99,  "stock": 120, "rating": 4.5, "tags": ["wireless", "office"] },
  { "id": 2, "name": "Mechanical Keyboard","category": "Electronics", "price": 89.99,  "stock": 45,  "rating": 4.8, "tags": ["mechanical", "office", "gaming"] },
  { "id": 3, "name": "Standing Desk",      "category": "Furniture",   "price": 349.00, "stock": 12,  "rating": 4.2, "tags": ["ergonomic", "office"] },
  { "id": 4, "name": "Webcam HD",          "category": "Electronics", "price": 59.99,  "stock": 0,   "rating": 3.9, "tags": ["video", "office"] },
  { "id": 5, "name": "Monitor 27\"",       "category": "Electronics", "price": 299.99, "stock": 30,  "rating": 4.7, "tags": ["display", "office"] },
  { "id": 6, "name": "Desk Chair",         "category": "Furniture",   "price": 199.00, "stock": 8,   "rating": 4.1, "tags": ["ergonomic", "comfort"] },
  { "id": 7, "name": "USB-C Hub",          "category": "Electronics", "price": 39.99,  "stock": 200, "rating": 4.3, "tags": ["usb", "office"] },
  { "id": 8, "name": "Notebook A5",        "category": "Stationery",  "price": 8.99,   "stock": 500, "rating": 4.0, "tags": ["writing", "office"] },
  { "id": 9, "name": "Pen Set",            "category": "Stationery",  "price": 12.49,  "stock": 300, "rating": 3.7, "tags": ["writing"] },
  { "id": 10,"name": "Laptop Stand",       "category": "Electronics", "price": 49.99,  "stock": 75,  "rating": 4.6, "tags": ["ergonomic", "office"] }
]
""";

// ── 2. Parse ──────────────────────────────────────────
List<Product> products = JsonSerializer.Deserialize<List<Product>>(json) ?? [];

// ── 4. Tasks — implement each one ────────────────────

// TASK 1 — Filter
// Get all Electronics that are in stock (stock > 0), sorted by price descending.
List<Product> inStockElectronics = products.FindAll(
    p => p.Category == "Electronics" && p.Stock > 100
);

inStockElectronics.Sort((a, b) => b.Price.CompareTo(a.Price));
// Convert the list back to a pretty string and print it

// Define options for "pretty printing" (adding indentations and spacing)
var options = new JsonSerializerOptions { WriteIndented = true };

string jsonDump = JsonSerializer.Serialize(inStockElectronics, options);
//Console.WriteLine(jsonDump);

List<Product> inStockElectronicsLinq = products.
Where(product => product.Stock > 100 && product.Category == "Electronics")
.OrderByDescending(product => product.Price)
.ToList();

string jsonDumpLinq = JsonSerializer.Serialize(inStockElectronicsLinq, options);
//Console.WriteLine("with linq: " + jsonDumpLinq);


// TASK 2 — Map / transform
// Project to an anonymous type with just Name and a discounted price (10% off).
var discounted = products.Select(product => new
{
    product.Name,
    DiscountedPrice = product.Price * 0.9m
});

// TASK 3 — Find
// Find the single product with the highest rating.
// If there's a tie, take the first one. Use FirstOrDefault.
var topRated = products
    .OrderByDescending(p => p.Rating)
    .FirstOrDefault();

// TASK 4 — Group
// Group products by category.
// Result: Dictionary<string, List<Product>>
var byCategory = products
    .GroupBy(p => p.Category)
    .ToDictionary(g => g.Key, g => g.ToList());

string jsonByCategoryLinq = JsonSerializer.Serialize(byCategory, options);
// Console.WriteLine("with linq: " + jsonByCategoryLinq);

// TASK 5 — Aggregate
// For each category, calculate the average price.
// Result: Dictionary<string, decimal>
var avgPriceByCategory = products
    .GroupBy(p => p.Category)
    .ToDictionary(
        g => g.Key,
        g => g.Average(p => p.Price)
    );

string jsonByCategoryAvg = JsonSerializer.Serialize(avgPriceByCategory, options);
// Console.WriteLine("with linq: " + jsonByCategoryAvg);

// TASK 6 — Flat filter on nested data
// Find all products that have the tag "office".
var officeProducts = products
    .Where(p => p.Tags.Any(t => t == "office"))
    .ToList();

// TASK 7 — Combine filter + transform
// Build a "restock list": products where stock < 20,
// projected to a new type: { Name, Stock, RestockQty (= 100 - Stock) }
var restockList = products.
Where(p => p.Stock < 20).
Select(p => new
{
    p.Name,
    p.Stock,
    RestockQty = 100 - p.Stock
}).
ToList();

// TASK 8 — Partition (the tricky one)
// Split products into two lists in a single pass:
// expensive (price >= 100) and affordable (price < 100).
// Hint: lookup ToLookup() — it's like GroupBy but gives you direct key access.
var priceGroups = products
    .ToLookup(p => p.Price >= 100);

var expensive = priceGroups[true].ToList();
var affordable = priceGroups[false].ToList();

// ── 1. Model ──────────────────────────────────────────
public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("stock")]
    public int Stock { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }
}






/* // TASK 2 — Map / transform
// Project to an anonymous type with just Name and a discounted price (10% off).
var discounted = // TODO

// TASK 3 — Find
// Find the single product with the highest rating.
// If there's a tie, take the first one. Use FirstOrDefault.
var topRated = // TODO

// TASK 4 — Group
// Group products by category.
// Result: Dictionary<string, List<Product>>
var byCategory = // TODO

// TASK 5 — Aggregate
// For each category, calculate the average price.
// Result: Dictionary<string, decimal>
var avgPriceByCategory = // TODO

// TASK 6 — Flat filter on nested data
// Find all products that have the tag "office".
var officProducts = // TODO

// TASK 7 — Combine filter + transform
// Build a "restock list": products where stock < 20,
// projected to a new type: { Name, Stock, RestockQty (= 100 - Stock) }
var restockList = // TODO

// TASK 8 — Partition (the tricky one)
// Split products into two lists in a single pass:
// expensive (price >= 100) and affordable (price < 100).
// Hint: lookup ToLookup() — it's like GroupBy but gives you direct key access.
var priceGroups  = // TODO
var expensive    = priceGroups[true].ToList();
var affordable   = priceGroups[false].ToList(); */
