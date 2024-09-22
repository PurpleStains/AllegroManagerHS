namespace AllegroConnector.Domain.Offer
{
    public interface IAllegroOffersRepository
    {
        public Task AddAsync(AllegroOffer offer);

        public Task<AllegroOffer> GetByIdAsync(Guid offerId);
        public Task<AllegroOffer> GetByIdAsync(string offerId);
        public Task<AllegroOffer> GetByEanAsync(string ean);

        public Task<List<AllegroOffer>> Get();

        public Task CommitAsync();
    }
}
