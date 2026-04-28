public class LocationDetail
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<RouteSummary> Routes { get; set; } = new();
    public List<RouteStopOccurrence> StopOccurrences { get; set; } = new();
}
