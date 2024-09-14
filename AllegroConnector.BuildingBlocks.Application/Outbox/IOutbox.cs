namespace AllegroConnector.BuildingBlocks.Application.Outbox
{
    public interface IOutbox
    {
        void Add(OutboxMessage message);
        Task Save();
    }
}
