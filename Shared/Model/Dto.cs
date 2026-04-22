
public class DriverDto
{
    public int Id { get; set; }

    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public DateTime DateHired { get; set; }

    public int JeepId { get; set; }
    public string JeepPlateNumber { get; set; }
}

public class JeepneyDto
{
    public int Id { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public string BodyNumber { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public string RouteCode { get; set; } = string.Empty;
}
public class RouteDto
{
    public int Id { get; set; }
    public string RouteCode { get; set; } = string.Empty;
    public string LocationStart { get; set; } = string.Empty;
    public string LocationEnd { get; set; } = string.Empty;
    public List<RouteStopDto> Stops { get; set; } = new();
}
public class RouteStopDto
{
    public int LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public int StopIndex { get; set; }
}
public class TripDto
{
    public int Id { get; set; }
    public string PlateNumber { get; set; } = string.Empty;
    public string RouteCode { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
    public int LogCount { get; set; }

}
public class TripLogDto
{
    public string StopName { get; set; } = string.Empty;
    public string EventType { get; set; } = string.Empty;
    public int PassengerCount { get; set; }
    public DateTime Timestamp { get; set; }
}