using System;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.Core.Concrete.Brokers;
using Saga.Core.Constants;
using Saga.Core.MessageBrokers.Concrete;
using Saga.Shared.Consumers.Models.Sagas;

namespace Booking.Saga.Consumer
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

                    var p = hostContext.Configuration.GetSection("MassTransitSettings");

                    var massTransitSettings = hostContext.Configuration.GetSection("MassTransitSettings")
                                            .Get<MassTransitSettings>();

                    services.AddSingleton(massTransitSettings);

                    var bookingSaga = new BookingStateMachine();
                    var repo = new InMemorySagaRepository<BookingState>();

                    var bus = BusConfiguration.Instance
                    .ConfigureBus(massTransitSettings, (cfg) =>
                    {
                        cfg.ReceiveEndpoint(SagaConstants.SAGAQUEUENAME, e =>
                        {
                            e.StateMachineSaga(bookingSaga, repo);
                        });
                    });

                    bus.StartAsync();

                    var _busInstance = BusConfiguration.Instance.ConfigureBus(massTransitSettings);

                    SendEndpoint.Endpoint = _busInstance.GetSendEndpoint(new Uri($"{massTransitSettings.Uri}/{SagaConstants.SAGAQUEUENAME}")).Result;

                    Console.WriteLine("Booking Saga State Machine Application started...");
                    Console.ReadLine();
                });
        }
    }
}
