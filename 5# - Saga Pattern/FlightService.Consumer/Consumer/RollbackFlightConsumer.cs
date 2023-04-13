using System;
using System.Threading.Tasks;
using MassTransit;
using Saga.Shared.Consumers.Abstract;

namespace FlightService.Consumer.Consumer
{
    public class RollbackFlightConsumer : IConsumer<IRollbackFlightCommand>
    {
        public RollbackFlightConsumer()
        {
        }

        public async Task Consume(ConsumeContext<IRollbackFlightCommand> context)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffffff")}: I'm rollbacking Flight Booking for Flight - {context.Message.FlightName}");
        }
    }
}