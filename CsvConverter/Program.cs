// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

Console.WriteLine("Enter IDs (one per line). Press Enter on an empty line to finish:");

List<string> ids = new List<string>();
string input;

// Read multiple lines until the user enters an empty line
while ((input = Console.ReadLine()) != "")
{
    ids.Add(input);
}

// Create an object to hold the IDs (e.g., for a field named 'plainOffers')
var data = new
{
    plainOffers = ids
};

// Serialize the object to a JSON string
string jsonString = JsonSerializer.Serialize(data);

Console.WriteLine("\nGenerated JSON string:");
Console.WriteLine(jsonString);

