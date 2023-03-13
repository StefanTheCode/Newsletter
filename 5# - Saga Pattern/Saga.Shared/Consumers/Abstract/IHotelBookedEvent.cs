using System;

namespace Saga.Shared.Consumers.Abstract
{
    public interface IHotelBookedEvent
    {
        Guid CorrelationId { get; }
    }
}
