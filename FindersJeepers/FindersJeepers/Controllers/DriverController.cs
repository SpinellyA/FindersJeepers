
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/drivers")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrivers()
    {
        var result = await _driverService.GetAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _driverService.GetDetail(id);
        return Ok(result);
    }

    [HttpPost] 
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest request)
    {
        await _driverService.CreateAsync(request);
        return Created();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDriver(int id, [FromBody] UpdateDriverRequest request)
    {
        if (id != request.Id)
            return BadRequest("Id mismatch");

        await _driverService.UpdateAsync(request);

        return Ok();
    }

    [HttpPut("jeepneys/{driverId:int}")]
    public async Task<IActionResult> AssignJeepneys(int driverId, [FromBody] AssignJeepneysRequest request)
    {
        if (driverId != request.DriverId)
            return BadRequest("Id mismatch!");

        await _driverService.AssignJeepneysAsync(request);

        return Ok();
    }


}
