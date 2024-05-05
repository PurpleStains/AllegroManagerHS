using AllegroConnector.Domain.Models;
using AllegroConnector.Domain.Models.Billings;
using AllegroConnector.Domain.Requests;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Domain
{
    public interface IAllegroApiService
    {
        Task<SaleOffersResponse> SaleOffers(string limit, string offset);
        Task<CategoryResponse> GetCategories();
        Task<ConcreteProductOfferResponse> GetOffers(string offerID);
        Task<CalculatedFeeResponse> CalculateOfferFee(CalculateFeeRequest request);
        Task<CheckoutFormResponse> GetOrders(string limit, string offset);
        Task<BillingEntries> GetBillingForOrder(Guid orderId);
    }
}
