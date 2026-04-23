public record CreateDriverRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public DateTime DateHired { get; set; }
}

public record UpdateDriverRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
}

public record CreateJeepneyRequest
{
    public string PlateNumber { get; set; } = string.Empty;
    public string BodyNumber { get; set; } = string.Empty;
}

public record UpdateJeepneyRequest : CreateJeepneyRequest
{
    public int Id { get; set; }
}

public record AssignJeepRequest
{
    public int DriverId { get; set; }
    public int JeepId { get; set; }
    public List<int> AssignedDriverIds { get; set; }
    public int RouteId { get; set; }
}

public class CreateLocationRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UpdateLocationRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
