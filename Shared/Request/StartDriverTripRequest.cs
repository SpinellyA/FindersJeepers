public record StartDriverTripRequest
{
    public int DriverId { get; set; }
    public int? JeepId { get; set; }
    public RouteDirection? Direction { get; set; }
}
