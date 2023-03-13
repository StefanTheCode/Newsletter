using Saga.Core.Abstract;

namespace Saga.Core.Concrete.Brokers
{
    public class MassTransitSettings : ISettings
    {
        public string Uri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? TripThreshold { get; set; }
        public int? ActiveThreshold { get; set; }
        public int? ResetInterval { get; set; }
        public int? RateLimit { get; set; }
        public int? RateLimiterInterval { get; set; }
        public int? TrackingPeriod { get; set; }
        public int? MessageRetryCount { get; set; }
    }
}