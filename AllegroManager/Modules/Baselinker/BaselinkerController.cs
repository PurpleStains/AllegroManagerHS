using BaselinkerConnector.Application.BaselinkerApi.Requests;
using BaselinkerConnector.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Baselinker
{
    public class BaselinkerController(IBaselinkerModule baselinker) : ControllerBase
    {
        [HttpGet("ProductDetails")]
        public async Task<IActionResult> ProductDetails()
        {
            var response = await baselinker.ExecuteRequestAsync(new GetProductDetailsRequest());
            return Ok(response);
        }

        [HttpGet("Products")]
        public async Task<IActionResult> Products()
        {
            var response = await baselinker.ExecuteRequestAsync(new GetProductsRequest());
            return Ok(response);
        }
    }
}
