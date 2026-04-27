public record AssignDriversRequest
{
    public int JeepId { get; set; }
    public List<int> DriverIds { get; set; } = new();

}


/*
 * Driver Profile:
 * When assingning a jeepney, add multiple jeepneys to one driver.
 * 
 * Jeepney Profile:
 * When assigning drivers, add multiple drivers to that jeepney.
 * 
 * 
 */