
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/routes")]
public class RouteController : ControllerBase
{
    private readonly IRouteService _routeService;

    public RouteController(IRouteService routeService)
    {
        _routeService = routeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoutes()
    {
        var result = await _routeService.GetRoutesAsync();
        return Ok(result);
    }

    [HttpGet("{routeId:int}")]
    public async Task<IActionResult> GetRoute(int routeId)
    {
        var result = await _routeService.GetDetailAsync(routeId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoute([FromBody] CreateRouteRequest request)
    {
        await _routeService.CreateRouteAsync(request);
        return Created();
    }
    [HttpPut("{routeId:int}/stops/")]
    public async Task<IActionResult> AddStops(int routeId, [FromBody] AddRouteStopRequest request)
    {
        await _routeService.AddRouteStopsAsync(request);
        return Created();
    }

}
