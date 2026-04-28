
public interface IRouteService
    {
    Task<List<RouteDto>> GetRoutes();
    Task CreateRouteAsync(CreateRouteRequest req);
    }
