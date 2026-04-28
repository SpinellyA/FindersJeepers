

using Microsoft.EntityFrameworkCore;

public class RouteService : IRouteService
{
    private readonly IUnitOfWork _uow;

    public RouteService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<RouteDto>> GetRoutes()
    {
        var result = await (
        from r in _uow.Routes.Get()

        join ls in _uow.Locations.Get()
            on r.LocationStartId equals ls.Id

        join le in _uow.Locations.Get()
            on r.LocationEndId equals le.Id

        select new RouteDto
        {
            Id = r.Id,
            RouteCode = r.RouteCode,
            LocationStart = ls.Name,
            LocationEnd = le.Name,
            Stops = new()
        }
    ).ToListAsync();

        return result;
    }

    public async Task CreateRouteAsync(CreateRouteRequest req)
    {
        var route = Route.Create(req.RouteCode, req.StartLocation, req.EndLocation);
        await _uow.Routes.AddAsync(route);
        await _uow.SaveChangesAsync();
    }

}
