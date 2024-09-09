using AllegroConnector.Application.AllegroApi.Commands;
using AllegroConnector.Application.AllegroApi.Queries;
using AllegroConnector.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Allegro
{
    [ApiController]
    [Route("api/myallegro/[controller]")]
    [AllowAnonymous]
    public class OrdersController(IAllegroModule allegroModule) : ControllerBase
    {

        [HttpGet("seedOrders")]
        public async Task<IActionResult> SeedOrders([FromQuery] string limit, string offset)
        {
            var response = await allegroModule.ExecuteCommandAsync(new SeedOrdersCommand(limit, offset));
            return Ok(response);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> Orders([FromQuery] string limit, string offset)
        {
            var response = await allegroModule.ExecuteQueryAsync(new OrdersQuery());
            return Ok(response);
        }

        [HttpGet("orderBillings")]
        public async Task<IActionResult> OrderBillings([FromQuery] DateTime from, DateTime to)
        {
            var response = await allegroModule.ExecuteQueryAsync(new OrdersBillingQuery(from, to));
            return Ok(response);
        }
    }
}
