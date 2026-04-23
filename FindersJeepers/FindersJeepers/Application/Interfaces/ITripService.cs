
public interface ITripService
    {
        Task<List<GetTripResponse>> GetTrips(int driverId, int jeepId);
    }
