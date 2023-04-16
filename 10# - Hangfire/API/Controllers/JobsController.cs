using API.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;
        private readonly IBackgroundJobClient _jobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public JobsController(IJobsService jobsService, IBackgroundJobClient jobClient, IRecurringJobManager recurringJobManager)
        {
            _jobsService = jobsService;
            _jobClient = jobClient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet("FireAndForgetJob")]
        public ActionResult CreateFireAndForgetJob()
        {
            _jobClient.Enqueue(() => _jobsService.FireAndForgetJob());

            return Ok();
        }

        [HttpGet("DelayedJob")]
        public ActionResult CreateDelayedJob()
        {
            _jobClient.Schedule(() => _jobsService.DelayedJob(), TimeSpan.FromSeconds(60));

            return Ok();
        }

        [HttpGet("ReccuringJob")]
        public ActionResult CreateReccuringJob()
        {
            _recurringJobManager.AddOrUpdate("jobId", () => _jobsService.ReccuringJob(), Cron.Daily);

            return Ok();
        }

        [HttpGet("ContinuationJob")]
        public ActionResult CreateContinuationJob()
        {
            var parentJobId = _jobClient.Enqueue(() => _jobsService.FireAndForgetJob());

            _jobClient.ContinueJobWith(parentJobId, () => _jobsService.Continuation());

            return Ok();
        }

        [HttpGet("BatchJob")]
        public ActionResult CreateBatchJob()
        {
            //var batchId = BatchJob.StartNew(batch => {
            //    batch.Enqueue(() => DownloadFileFromServer());
            //    batch.Enqueue(() => ProcessFile());
            //    batch.Enqueue(() => SaveResultsToDatabase());
            //});

            return Ok();
        }
    }
}
