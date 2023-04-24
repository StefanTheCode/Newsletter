namespace InterfaceSegragation;

public class OfficeWorker : IWork, IEat
{
    public void Eat()
    {
        Console.WriteLine("Office worker is eating lunch.");
    }

    public void Work()
    {
        Console.WriteLine("Office worker is working.");
    }
}