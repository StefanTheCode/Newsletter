using System;

namespace Saga.Shared.Consumers.Abstract
{
    public interface IBookingFailedEvent
    {
        Guid CorrelationId { get; }
    }
}