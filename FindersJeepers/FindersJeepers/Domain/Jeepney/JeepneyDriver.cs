public class JeepneyDriver // child entity of Jeepney
{
    public int Id { get; private set; }
    public int JeepneyId { get; private set; }
    public int DriverId { get; private set; }
    public DateTime AssignedAt { get; private set; }
    public DateTime? UnassignedAt { get; private set; }

    private JeepneyDriver() { }

    public static JeepneyDriver Create(int jeepneyId, int driverId)
    {
        if (jeepneyId < 1) throw new DomainException("Invalid jeepney ID!");
        if (driverId < 1) throw new DomainException("Invalid driver ID!");

        return new JeepneyDriver
        {
            JeepneyId = jeepneyId,
            DriverId = driverId,
            AssignedAt = DateTime.UtcNow
        };
    }

    public void Deactivate()
    {
        if (UnassignedAt != null) throw new DomainException("This driver is already inactive!");
        UnassignedAt = DateTime.UtcNow;
    }
}