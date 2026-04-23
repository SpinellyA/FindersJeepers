
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/locations")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        var result = await _locationService.GetAsync();
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
    {
        await _locationService.CreateAsync(request);
        return Created();
    }
}
