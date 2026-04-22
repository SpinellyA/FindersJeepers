
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/driver")]
public class DriverController : ControllerBase
{
    private readonly DriverService _driverService;

    public DriverController(DriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrivers()
    {

        return Ok();
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {

        return Ok();
    }

    [HttpPost] 
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest request)
    {

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDriver(int id, [FromBody] UpdateDriverRequest request)
    {
        if (id != request.Id)
            return BadRequest("Id mismatch");


        return Ok();
    }
}
