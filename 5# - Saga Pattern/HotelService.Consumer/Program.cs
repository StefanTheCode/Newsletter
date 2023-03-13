using System;
using HotelService.Consumer.Consumer;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.Core.Concrete.Brokers;
using Saga.Core.MessageBrokers.Concrete;
using Saga.Shared.Consumers.Models.Booking;

namespace HotelService.Consumer
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
                                cfg.ReceiveEndpoint(nameof(BookHotelReceivedEvent), e =>
                                {
                                    e.Consumer(() => new BookHotelReceivedConsumer());
                                });
                                cfg.ReceiveEndpoint(nameof(HotelBookedEvent), e =>
                                {
                                    e.Consumer(() => new HotelBookedConsumer());
                                });
                            });

                    bus.StartAsync();

                    Console.WriteLine("Hotel Booking Consumer Application started...");
                    Console.ReadLine();
                });
        }
    }
}