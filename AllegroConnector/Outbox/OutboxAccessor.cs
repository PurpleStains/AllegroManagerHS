
using AllegroConnector.BuildingBlocks.Application.Outbox;

namespace AllegroConnector.Infrastructure.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly AllegroContext allegroContext;

        internal OutboxAccessor(AllegroContext context)
        {
            allegroContext = context;
        }

        public void Add(OutboxMessage message)
        {
            //_meetingsContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}