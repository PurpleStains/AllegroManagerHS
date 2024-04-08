using AllegroConnector.Application.AllegroAuthorization.Commands;
using AllegroConnector.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Allegro
{
    public class AllegroConnectorController : ControllerBase
    {
        readonly IAllegroModule _allegroModule;

        public AllegroConnectorController(IAllegroModule allegroModule)
        {
            _allegroModule = allegroModule;
        }

        [HttpPost("getCode")]
        public async Task<IActionResult> GetCode()
        {
            var response = await _allegroModule.ExecuteCommandAsync(new GetCodeCommand());
            return Ok(response);
        }

        [HttpPost("auhorize")]
        public async Task<IActionResult> Authorize([FromBody] AuthorizeCommand command)
        {
            await _allegroModule.ExecuteCommandAsync(command);
            return Ok("Successfuly authorized");
        }
    }
}
