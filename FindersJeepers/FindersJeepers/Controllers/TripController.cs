
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/trips")]
public class TripController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTrip([FromBody] StartTripRequest req)
    {
        await _tripService.CreateDriverTrip(req);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var result = await _tripService.GetTripsAsync();
        return Ok(result);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTripDetail(int id)
    {
        var result = await _tripService.GetDetailAsync(id);
        return Ok(result);
    }

    [HttpPut("{id:int}/start")]
    public async Task<IActionResult> StartTrip(int id)
    {
        await _tripService.StartTrip(id);
        return Ok();
    }
    [HttpPut("{id:int}/complete")]
    public async Task<IActionResult> CompleteTrip(int id)
    {
        await _tripService.CompleteTrip(id);
        return Ok();
    }
    [HttpPost("{id:int}/next/")]
    public async Task<IActionResult> CompleteTrip(int id, [FromBody] NextStopRequest req)
    {
        await _tripService.NextStop(req);
        return Ok();
    }


}
