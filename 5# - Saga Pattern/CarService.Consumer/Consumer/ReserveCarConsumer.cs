using System.Threading.Tasks;
using System;
using MassTransit;
using Saga.Shared.Consumers.Abstract;

namespace CarSevice.Consumer.Consumer
{
    public class ReserveCarConsumer : IConsumer<IReserveCarCommand>
    {
        public ReserveCarConsumer()
        {
        }

        public async Task Consume(ConsumeContext<IReserveCarCommand> context)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffffff")}: Let's create Car Booking -{context.Message.CorrelationId}");

           
        }
    }
}
