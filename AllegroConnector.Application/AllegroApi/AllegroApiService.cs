using AllegroConnector.Domain;
using AllegroConnector.Domain.Models;
using AllegroConnector.Domain.Models.Billings;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Domain.Requests;
using AllegroConnector.Domain.Responses;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AllegroConnector.Application.AllegroApi
{
    public class AllegroApiService(HttpClient client, IAllegroOAuthTokenHandler tokenHandler) : IAllegroApiService
    {
        public async Task<SaleOffersResponse> SaleOffers(string limit, string offset)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "sale/offers");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenHandler.GetAccessToken());
            request.Content = new FormUrlEncodedContent([
                new("limit", limit),
                new("offset", offset)
            ]);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<SaleOffersResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<CategoryResponse> GetCategories()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "sale/categories");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenHandler.GetAccessToken());
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var categories = JsonConvert.DeserializeObject<CategoryResponse>(await response.Content.ReadAsStringAsync());
            return categories;
        }

        public async Task<ConcreteProductOfferResponse> GetOffers(string offerID)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"sale/product-offers/{offerID}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenHandler.GetAccessToken());
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var offer = JsonConvert.DeserializeObject<ConcreteProductOfferResponse>(await response.Content.ReadAsStringAsync());
            return offer;
        }

        public async Task<CalculatedFeeResponse> CalculateOfferFee(CalculateFeeRequest requestBody)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"pricing/offer-fee-preview");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenHandler.GetAccessToken());
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
            request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), 
                Encoding.UTF8, "application/vnd.allegro.public.v1+json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var offer = JsonConvert.DeserializeObject<CalculatedFeeResponse>(await response.Content.ReadAsStringAsync());
            return offer;
        }

        public async Task<CheckoutFormResponse> GetOrders(string limit, string offset)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"order/checkout-forms?limit={limit}&offset={offset}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenHandler.GetAccessToken());
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
            //request.Content = new FormUrlEncodedContent([
            //    new("limit", limit),
            //    new("offset", offset)
            //]);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var checkout = JsonConvert.DeserializeObject<CheckoutFormResponse>(await response.Content.ReadAsStringAsync());
            return checkout;
        }

        public async Task<BillingEntries> GetBillingForOrder(Guid orderId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "billing/billing-entries");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenHandler.GetAccessToken());
            request.Content = new FormUrlEncodedContent([
                new("order.id", orderId.ToString())
            ]);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var billings = JsonConvert.DeserializeObject<BillingEntries>(await response.Content.ReadAsStringAsync());
            return billings;
        }
    }
}
