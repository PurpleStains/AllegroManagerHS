using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Models;

namespace AllegroConnector.Application.AllegroApi.Commands
{
    public class SeedOrdersCommand : CommandBase<CheckoutFormResponse>
    {
        public string Limit { get; }

        public string Offset { get; }

        public SeedOrdersCommand(string limit, string offset)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}
