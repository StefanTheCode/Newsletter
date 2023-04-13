using System.Threading.Tasks;
using System;
using MassTransit;
using Saga.Shared.Consumers.Abstract;

namespace CarSevice.Consumer.Consumer
{
    public class RollbackCarConsumer : IConsumer<IRollbackCarCommand>
    {
        public RollbackCarConsumer()
        {
        }

        public async Task Consume(ConsumeContext<IRollbackCarCommand> context)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffffff")}:  I'm rollbacking Car Booking -{context.Message.CorrelationId}");
        }
    }
}
