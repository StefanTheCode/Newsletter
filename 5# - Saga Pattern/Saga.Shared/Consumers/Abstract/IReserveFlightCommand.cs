using System;

namespace Saga.Shared.Consumers.Abstract
{
    public interface IReserveFlightCommand
    {
        Guid CorrelationId { get; }
        string FlightName { get; }
    }
}
