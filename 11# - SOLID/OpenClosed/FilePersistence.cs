using OpenClosed.Abstraction;

namespace OpenClosed;

public class FilePersistence : IPersistence
{
    public void Save(string data)
    {
        //Save to file
        Console.WriteLine($"Saving data to a file: {data}");
    }
}