using System;
using System.Threading.Tasks;
using MassTransit;
using Saga.Shared.Consumers.Abstract;

namespace HotelService.Consumer.Consumer
{
    public class BookHotelReceivedConsumer : IConsumer<IBookHotelReceivedEvent>
    {
        public async Task Consume(ConsumeContext<IBookHotelReceivedEvent> context)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffffff")}: Hotel is received (Consumer): {context.Message.HotelName}");

            await context.Publish<IHotelBookedEvent>(
              new { CorrelationId = context.Message.CorrelationId });
        }
    }
}
