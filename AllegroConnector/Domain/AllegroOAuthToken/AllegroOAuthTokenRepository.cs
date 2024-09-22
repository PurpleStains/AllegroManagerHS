using Token = AllegroConnector.Domain.OAuthToken;

namespace AllegroConnector.Infrastructure.Domain.AllegroOAuthToken
{
    public class AllegroOAuthTokenRepository : Token.IOAuthTokenRepository
    {
        private readonly AllegroContext _context;

        public AllegroOAuthTokenRepository(AllegroContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Token.AllegroOAuthToken token)
        {
            await _context.AddAsync(token);
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Token.AllegroOAuthToken?> Get()
        {
            var result = _context.AllegroOAuthTokens.AsQueryable().OrderByDescending(x => x.DateTimeStamp).FirstOrDefault();

            if (result is null)
                return default;

            return result;
        }

        public Task<Token.AllegroOAuthToken> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
