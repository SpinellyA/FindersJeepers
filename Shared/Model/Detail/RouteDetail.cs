public class RouteDetail
{
    public int Id { get; set; }
    public string RouteCode { get; set; } = string.Empty;
    public string LocationStart { get; set; } = string.Empty;
    public string LocationEnd { get; set; } = string.Empty;
    public List<RouteStopDto> Stops { get; set; } = new();
    public List<RouteStopDto> ReturnStops { get; set; } = new();
    public List<JeepneySummary> AssignedJeepneys { get; set; } = new();
}
