using AllegroConnector.Domain;
using AllegroConnector.Domain.Models;
using AllegroConnector.Domain.Models.Billings;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Domain.Requests;
using AllegroConnector.Domain.Responses;
using Newtonsoft.Json;
using RestSharp;
using Category = AllegroConnector.Domain.Models.Category;
using Method = RestSharp.Method;
using Offer = AllegroConnector.Domain.Models.Offer;

namespace AllegroConnector.Application.AllegroApi
{
    public class AllegroApiClient : IAllegroApiClient
    {
        private readonly IAllegroOAuthTokenHandler _tokenHandler;
        private readonly static string url = "https://api.allegro.pl/";
        private readonly string _marketPlace = "allegro-pl";

        public AllegroApiClient(IAllegroOAuthTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        public async Task<SaleOffersResponse> SaleOffers(string limit, string offset)
        {
            var client = new RestClient(url);
            var request = new RestRequest($"sale/offers", Method.Get);

            request.AddOrUpdateParameter("Authorization", $"Bearer {await _tokenHandler.GetAccessToken()}", ParameterType.HttpHeader);
            request.AddParameter("limit", limit);
            request.AddParameter("offset", offset);
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");

            var response = await client.ExecuteAsync(request);

            var offers = JsonConvert.DeserializeObject<SaleOffersResponse>(response.Content);
            return offers;
        }

        public async Task<CategoryResponse> GetCategories()
        {
            var client = new RestClient(url);
            var request = new RestRequest("sale/categories", Method.Get);

            request.AddOrUpdateParameter("Authorization", $"Bearer {await _tokenHandler.GetAccessToken()}", ParameterType.HttpHeader);
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");

            var response = await client.ExecuteAsync(request);

            var categories = JsonConvert.DeserializeObject<CategoryResponse>(response.Content);
            return categories;
        }

        public async Task<ConcreteProductOfferResponse> GetOffers(string offerID)
        {
            var client = new RestClient(url);
            var request = new RestRequest($"sale/product-offers/{offerID}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {await _tokenHandler.GetAccessToken()}");
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");

            var response = await client.ExecuteAsync(request);

            var offer = JsonConvert.DeserializeObject<ConcreteProductOfferResponse>(response.Content);
            return offer;
        }

        public async Task<CalculatedFeeResponse> CalculateOfferFee(string offerID)
        {
            var offerFromAllegro = await GetOffers(offerID);
            var body = new CalculateFeeRequest()
            {
                offer = new Offer()
                {
                    fundraisingCampaign = null,
                    category = new Category()
                    {
                        id = offerFromAllegro.category.id,
                    },
                    sellingMode = offerFromAllegro.sellingMode
                },
                classifiedsPackages = null,
                marketplaceId = _marketPlace
            };

            var client = new RestClient(url);
            var request = new RestRequest($"pricing/offer-fee-preview", Method.Post);
            request.AddHeader("Authorization", $"Bearer {await _tokenHandler.GetAccessToken()}");
            request.AddHeader("Content-Type", "application/vnd.allegro.public.v1+json");
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");
            request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);
            var offer = JsonConvert.DeserializeObject<CalculatedFeeResponse>(response.Content);
            return offer;
        }

        public async Task<CheckoutFormResponse> GetOrders(string limit, string offset)
        {
            var client = new RestClient(url);
            var request = new RestRequest("order/checkout-forms", Method.Get);

            request.AddOrUpdateParameter("Authorization", $"Bearer {await _tokenHandler.GetAccessToken()}", ParameterType.HttpHeader);
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");
            request.AddParameter("limit", limit);
            request.AddParameter("offset", offset);

            var response = await client.ExecuteAsync(request);
            var checkout = JsonConvert.DeserializeObject<CheckoutFormResponse>(response.Content);
            return checkout;
        }

        public async Task<BillingEntries> GetBillingForOrder(Guid orderId)
        {
            var client = new RestClient(url);
            var request = new RestRequest("billing/billing-entries", Method.Get);

            request.AddOrUpdateParameter("Authorization", $"Bearer {await _tokenHandler.GetAccessToken()}", ParameterType.HttpHeader);
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");
            request.AddParameter("order.id", orderId);

            var response = await client.ExecuteAsync(request);
            var billings = JsonConvert.DeserializeObject<BillingEntries>(response.Content);
            return billings;
        }
    }
}
