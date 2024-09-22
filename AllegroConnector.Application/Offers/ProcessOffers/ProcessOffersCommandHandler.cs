using AllegroConnector.Application.Commands;
using AllegroConnector.Application.Offers.Update;
using AllegroConnector.BuildingBlocks.Application.Data;
using AllegroConnector.Domain.Offer;
using Dapper;


namespace AllegroConnector.Application.Offers.ProcessOffers
{
    internal class ProcessOffersCommandHandler(
        ICommandsScheduler scheduler,
        ISqlConnectionFactory sqlConnectionFactory) : ICommandHandler<ProcessOffersCommand>
    {
        public async Task Handle(ProcessOffersCommand request, CancellationToken cancellationToken)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sql = $"""
                                SELECT 
                                    [offers].[AllegroOffers].[AllegroOfferId] AS [{nameof(AllegroOffer.AllegroOfferId)}]
                                FROM [offers].[AllegroOffers]
                                """;

            var offers = await connection.QueryAsync<Guid>(sql);

            foreach (var offer in offers)
            {
                await scheduler.EnqueueAsync(new UpdateOfferCommand(Guid.NewGuid(), offer));
            }
        }
    }
}
