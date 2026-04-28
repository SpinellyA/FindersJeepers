public class JeepneyDetail
{
    public int Id { get; set; }
    public string PlateNumber { get; set; } = string.Empty;
    public string BodyNumber { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string RouteCode { get; set; } = string.Empty;
    public string CurrentStatus { get; set; } = string.Empty;
    public List<DriverSummary> AssignedDrivers { get; set; } = new();
    public TripSummary? CurrentTrip { get; set; }
    public List<TripSummary> PastTrips { get; set; } = new();
}
