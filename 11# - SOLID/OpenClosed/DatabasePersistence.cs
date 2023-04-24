using OpenClosed.Abstraction;

namespace OpenClosed;

public class DatabasePersistence : IPersistence
{
    public void Save(string data)
    {
        //Save to database
        Console.WriteLine($"Saving data to database: {data}");
    }
}