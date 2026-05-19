

public interface ITripRepository : IRepository<Trip>
{
    Task<List<Trip>> GetActiveTripsOnRouteAsync(int routeId);
    Task<Trip?> GetCurrentTripByDriverAsync(int driverId);
    Task<Trip?> GetCurrentTripByJeepneyAsync(int jeepId);
}