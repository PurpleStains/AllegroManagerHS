using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Allegro
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AllegroAuthorizationController : ControllerBase
    {
        //private readonly IAllegroOAuth _allegroOAuth;

        //public AllegroAuthorizationController(IAllegroOAuth allegroOAuth)
        //{
        //    _allegroOAuth = allegroOAuth;
        //}

        //[HttpPost("authorize")]
        //public async Task<IActionResult> Authorize()
        //{
        //    var response = await _allegroOAuth.Authorize();
        //    await Console.Out.WriteLineAsync($"Url: {response.verification_uri_complete}");
        //    var result = await _allegroOAuth.AwaitForAccessToken(response.interval, response.device_code);
        //    _allegroOAuthTokenWriter.PersisteToken(result);

        //    return Redirect(response.verification_uri_complete);
        //}
    }
}
