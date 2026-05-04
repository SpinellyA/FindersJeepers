


public interface ITripService
{
    Task<List<TripDto>> GetTripsAsync();
    Task NextStop(NextStopRequest req);
    Task CreateDriverTrip(StartDriverTripRequest req);
    Task<TripDetailDto> GetDetailAsync(int tripId);
    Task StartTrip(int tripId);
    Task CompleteTrip(int tripId);
}
