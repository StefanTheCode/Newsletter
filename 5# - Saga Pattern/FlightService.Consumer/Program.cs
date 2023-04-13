using System;
using FlightService.Consumer.Consumer;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.Core.Concrete.Brokers;
using Saga.Core.MessageBrokers.Concrete;
using Saga.Shared.Consumers.Models.Car;
using Saga.Shared.Consumers.Models.Flight;

namespace FlightService.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", true, true);
                config.AddEnvironmentVariables();

                if (args != null)
                    config.AddCommandLine(args);
            })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();

                    var massTransitSettings = hostContext.Configuration.GetSection("MassTransitSettings")
                        .Get<MassTransitSettings>();
                    services.AddSingleton(massTransitSettings);

                    var bus = BusConfiguration.Instance
                            .ConfigureBus(massTransitSettings, (cfg) =>
                            {
                                cfg.ReceiveEndpoint(nameof(ReserveFlightCommand), e =>
                                {
                                    e.Consumer(() => new ReserveFlightConsumer());
                                });

                                cfg.ReceiveEndpoint(nameof(RollbackFlightCommand), e =>
                                {
                                    e.Consumer(() => new RollbackFlightConsumer());
                                });;
                            });

                    bus.StartAsync();

                    Console.WriteLine("Flight Booking Consumer Application started...");
                    Console.ReadLine();
                });
        }
    }
}
