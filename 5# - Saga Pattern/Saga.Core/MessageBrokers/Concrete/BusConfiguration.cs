using System;
using MassTransit;
using Saga.Core.Concrete.Brokers;

namespace Saga.Core.MessageBrokers.Concrete
{
    public class BusConfiguration
    {
        private static readonly Lazy<BusConfiguration> _configurator = new Lazy<BusConfiguration>(() => new BusConfiguration());
        public static BusConfiguration Instance => _configurator.Value;

        public IBusControl ConfigureBus(MassTransitSettings massTransitSettings, Action<IRabbitMqBusFactoryConfigurator> action = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(massTransitSettings.Uri), hst =>
                {
                    hst.Username(massTransitSettings.Username);
                    hst.Password(massTransitSettings.Password);
                });

                SetRetryCount(massTransitSettings, cfg);
                SetTripThreshold(massTransitSettings, cfg);
                SetRateLimit(massTransitSettings, cfg);

                action?.Invoke(cfg);
            });
        }

        private static void SetRateLimit(MassTransitSettings massTransitSettings, IRabbitMqBusFactoryConfigurator cfg)
        {
            if (massTransitSettings.RateLimit.HasValue && massTransitSettings.RateLimiterInterval.HasValue)
            {
                cfg.UseRateLimit(massTransitSettings.RateLimit.Value, TimeSpan.FromSeconds(massTransitSettings.RateLimiterInterval.Value));
            }
        }

        private static void SetTripThreshold(MassTransitSettings massTransitSettings, IRabbitMqBusFactoryConfigurator cfg)
        {
            if (massTransitSettings.TripThreshold.HasValue && massTransitSettings.ActiveThreshold.HasValue && massTransitSettings.ResetInterval.HasValue)
            {
                cfg.UseCircuitBreaker(cb =>
                {
                    cb.TrackingPeriod = TimeSpan.FromMinutes(massTransitSettings.TrackingPeriod.Value);
                    cb.TripThreshold = massTransitSettings.TripThreshold.Value;
                    cb.ActiveThreshold = massTransitSettings.ActiveThreshold.Value;
                });
            }
        }

        private static void SetRetryCount(MassTransitSettings massTransitSettings, IRabbitMqBusFactoryConfigurator cfg)
        {
            if (massTransitSettings.MessageRetryCount.HasValue)
                cfg.UseMessageRetry(u => u.Immediate(massTransitSettings.MessageRetryCount.Value));
        }
    }
}