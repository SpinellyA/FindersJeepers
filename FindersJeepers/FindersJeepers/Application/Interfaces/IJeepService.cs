public interface IJeepService
{
    Task CreateAsync(CreateJeepneyRequest request);
    Task UpdateAsync(UpdateJeepneyRequest request);
    Task DeleteAsync(int jeepId);

    Task<List<JeepneyDto>> GetAsync(int pageNumber = -1, int pageSize = -1);
    Task<JeepneyDetail> GetByIdAsync(int jeepId);

    Task AssignDriversAsync(AssignDriversRequest request);

}
