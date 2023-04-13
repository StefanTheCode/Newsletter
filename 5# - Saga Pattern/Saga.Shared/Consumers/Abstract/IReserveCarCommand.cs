using System;

namespace Saga.Shared.Consumers.Abstract
{
    public interface IReserveCarCommand
    {
        Guid CorrelationId { get; }
    }
}
