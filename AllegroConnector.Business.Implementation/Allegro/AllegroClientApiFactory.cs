using AllegroConnector.Application;
using AutoMapper;

namespace AllegroConnector.Business.Implementation.Allegro
{
    public class AllegroClientApiFactory : IAllegroClientApiFactory
    {
        private IAllegroApiClient _apiClient;
        private readonly IAllegroOAuthTokenQuery _allegroOAuthTokenQuery;
        private readonly IMapper _mapper;

        public AllegroClientApiFactory(IAllegroOAuthTokenQuery allegroOAuthTokenQuery, IMapper mapper)
        {
            _allegroOAuthTokenQuery = allegroOAuthTokenQuery;
            _mapper = mapper;

            ConfigureAllegroApiClient();
        }

        public IAllegroApiClient GetAllegroApiClient()
        {
            throw new NotImplementedException();
        }

        private void ConfigureAllegroApiClient()
        {

            //_apiClient = new AllegroApiClient();

            ////TODO Added initial token from database.
            //var token = _mapper.Map<AllegroOAuthPerrmision>(_allegroOAuthTokenQuery.Get());

            //if (token == null)
            //{
            //    return;
            //}

            //_apiClient.SetToken(token);
        }
    }
}
