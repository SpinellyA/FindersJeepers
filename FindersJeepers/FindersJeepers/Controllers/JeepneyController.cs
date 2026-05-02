
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/jeepneys")]
public class JeepneyController : ControllerBase
{
    private readonly IJeepService jeepService;

    public JeepneyController(IJeepService jeepService)
    {
        this.jeepService = jeepService;
    }

    [HttpGet]
    public async Task<IActionResult> GetJeepneys()
    {
        var result = await jeepService.GetAsync();
        return Ok(result);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetJeepneyById(int id)
    {
        var result = await jeepService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateJeepney([FromBody] CreateJeepneyRequest req)
    {
        await jeepService.CreateAsync(req);
        return Created();
    }
    [HttpPut("{jeepneyId:int}")]
    public async Task<IActionResult> UpdateJeepney(int jeepneyId, [FromBody] UpdateJeepneyRequest req)
    {
        await jeepService.UpdateAsync(req);
        return Ok();
    }

    [HttpPost("{jeepneyId:int}/drivers/")]
    public async Task<IActionResult> AssignDrivers(int jeepneyId, [FromBody] AssignDriversRequest req)
    {
        if (jeepneyId != req.JeepId)
            return BadRequest("Id mismatch!");

        await jeepService.AssignDriversAsync(req);
        return Ok();
    }

    [HttpGet("drivers/{jeepneyId:int}")]
    public async Task<IActionResult> GetJeepneyDrivers(int jeepneyId)
    {
        var result = await jeepService.GetJeepneyDriversAsync(jeepneyId);
        return Ok(result);
    }
    [HttpDelete("{jeepneyId:int}/drivers/{driverId:int}")]
    public async Task<IActionResult> RemoveDriverAsync(int jeepneyId, int driverId)
    {
        await jeepService.RemoveDriverAsync(driverId, jeepneyId);
        return Ok();
    }
}