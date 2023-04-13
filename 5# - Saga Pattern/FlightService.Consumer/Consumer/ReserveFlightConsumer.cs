using System;
using System.Threading.Tasks;
using MassTransit;
using Saga.Shared.Consumers.Abstract;

namespace FlightService.Consumer.Consumer
{
    public class ReserveFlightConsumer : IConsumer<IReserveFlightCommand>
    {
        public ReserveFlightConsumer()
        {
        }

        public async Task Consume(ConsumeContext<IReserveFlightCommand> context)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffffff")}: Let's create Flight Booking for Flight -{context.Message.FlightName}");

             await context.Publish<IBookingFailedEvent>(
             new { CorrelationId = context.Message.CorrelationId });
            //await context.Publish<IReserveCarCommand>(
            // new { CorrelationId = context.Message.CorrelationId });
        }
    }
}
