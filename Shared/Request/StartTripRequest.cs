public record StartTripRequest
{
    public int DriverId { get; set; }
    public int? JeepId { get; set; }
    public RouteDirection? Direction { get; set; }
}
