
public interface ITripRepository : IRepository<Trip>
{
    Task<Trip?> GetCurrentTripByDriverAsync(int driverId);
}