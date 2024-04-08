namespace AllegroConnector.BuildingBlocks.Application.Outbox
{
    public interface IOutBox
    {
        void Add(OutboxMessage message);
        Task Save();
    }
}
