
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/location")]
public class LocationController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
    {

        return Ok();
    }
}