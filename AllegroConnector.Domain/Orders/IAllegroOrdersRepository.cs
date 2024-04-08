namespace AllegroConnector.Domain.Orders
{
    public interface IAllegroOrdersRepository
    {
        Task AddAsync(Order token);
        Task Update(Order order);

        Task<int> Commit();

        Task<Order> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> Get();
    }
}
