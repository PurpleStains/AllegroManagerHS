using BaselinkerConnector.Application.BaselinkerApi.Requests;
using BaselinkerConnector.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Baselinker
{
    public class BaselinkerController(IBaselinkerModule baselinker) : ControllerBase
    {
        [HttpGet("Products")]
        public async Task<IActionResult> Products()
        {
            var response = await baselinker.ExecuteRequestAsync(new GetBaselinkerProductsRequest());
            return Ok(response);
        }
    }
}
