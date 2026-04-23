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
    public string LicenseNumber { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public DateTime DateHired { get; set; }
}

public record CreateJeepneyRequest
{

}

public record UpdateJeepneyRequest
{

}

public record AssignJeepRequest
{
    public int DriverId { get; set; }
    public int JeepId { get; set; }
}
