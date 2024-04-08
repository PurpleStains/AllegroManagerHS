using AllegroConnector.Application.AllegroAuthorization.Commands;
using AllegroConnector.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Allegro
{
    public class AllegroConnectorController(IAllegroModule allegroModule) : ControllerBase
    {
        [HttpPost("getCode")]
        public async Task<IActionResult> GetCode()
        {
            var response = await allegroModule.ExecuteCommandAsync(new GetCodeCommand());
            return Ok(response);
        }

        [HttpPost("auhorize")]
        public async Task<IActionResult> Authorize([FromBody] AuthorizeCommand command)
        {
            await allegroModule.ExecuteCommandAsync(command);
            return Ok("Successfuly authorized");
        }
    }
}
