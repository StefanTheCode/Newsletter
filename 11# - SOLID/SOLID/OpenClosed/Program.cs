using OpenClosed.Abstraction;
using OpenClosed;

Console.WriteLine("Open-Closed Principle");

List<IPersistence> persistenceMethods = new()
{
    new DatabasePersistence(),
    new FilePersistence()
};

string data = "Sample data to be saved";

SaveData(persistenceMethods, data);

static void SaveData(List<IPersistence> persistenceMethods, string data)
{
    foreach (var persistence in persistenceMethods)
    {
        persistence.Save(data);
    }
}