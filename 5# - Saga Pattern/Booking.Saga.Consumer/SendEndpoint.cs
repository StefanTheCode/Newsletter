using MassTransit;

namespace Booking.Saga.Consumer
{
    public class SendEndpoint
    {
        public static ISendEndpoint Endpoint { get; set; }
    }
}
