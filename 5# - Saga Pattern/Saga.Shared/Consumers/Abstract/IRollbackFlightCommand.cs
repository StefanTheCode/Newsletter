using System;

namespace Saga.Shared.Consumers.Abstract
{
    public interface IRollbackFlightCommand
    {
        Guid CorrelationId { get; }
        string FlightName { get; }
    }
}
