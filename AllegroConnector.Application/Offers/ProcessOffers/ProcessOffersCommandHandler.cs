using AllegroConnector.Application.Commands;
using AllegroConnector.Domain;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.Offers.ProcessOffers
{
    internal class ProcessOffersCommandHandler(IAllegroApiService api) : ICommandHandler<ProcessOffersCommand>
    {
        public async Task Handle(ProcessOffersCommand request, CancellationToken cancellationToken)
        {
            //int offset = 0; // Start from 0 and then apply offset from request
            //var result = new List<SaleOffersResponse>();
            //for (var i = 0; i < request.Limit / request.Offset; i++)
            //{
            //    var response = await api.SaleOffers(offset.ToString(), request.Limit.ToString());
            //    result.Add( response);
            //    offset += request.Offset;
            //}
        }
    }
}
