using AllegroConnector.Domain.Models;
using AllegroConnector.Domain.Models.Billings;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Domain
{
    public interface IAllegroApiClient
    {
        Task<SaleOffersResponse> SaleOffers(string limit, string offset);
        Task<CategoryResponse> GetCategories();
        Task<ConcreteProductOfferResponse> GetOffers(string offerID);
        Task<CalculatedFeeResponse> CalculateOfferFee(string offerID);
        Task<CheckoutFormResponse> GetOrders(string limit, string offset);
        Task<BillingEntries> GetBillingForOrder(Guid orderId);
    }
}
