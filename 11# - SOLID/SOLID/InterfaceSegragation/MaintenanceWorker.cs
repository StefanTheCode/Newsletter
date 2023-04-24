namespace InterfaceSegragation;

public class MaintenanceWorker : IWork, IMaintenance
{
    public void PerformMaintenance()
    {
        Console.WriteLine("Maintenance worker is performing maintenance tasks.");
    }

    public void Work()
    {
        Console.WriteLine("Maintenance worker is working.");
    }
}