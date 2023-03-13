using System;

namespace Saga.Shared.Common
{
    public interface IMessage
    {
        Guid CorrelationId { get; }
    }
}
