using AllegroConnector.Application.AllegroApi.Commands;
using AllegroConnector.Application.AllegroApi.Queries;
using AllegroConnector.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Allegro
{
    [ApiController]
    [Route("api/myallegro/[controller]")]
    [AllowAnonymous]
    public class SaleController : ControllerBase
    {
        private readonly IAllegroModule _allegroModule;

        public SaleController(IAllegroModule allegroModule)
        {
            _allegroModule = allegroModule;
        }


        [HttpGet("categories")]
        public async Task<IActionResult> Categories()
        {
            var response = await _allegroModule.ExecuteQueryAsync(new CategoriesQuery());

            return Ok(response);
        }

        [HttpGet("saleOffers")]
        public async Task<IActionResult> SaleOffers([FromQuery] string limit, string offset)
        {
            var response = await _allegroModule.ExecuteQueryAsync(new SaleOffersQuery(limit, offset));

            return Ok(response);
        }

        [HttpGet("offers")]
        public async Task<IActionResult> Offers(string offerId)
        {
            var response = await _allegroModule.ExecuteQueryAsync(new OfferQuery(offerId));

            return Ok(response);
        }

        [HttpGet("calculateFee")]
        public async Task<IActionResult> CalculateFeeForOffer([FromQuery] string offerId)
        {
            var response = await _allegroModule.ExecuteQueryAsync(new CalculateOfferFeeQuery(offerId));
            return Ok(response);
        }

        [HttpGet("seedOrders")]
        public async Task<IActionResult> SeedOrders([FromQuery] string limit, string offset)
        {
            var response = await _allegroModule.ExecuteCommandAsync(new SeedOrdersCommand(limit, offset));
            return Ok(response);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> Orders([FromQuery] string limit, string offset)
        {
            var response = await _allegroModule.ExecuteQueryAsync(new OrdersQuery());
            return Ok(response);
        }

        [HttpGet("orderBillings")]
        public async Task<IActionResult> OrderBillings([FromQuery] DateTime from, DateTime to)
        {
            var response = await _allegroModule.ExecuteQueryAsync(new OrdersBillingQuery(from, to));
            return Ok(response);
        }
    }
}
