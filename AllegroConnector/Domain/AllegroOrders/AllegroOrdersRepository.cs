using AllegroConnector.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace AllegroConnector.Infrastructure.Domain.AllegroOrders
{
    internal class AllegroOrdersRepository : IAllegroOrdersRepository
    {
        private readonly AllegroContext _context;

        public AllegroOrdersRepository(AllegroContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.AddAsync(order);
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return _context.Orders
                .Include(l => l.LineItems)
                .ThenInclude(a => a.AllegroOffer)
                .ToList();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}
