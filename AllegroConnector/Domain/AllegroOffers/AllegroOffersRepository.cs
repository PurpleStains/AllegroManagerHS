using AllegroConnector.Domain.Offer;
using Microsoft.EntityFrameworkCore;

namespace AllegroConnector.Infrastructure.Domain.AllegroOffers
{
    internal class AllegroOffersRepository : IAllegroOffersRepository
    {
        readonly AllegroContext _context;

        public AllegroOffersRepository(AllegroContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AllegroOffer offer)
        {
            await _context.AllegroOffers.AddAsync(offer);
        }

        public async Task<AllegroOffer> GetByIdAsync(Guid Id)
        {
            return await _context.AllegroOffers.FirstOrDefaultAsync(x => x.AllegroOfferId == Id);
        }

        public async Task<AllegroOffer> GetByIdAsync(string offerId)
        {
            return await _context.AllegroOffers.FirstOrDefaultAsync(x => x.OfferId == offerId);
        }

        public async Task<List<AllegroOffer>> Get()
        {
            return await _context.AllegroOffers.ToListAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<AllegroOffer> GetByEanAsync(string ean)
        {
            return await _context.AllegroOffers.FirstOrDefaultAsync(x => x.EAN.Equals(ean));
        }
    }
}
