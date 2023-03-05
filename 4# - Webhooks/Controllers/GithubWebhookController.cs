using Microsoft.AspNetCore.Mvc;

namespace Webhooks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GithubWebhookController : ControllerBase
{
    [HttpPost]
    [Route("pushed")]
    public IActionResult Pushed(dynamic payload)
    {
        //Do something with payload

        return Ok();
    }
}