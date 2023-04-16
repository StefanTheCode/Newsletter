namespace API.Jobs;

public class JobsService : IJobsService
{
    public void BatchJob()
    {
        Console.WriteLine("This is a Batch Job");
    }

    public void Continuation()
    {
        Console.WriteLine("This is a Continuation");
    }

    public void DelayedJob()
    {
        Console.WriteLine("This is a Delayed Job");
    }

    public void FireAndForgetJob()
    {
        Console.WriteLine("This is a Fire and Forget Job");
    }

    public void ReccuringJob()
    {
        Console.WriteLine("This is a Reccuring Job");
    }
}
