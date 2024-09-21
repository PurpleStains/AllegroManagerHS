
using AllegroConnector.BuildingBlocks.Application.Outbox;
using BaselinkerConnector.Infrastructure;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Outbox
{
    public class OutboxAccessor(BaselinkerContext baselinkerContext) : IOutbox
    {
        public void Add(OutboxMessage message)
        {
            baselinkerContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}