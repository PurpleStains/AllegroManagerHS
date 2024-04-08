using MediatR;

namespace AllegroConnector.BuildingBlocks.Application.Events
{
    public interface IDomainEventNotification<out TEventType> : IDomainEventNotification
    {
        TEventType Type { get; }
    }

    public interface IDomainEventNotification : INotification
    {
        Guid id { get; }
    }
}
