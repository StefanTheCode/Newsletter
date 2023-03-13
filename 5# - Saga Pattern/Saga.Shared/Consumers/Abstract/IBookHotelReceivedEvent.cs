using System;

namespace Saga.Shared.Consumers.Abstract
{
    public interface IBookHotelReceivedEvent
    {
        Guid CorrelationId { get; }
        string HotelName { get; }
    }
}
