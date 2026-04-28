
public interface ITripService
    {
        Task<List<TripDto>> GetTrips(int driverId, int jeepId);
    }
