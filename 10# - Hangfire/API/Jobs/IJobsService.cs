namespace API.Jobs;

public interface IJobsService
{
    void FireAndForgetJob();
    void DelayedJob();
    void ReccuringJob();
    void Continuation();
    void BatchJob();
}