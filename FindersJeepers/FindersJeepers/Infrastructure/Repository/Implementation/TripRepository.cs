using Microsoft.EntityFrameworkCore;

public class TripRepository : Repository<Trip>, ITripRepository
{
    public TripRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<Trip?> GetCurrentTripByDriverAsync(int driverId) =>
        await _set.Where(x => x.DriverId == driverId && x.Status == TripStatus.OnGoing || x.Status == TripStatus.Waiting)
            .FirstOrDefaultAsync();

    public async Task<List<Trip>> GetTripsOfJeep(int jeepId) =>
        await _set.Where(x => x.JeepneyId == jeepId).ToListAsync();

    public override Task<Trip> GetByIdAsync(int id) => _context.Trips.Include(x=>x.Logs).FirstOrDefaultAsync(x=>x.Id == id);
}
