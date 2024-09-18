using AllegroConnector.Application.Contracts;
using FluentResults;

namespace AllegroConnector.Application.Imports.ImportOffers
{
    public class ImportOffersCommand : CommandBase<Result>
    {
        public string[] PlainOffers { get; }

        public ImportOffersCommand(string[] plainOffers)
        {
            PlainOffers = plainOffers;
        }   
    }
}
