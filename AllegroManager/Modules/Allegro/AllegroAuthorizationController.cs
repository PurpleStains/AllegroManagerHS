using AllegroConnector.Application.AllegroAuthorization.Commands;
using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Allegro
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/myallegro/[controller]")]
    public class AllegroAuthorizationController(IAllegroModule allegroModule) : ControllerBase
    {
        [HttpGet("GetCode")]
        public async Task<IActionResult> GetCode()
        {
            var result = await allegroModule.ExecuteCommandAsync(new GetCodeCommand());
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return Ok(result.Errors);
        }

        [HttpPost("Authorize")]
        public async Task<IActionResult> Authorize([FromBody] AuthorizeCommand command)
        {
            var result = await allegroModule.ExecuteCommandAsync(command);
            if (result.IsSuccess)
            {
                return Ok("Successfuly authorized");
            }

            var error = result.Errors.First() as AuthorizationError;
            return Ok(error);
        }

        [HttpGet("is-authorized")]
        public async Task<IActionResult> IsAuthorized()
        {
            var result = await allegroModule.ExecuteCommandAsync(new IsAuthorizedCommand());

            return Ok(result.Value);
        }
    }
}
