public class RouteStop
{
    public int Id { get; private set; }
    public int RouteId { get; private set; }
    public int LocationId { get; private set; }
    public int StopIndex { get; private set; }
    public RouteDirection Direction { get; private set; }

    private RouteStop() { }

    public static RouteStop Create(int routeId, int locationId, int stopIndex, RouteDirection direction)
    {
        if (routeId < 1) throw new DomainException("Invalid route id!");
        if (locationId < 1) throw new DomainException("Invalid location id!");
        if (stopIndex < 0) throw new DomainException("Invalid stop index!");

        return new RouteStop
        {
            RouteId = routeId,
            LocationId = locationId,
            StopIndex = stopIndex,
            Direction = direction
        };
    }
}

