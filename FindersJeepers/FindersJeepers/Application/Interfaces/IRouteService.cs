
public interface IRouteService
    {
    Task<List<GetRouteResponse>> GetRoutes();
    Task CreateRouteAsync(CreateRouteRequest req);
    }
