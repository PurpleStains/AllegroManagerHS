using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Models;

namespace AllegroConnector.Application.AllegroApi.Commands
{
    public class SeedOrdersCommand : CommandBase<CheckoutFormResponse>
    {
        public string Limit { get; set; }

        public string Offset { get; set; }

        public SeedOrdersCommand(string limit, string offset)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}
