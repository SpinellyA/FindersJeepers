
public interface IOptionService
{
    Task<List<DriverOption>> GetDriversForJeep(int jeepId);
    Task<List<JeepneyOption>> GetJeepsForDriver(int driverId);
    Task<List<LocationDto>> GetLocations();
    Task<List<LocationDto>> SearchLocations(string query);
}