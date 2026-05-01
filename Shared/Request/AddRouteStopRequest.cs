public class AddRouteStopRequest
{
    public int RouteId { get; set; }
    public List<LocationIndexPair> RouteStops { get; set; } // probably a bad idea to reuse routestopdto
}

public record LocationIndexPair
{
    public int LocationId { get; set; }
    public int Index { get; set; }
}