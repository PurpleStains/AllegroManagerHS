using AllegroConnector.Application.Queries;
using AllegroConnector.Domain;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class CategoriesQueryHandler : IQueryHandler<CategoriesQuery, CategoryResponse>
    {
        private readonly IAllegroApiService _apiClient;

        public CategoriesQueryHandler(IAllegroApiService apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<CategoryResponse> Handle(CategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = await _apiClient.GetCategories();

            return response;
        }
    }
}
