public interface IJeepService
{
    Task CreateAsync(CreateJeepneyRequest request);
    Task UpdateAsync(UpdateJeepneyRequest request);
    Task DeleteAsync(int jeepId);

    Task<List<JeepneyDto>> GetAsync(int pageNumber = -1, int pageSize = -1);
    Task<JeepneyDetail> GetDetail(int jeepId);

    Task AssignDriversAsync(AssignDriversRequest request);
    Task<List<JeepneyDriverDto>> GetJeepneyDriversAsync(int jeepId);
    Task RemoveDriverAsync(int driverId, int jeepneyId);
}
