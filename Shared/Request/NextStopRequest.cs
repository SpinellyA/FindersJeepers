public record NextStopRequest
{
    public int TripId { get; set; }
    public int PassengerCount { get; set; }
}