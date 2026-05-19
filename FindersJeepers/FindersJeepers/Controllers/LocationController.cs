
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] UpdateLocationRequest request)
    {
        await _locationService.UpdateAsync(request);
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetLocation(int id)
    {
        var result = await _locationService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
    {
        await _locationService.CreateAsync(request);
        return Created();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _locationService.DeleteAsync(id);
        return Ok();
    }
}
