using AllegroConnector.Application.Queries;
using AllegroConnector.Domain.OAuthToken;

namespace AllegroConnector.Application.Test
{
    internal class TestQueryHandler : IQueryHandler<TestQuery, int>
    {
        private readonly IOAuthTokenRepository _oAuthRepository;

        public TestQueryHandler(IOAuthTokenRepository sqlConnectionFactory)
        {
            _oAuthRepository = sqlConnectionFactory;
        }

        public async Task<int> Handle(TestQuery query, CancellationToken cancellationToken)
        {
            var token = new AllegroOAuthToken()
            {
                Id = Guid.NewGuid(),
                DateTimeStamp = DateTime.Now,
                Jti = "123123123123"
            };
            await _oAuthRepository.AddAsync(token);
            return await _oAuthRepository.Commit();
        }
    }
}
