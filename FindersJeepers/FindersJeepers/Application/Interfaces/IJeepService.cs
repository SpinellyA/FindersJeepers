public interface IJeepService
{
    Task CreateAsync(CreateJeepneyRequest request);
    Task UpdateAsync(UpdateJeepneyRequest request);
    Task DeleteAsync(int jeepId);

    Task<List<GetJeepneyResponse>> GetAsync(int pageNumber = -1, int pageSize = -1);
    Task<GetJeepneyDetailResponse> GetByIdAsync(int jeepId);

    Task AssignDriversAsync(AssignDriversRequest request);

}
