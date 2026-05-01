
public interface IRouteService
    {
    Task<List<RouteDto>> GetRoutes();
    Task CreateRouteAsync(CreateRouteRequest req);
    Task<RouteDetail> GetRoute(int routeId);
    Task AddRouteStopsAsync(AddRouteStopRequest req);
}
