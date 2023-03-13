using System;
using System.Threading.Tasks;
using MassTransit;
using Saga.Shared.Consumers.Abstract;

namespace HotelService.Consumer
{
    public class HotelBookedConsumer : IConsumer<IHotelBookedEvent>
    {
        public HotelBookedConsumer()
        {
        }

        public async Task Consume(ConsumeContext<IHotelBookedEvent> context)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffffff")}: Hotel is booked (Consumer): {context.Message.CorrelationId}");

            await context.Publish<IReserveFlightCommand>(
            new { CorrelationId = context.Message.CorrelationId });
        }
    }
}