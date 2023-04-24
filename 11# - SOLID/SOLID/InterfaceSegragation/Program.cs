using InterfaceSegragation;

Console.WriteLine("Interface Segregation Principle");

List<object> workers = new()
{
    new OfficeWorker(),
    new MaintenanceWorker()
};

foreach (var worker in workers)
{
    if (worker is IWork working)
    {
        working.Work();
    }

    if (worker is IEat eating)
    {
        eating.Eat();
    }

    if (worker is IMaintenance maintenance)
    {
        maintenance.PerformMaintenance();
    }

    Console.WriteLine();
}