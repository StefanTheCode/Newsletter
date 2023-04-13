using System;
using System.Threading.Tasks;
using MassTransit;
using Saga.Shared.Consumers.Abstract;

namespace HotelService.Consumer.Consumer
{
    public class BookingFailedConsumer : IConsumer<IBookingFailedEvent>
    {
        public async Task Consume(ConsumeContext<IBookingFailedEvent> context)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffffff")}: Hotel is failed (Consumer): {context.Message.CorrelationId}");

            //await context.Publish<IHotelBookedEvent>(
            //  new { CorrelationId = context.Message.CorrelationId });
        }
    }
}
