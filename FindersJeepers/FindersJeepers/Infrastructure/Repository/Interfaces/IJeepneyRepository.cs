
public interface IJeepneyRepository : IRepository<Jeepney>
{
    Task<List<Jeepney>> GetByDriverAsync(int driverId);
}