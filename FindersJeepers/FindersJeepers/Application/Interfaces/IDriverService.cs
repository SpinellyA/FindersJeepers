
public interface IDriverService
{
    Task CreateAsync(CreateDriverRequest request);
    Task UpdateAsync(UpdateDriverRequest request);
    Task DeleteAsync(int driverId);
    Task<List<DriverDto>> GetAsync(int pageNumber = -1, int pageSize = -1);
    Task<DriverDetail> GetByIdAsync(int driverId);

    Task AssignJeepneysAsync(AssignJeepneysRequest request);
}
