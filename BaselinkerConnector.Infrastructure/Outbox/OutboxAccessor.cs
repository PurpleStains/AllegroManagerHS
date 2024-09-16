
using AllegroConnector.BuildingBlocks.Application.Outbox;
using BaselinkerConnector.Infrastructure;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly BaselinkerContext _baselinkerContext;

        internal OutboxAccessor(BaselinkerContext meetingsContext)
        {
            _baselinkerContext = meetingsContext;
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