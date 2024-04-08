namespace AllegroConnector.Domain.OAuthToken
{
    public interface IOAuthTokenRepository
    {
        Task AddAsync(AllegroOAuthToken token);

        Task<int> Commit();

        Task<AllegroOAuthToken> GetByIdAsync(Guid id);
        Task<AllegroOAuthToken> Get();
    }
}
