
public interface ILocationService
    {
        Task CreateAsync(CreateLocationRequest request);

        Task<List<GetLocationResponse>> GetAsync(int pageNumber = -1, int pageSize = -1);
        Task<GetLocationDetailResponse> GetByIdAsync(int locationId);
        Task UpdateAsync(UpdateLocationRequest request);
        Task DeleteAsync(int jeepId);
    }
