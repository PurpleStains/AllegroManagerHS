using AllegroConnector.Domain;
using AllegroConnector.Domain.Models;
using AllegroConnector.Domain.Models.Billings;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Domain.Requests;
using AllegroConnector.Domain.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AllegroConnector.Application.AllegroApi
{
    public class AllegroApiService(HttpClient client, IAllegroOAuthTokenHandler tokenHandler) : IAllegroApiService
    {
        public async Task<SaleOffersResponse> SaleOffers(string limit, string offset)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "sale/offers");
            request.Content = new FormUrlEncodedContent([
                new("limit", limit),
                new("offset", offset)
            ]);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var offers = JsonSerializer.Deserialize<SaleOffersResponse>(await response.Content.ReadAsStringAsync());
            return offers;
        }

        public async Task<CategoryResponse> GetCategories()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "sale/categories");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var categories = JsonSerializer.Deserialize<CategoryResponse>(await response.Content.ReadAsStringAsync());
            return categories;
        }

        public async Task<ConcreteProductOfferResponse> GetOffers(string offerID)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"sale/product-offers/{offerID}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var offer = JsonSerializer.Deserialize<ConcreteProductOfferResponse>(await response.Content.ReadAsStringAsync());
            return offer;
        }

        public async Task<CalculatedFeeResponse> CalculateOfferFee(CalculateFeeRequest requestBody)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"pricing/offer-fee-preview");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), 
                Encoding.UTF8, "application/vnd.allegro.public.v1+json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var offer = JsonSerializer.Deserialize<CalculatedFeeResponse>(await response.Content.ReadAsStringAsync());
            return offer;
        }

        public async Task<CheckoutFormResponse> GetOrders(string limit, string offset)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"order/checkout-forms?limit={limit}&offset={offset}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var checkout = JsonSerializer.Deserialize<CheckoutFormResponse>(await response.Content.ReadAsStringAsync());
            return checkout;
        }

        public async Task<BillingEntries> GetBillingForOrder(Guid orderId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "billing/billing-entries");
            request.Content = new FormUrlEncodedContent([
                new("order.id", orderId.ToString())
            ]);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var billings = JsonSerializer.Deserialize<BillingEntries>(await response.Content.ReadAsStringAsync());
            return billings;
        }
    }
}
