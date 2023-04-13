using System;

namespace Saga.Shared.Consumers.Abstract
{
    public interface IRollbackCarCommand
    {
        Guid CorrelationId { get; }
    }
}
